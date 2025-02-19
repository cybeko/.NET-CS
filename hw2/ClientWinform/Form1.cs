using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClientWinform
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 4900);
                stream = client.GetStream();
                OutputText("Connected to server.\r\n");
            }
            catch (Exception ex)
            {
                OutputText($"Error: {ex.Message}\r\n");
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendRequest();
        }

        private void SendRequest()
        {
            byte[] data = Encoding.UTF8.GetBytes("GET_WORD");
            stream.Write(data, 0, data.Length);

            byte[] buf = new byte[1024];
            int bytes = stream.Read(buf, 0, buf.Length);
            string response = Encoding.UTF8.GetString(buf, 0, bytes);
            OutputText($"{response}\r\n");
        }

        private void OutputText(string text)
        {
            if (textBoxChat.InvokeRequired)
            {
                textBoxChat.Invoke(new Action<string>(OutputText), text);
            }
            else
            {
                textBoxChat.AppendText(text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client?.Close();
        }
    }
}
