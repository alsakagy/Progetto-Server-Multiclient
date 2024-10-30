using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        public static string data = null;
        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }

        public static void StartListening()
        {
            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Timeout : {0}", listener.ReceiveTimeout);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = listener.Accept();

                    ClientManager clientThread = new ClientManager(handler);
                    Thread t = new Thread(new ThreadStart(clientThread.doClient));
                    t.Start();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }
    }
    public class ClientManager
    {

        Socket clientSocket;
        byte[] bytes = new Byte[1024];
        String data = "";

        public ClientManager(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
        }

        public void doClient()
        {

            while (data != "Quit$")
            {
                Console.WriteLine("informazioni client : " + clientSocket.RemoteEndPoint);
                data = "";
                while (data.IndexOf("$") == -1)
                {
                    int bytesRec = clientSocket.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                }

                Console.WriteLine("Messaggio ricevuto : {0}", data);

                byte[] msg = Encoding.ASCII.GetBytes(data);

                clientSocket.Send(msg);
            }
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            data = "";
        }
    }
}
