using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;

        public Form1()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            client = new TcpClient("127.0.0.1", 4900);
            stream = client.GetStream();
            AppendText("\nConnected to the server...\n");
            receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AppendText("\nServer: " + message);
                }
            }
            catch
            {
                AppendText("Disconnected from server.\n");
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessage(textBoxMessage.Text);
        }

        private void SendMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message) || client == null) return;

            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
            AppendText("You: " + message + "\n");
            textBoxMessage.Clear();
        }

        private void AppendText(string text)
        {
            if (textBoxServerResponse.InvokeRequired)
            {
                textBoxServerResponse.Invoke(new Action(() => textBoxServerResponse.AppendText(text)));
            }
            else
            {
                textBoxServerResponse.AppendText(text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client?.Close();
            receiveThread?.Abort();
        }
    }
}
