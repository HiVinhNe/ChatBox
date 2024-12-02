using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class FromClient
    {
        private TcpClient client = new TcpClient("192.168.100.102", 6969);
        public async Task<string> ThreadReadMesAsync()
        {
            string msg = null;
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                int recv = await stream.ReadAsync(buffer, 0, buffer.Length);  // Đọc bất đồng bộ
                if (recv > 0)
                {
                    msg = Encoding.ASCII.GetString(buffer, 0, recv);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return msg;
        }

        public void SendMes(string input)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes(input);
                stream.Write(buffer, 0, buffer.Length);
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
