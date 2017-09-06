using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectSendingViaSerialization;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("");
            int port = 8080;
            try
            {
                if(args.Length >= 1)
                {
                    ip = IPAddress.Parse(args[0]);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid IP");

            }
            try
            {
                TcpClient client = new TcpClient(ip.ToString(), port);
                Console.WriteLine("Established");
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
                string s = string.Empty;
                while()
                {
                    Console.WriteLine("Enter \'GetPersonList\' to retrieve list from server");
                    s = Console.ReadLine();
                    Console.WriteLine();
                    if(s == "GetPersonList")
                    {
                        writer.WriteLine(s);
                        writer.Flush();
                        Write(Desrialize(client.GetStream()));
                        Console.WriteLine();
                    }
                    if(s == "Exit")
                    {
                        writer.WriteLine(s);
                        writer.Flush();
                    }
                    else
                    {
                        writer.WriteLine(s);
                        writer.Flush();
                        string serverString = reader.ReadLine();
                        Console.WriteLine(serverString);
                        Console.WriteLine();
                    }
                }
            }
        }
        static List<Person> Desrialize(NetworkStream stream )
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (List<Person>)formatter.Deserialize(stream);
        }
        static void Write(List<Person> personlist)
        {
            foreach(Person p in personlist)
            {
                Console.WriteLine(p);
            }
        }

    }
}
