using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8080);
            server.Start();
            while (true)
            {
                Socket client = server.AcceptSocket();
                Byte[] stream = new byte[2048];
                client.Receive(stream);
                string message = Encoding.ASCII.GetString(stream);
                var abc = JsonConvert.DeserializeObject(message);
                Console.WriteLine(abc);
                client.Close();
                client.Dispose();
            }
        }
    }
}

