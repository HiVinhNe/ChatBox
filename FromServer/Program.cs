using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FromServer
{
    internal class Program
    {
        static List<Socket> clients = new List<Socket>(); // Danh sách các Client
        static Dictionary<String, String> userOnline = new Dictionary<String, String>();
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 6969);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            server.Listen(10);
            Console.WriteLine("Server is running and waiting for connections...");

            while (true)
            {
                Socket client = server.Accept();
                clients.Add(client); // Thêm Client vào danh sách

                Console.WriteLine("Connected to client: {0}", client.RemoteEndPoint);

                // Tạo luồng để xử lý Client
                Thread clientThread = new Thread(HandleClient);
                clientThread.IsBackground = true;
                clientThread.Start(client);
            }
        }

        static void HandleClient(object obj)
        {
            Socket client = (Socket)obj;

            try
            {
                // Gửi thông báo chào mừng
                string welcomeMsg = "Welcome to the chat server!";
                client.Send(Encoding.ASCII.GetBytes(welcomeMsg));
                
                while (true)
                {
                    byte[] dataRecv = new byte[1024];
                    int recv = client.Receive(dataRecv);

                    if (recv == 0) break; // Nếu Client ngắt kết nối

                    string msg = Encoding.ASCII.GetString(dataRecv, 0, recv);
                    Console.WriteLine("Client ({0}): {1}", client.RemoteEndPoint, msg);

                    if (msg.Contains("Name:"))
                    {
                        int spaceIndex = msg.IndexOf(' ');
                        msg = msg.Substring(spaceIndex + 1);  // Bắt đầu từ vị trí sau dấu cách
                        userOnline.Add(client.RemoteEndPoint.ToString(), msg);
                    }
                    else if (msg.ToUpper() == "EXIT")
                    {
                        Console.WriteLine("Client ({0}) disconnected.", client.RemoteEndPoint);
                        userOnline.Remove(client.RemoteEndPoint.ToString());
                        break;
                    }
                    else
                    {

                        // Gửi tin nhắn đến tất cả các Client
                        BroadcastMessage($"{userOnline[client.RemoteEndPoint.ToString()]}: {msg}", client);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                clients.Remove(client); // Xóa Client khỏi danh sách
                client.Close();
            }
        }

        static void BroadcastMessage(string message, Socket sender)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            foreach (Socket client in clients)
            {
                if (client != sender) // Không gửi lại cho người gửi
                {
                    try
                    {
                        client.Send(buffer);
                    }
                    catch (Exception)
                    {
                        // Nếu Client không phản hồi, loại bỏ khỏi danh sách
                        clients.Remove(client);
                        client.Close();
                    }
                }
            }
        }
    }
}
