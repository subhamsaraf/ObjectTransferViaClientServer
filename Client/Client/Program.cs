using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string last = Console.ReadLine();
            Person person = new Person(first,last);

            var abc = JsonConvert.SerializeObject(person);
            string serverIP = "172.16.14.136";
            int serverport = 8080 ;
            TcpClient client = new TcpClient(serverIP, serverport);
            NetworkStream stream = client.GetStream();
            {
                byte[] stringByte = Encoding.ASCII.GetBytes(abc);
                stream.Write(stringByte, 0, stringByte.Length);
            }
        }
    }
}
