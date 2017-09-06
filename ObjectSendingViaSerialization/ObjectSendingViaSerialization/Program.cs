using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectSendingViaSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener Listner = null;
            try
            {
                Listner = new TcpListener(IPAddress.Any, 8080);
                Listner.Start();
                Console.WriteLine("Connection Started");
                while(true)
                {
                    Console.WriteLine("Waiting for  the Connection");
                    TcpClient client = Listner.AcceptTcpClient();
                    Console.WriteLine("New connection Started");
                    Thread thread = new Thread(ProcessClientRequests);
                    thread.Start(client);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if(Listner != null)
                {
                    Listner.Stop();
                }
            }
        }
        private static void ProcessClientRequests(object argument)
        {
            TcpClient client = (TcpClient)argument;
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
                string s = string.Empty;
                while(!(s = reader.ReadLine()).Equals("Exit") || s == null)
                {
                    if(s == "GetPersonList")
                    {
                        Console.WriteLine("Client" + s);
                        SerializePerson(client.GetStream());

                    }
                }
                reader.Close();
                writer.Close();
                client.Close();
                Console.WriteLine("Client Connection Closed");
            }
            catch(Exception e)
            {
                Console.WriteLine("Unknown Exception");
            }
            finally
            {
                if(client != null)
                {
                    client.Close();
                }
            }
        
        }

       private static void SerializePerson(NetworkStream stream)
        {
            PersonHolder personHolder = new PersonHolder();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, personHolder.GetPersonList());
        }
    }
    
}
