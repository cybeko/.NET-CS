using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class TcpChatServer
{
    private static List<TcpClient> clients = new List<TcpClient>();
    private static TcpListener server;
    private static List<MenuItem> menuItems = new List<MenuItem>();
    private static Queue<Order> orderQueue = new Queue<Order>();
    private static bool isKitchenFree = true;
    static void Main()
    {
        try
        {
            InitializeMenu();

            server = new TcpListener(IPAddress.Any, 4900);
            server.Start();
            Console.WriteLine("Server is running...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Console.WriteLine("new client connected.");

                SendMenuToClient(client);

                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Recieved: " + message);
                ProcessOrder(message, client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            clients.Remove(client);
            client.Close();
            Console.WriteLine("Client disconnected.");
        }
    }

    private static void ProcessOrder(string orderText, TcpClient client)
    {
        int orderCookingTime = 0;
        foreach (var item in menuItems)
        {
            if (orderText.ToLower().Contains(item.Name.ToLower()))
            {
                orderCookingTime += item.CookingTime;
            }
        }

        Order order = new Order
        {
            Client = client,
            CookingTime = orderCookingTime
        };

        lock (orderQueue)
        {
            if (isKitchenFree)
            {
                isKitchenFree = false;
                SendOrderDetails(order, client);
                Thread cookingThread = new Thread(() => CookOrder(order));
                cookingThread.Start();
            }
            else
            {
                orderQueue.Enqueue(order);
                NotifyClientOrderWaiting(order, client);
            }
        }
    }

    private static void SendOrderDetails(Order order, TcpClient client)
    {
        string message = $"Your order will be ready in {order.CookingTime} seconds\n";
        SendMessageToClient(message, client);
    }

    private static void NotifyClientOrderWaiting(Order order, TcpClient client)
    {
        lock (orderQueue)
        {
            int waitingTime = 0;
            foreach (var queuedOrder in orderQueue)
            {
                waitingTime += queuedOrder.CookingTime;
            }
            string message = $"Your order will be ready in {waitingTime + order.CookingTime} seconds\n";
            SendMessageToClient(message, client);
        }
    }

    private static void CookOrder(Order order)
    {
        Thread.Sleep(order.CookingTime * 1000);
        CompleteOrder(order);
    }
    private static void CompleteOrder(Order order)
    {
        lock (orderQueue)
        {
            string message = "Order is ready!\n";
            SendMessageToClient(message, order.Client);

            if (orderQueue.Count > 0)
            {
                var nextOrder = orderQueue.Dequeue();
                isKitchenFree = false;
                SendOrderDetails(nextOrder, nextOrder.Client);
                Thread cookingThread = new Thread(() => CookOrder(nextOrder));
                cookingThread.Start();
            }
            else
            {
                isKitchenFree = true; 
            }
        }
    }

    private static void SendMessageToClient(string message, TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);
    }
    private static void InitializeMenu()
    {
        menuItems = new List<MenuItem>
        {
            new MenuItem { Name = "burger", Cost = 10, CookingTime = 3 },
            new MenuItem { Name = "pizza", Cost = 15, CookingTime = 2 },
            new MenuItem { Name = "cola", Cost = 12, CookingTime = 1 },
            new MenuItem { Name = "salad", Cost = 8, CookingTime = 2 },
            new MenuItem { Name = "fries", Cost = 25, CookingTime = 5 },
            new MenuItem { Name = "sprite", Cost = 25, CookingTime = 5 },
            new MenuItem { Name = "steak", Cost = 25, CookingTime = 5 }
        };
    }
    private static void SendMenuToClient(TcpClient client)
    {
        string menuString = GetMenuString();
        byte[] data = Encoding.UTF8.GetBytes(menuString);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);
    }

    private static string GetMenuString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("\nMenu: ");
        foreach (var item in menuItems)
        {
            sb.AppendLine($"\nItem: {item.Name}, price: ${item.Cost}, cooking time: {item.CookingTime} seconds");
        }
        return sb.ToString();
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int CookingTime { get; set; }
    }

    public class Order
    {
        public TcpClient Client { get; set; }
        public int CookingTime { get; set; }
    }
}
