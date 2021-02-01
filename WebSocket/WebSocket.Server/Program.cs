using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebSocket.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 7000);

            serverSocket.Start();
            Console.WriteLine("Server started...");

            TcpClient clientSocket;
            NetworkStream stream;

            clientSocket = serverSocket.AcceptTcpClient();
            stream = clientSocket.GetStream();

            Console.WriteLine($"Connected: {clientSocket.Client.RemoteEndPoint}");

            while (true)
            {
                //read
                byte[] buff1 = new byte[1024];
                int len = stream.Read(buff1, 0, buff1.Length);
                string request = Encoding.UTF8.GetString(buff1, 0, len);

                if (request == "-1 close") break;

                Console.WriteLine("Request is:" + request);
            }

            clientSocket.Close();
            Console.WriteLine("client stoped...");

            serverSocket.Stop();
            Console.WriteLine("server stoped...");

            Console.ReadLine();
        }

        static async void acceptClients()
        {
            await Task.Run(() => {

            });
        }
    }
}
