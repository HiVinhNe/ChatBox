using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace FinalProject
{
    internal class FromServer
    {
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6969);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public void StartServer()
        {
            server.Bind(ipep);
            server.Listen(10); //10 Connection
            Console.WriteLine("waiting to connect...");
            Socket client = server.Accept();
            Console.WriteLine("Accept Connect with: {0}", client.RemoteEndPoint.ToString());

            String s = "Welcome to server 6969: ";
            byte[] buffer = new byte[1024];
            buffer = Encoding.ASCII.GetBytes(s);
            client.Send(buffer, buffer.Length, SocketFlags.None);
            while(true)
            {
                byte[] datarecv = new byte[1024];
                int recv = client.Receive(datarecv);
                s = Encoding.ASCII.GetString(datarecv, 0, recv);
                Console.WriteLine("Client: {0}", s);

                if (s.ToUpper().Equals("EXIT")) break;
                s=s.ToUpper();
                buffer = Encoding .ASCII.GetBytes(s);
                client.Send(buffer, buffer.Length, SocketFlags.None);
            }
            client.Close();
            server.Close();
        }
    }
}
