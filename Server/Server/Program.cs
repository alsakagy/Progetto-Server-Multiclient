using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    internal class Program
    {
        //Lista di socket
        private static List<Socket> Clients = new List<Socket>();
        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }

        public static void StartListening()
        {
            //Crea l'oggetto che indica l'ip
            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            //Crea il socket (listener) tramite l'ip
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //Messaggio inutile
            Console.WriteLine("Timeout : {0}", listener.ReceiveTimeout);

            //Try-Catch per errori
            try
            {
                //Associa il listener al EndPoint
                listener.Bind(localEndPoint);
                //Possono collegarsi solo 10 client contemporaneamente
                listener.Listen(10);

                //Oggetto dedicato alla gestione complessiva dei clients collegati
                ClientsManager clientsThread = new ClientsManager(ref Clients);
                //Thread dell'oggetto che gestisci i client collegati (fa il broadcast)
                Thread tb = new Thread(new ThreadStart(clientsThread.broadcast));
                tb.Start();

                //ciclo infinito
                while (true)
                {

                    Console.WriteLine("Waiting for a connection...");
                    //Aspetta la connessione del clinet e l'accetta
                    Socket handler = listener.Accept();

                    //Oggetto che gestisce il client collegato
                    ClientManager clientThread = new ClientManager(handler);
                    //Thread dell'oggetto appena creato (fa il DoClient)
                    Thread t = new Thread(new ThreadStart(clientThread.doClient));
                    t.Start();

                }

            }
            catch (Exception e)
            {
                //Eccezione gestita
                Console.WriteLine(e.ToString());
            }

            //inutile
            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }
    }
    public class ClientsManager //Classe che gestisce i socket dei client connessi
    {
        //Lista passata per riferimento
        List<Socket> Clients = new List<Socket>();
        //Messaggio in byte
        byte[] bytes = new byte[1024];
        //Messaggio in string
        string data;

        //Costruttore che riceve la lista di socket
        public ClientsManager(ref List<Socket> clients)
        {
            this.Clients = clients;
        }

        //Invia a tutti i client un saluto + il loro IP/porta ogni 5 secondi
        public void broadcast()
        {
            while (true)
            {
                //Aspetta 5 secondi (5000 millisecondi)
                System.Threading.Thread.Sleep(5000);
                data = "";

                //Per ogni socket
                foreach (Socket socket in Clients)
                {
                    try
                    {
                        //Messaggio in string
                        data = "Ciao " + socket.RemoteEndPoint.ToString() + "\n";
                        //Messaggio trasformato in byte
                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        //Invio messaggio in byte
                        socket.Send(msg);
                        //Console.WriteLine(socket.RemoteEndPoint.ToString());
                    }
                    catch (Exception e)
                    {
                        //Eccezione gestita
                        Console.WriteLine("qlch client ha interrotto comunicazione" + e);
                    }
                }
            }
        }
    }
    public class ClientManager //Classe che gestisce il socket del singolo client
    {
        //Socket
        Socket clientSocket;
        //Messaggio in byte
        byte[] bytes = new byte[1024];
        //Messaggio in string
        string data = "";

        //Costruttore che riceve il socket
        public ClientManager(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
        }

        //Legge il messaggio del client e lo rinvia indietro
        public void doClient()
        {
            //Fino a che il messaggio non è la regola di protocollo che fa terminare la connessione
            while (data != "Quit$")
            {
                //Inutile
                Console.WriteLine("informazioni client : " + clientSocket.RemoteEndPoint);
                //Svuota data da messaggi precendeti
                data = "";
                //Fino a che non è arrivato al carattere terminatore del messaggio
                while (data.IndexOf("$") == -1) //Spiegazione --> data viene costruito dalla decodificazione del messaggio che arriva in byte, percio fino a che non viene scritto in data la lettera "$" il suo valore di IndexOf() sara -1 una volta trovato sarà diverso da -1 perciò il messaggio sarà finito
                {
                    //Riceve il messsaggio in byte dal client
                    int bytesRec = clientSocket.Receive(bytes);
                    //Trasforma il messaggio da byte a string
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                }

                //Stampa il messaggio ricevuto (inutile)
                Console.WriteLine("Messaggio ricevuto : {0}", data);
                string[] Dati = data.Split(' ');

                switch (Dati[0])
                {
                    case "REG":
                        // Non so come indicare la cartella resource come percorso in cui deve creare/leggere il file
                        File.AppendAllText("ElencoAccount.json", Dati[1]);
                        break;
                }
                //Codifica data in byte
                byte[] msg = Encoding.ASCII.GetBytes(data);
                //Manda il messaggio appena codificato al client
                clientSocket.Send(msg);
            }
            //Spegne la connessione
            clientSocket.Shutdown(SocketShutdown.Both);
            //Chiude il socket
            clientSocket.Close();
            //Svuota data
            data = "";
        }
    }

    class Account
    {
        private string nomeutente;
        private string password;

        public string NomeUtente
        {
            get { return nomeutente; }
            set { nomeutente = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Account(string nomeutente, string password)
        {
            if (nomeutente == string.Empty && password != string.Empty)
            {
                throw new ArgumentNullException(nomeutente, "Il campo nome utente non può essere vuoto");
            }

            if (password == string.Empty && nomeutente != string.Empty)
            {
                throw new ArgumentNullException(password, "Il campo password non può essere vuoto");
            }

            if (nomeutente == string.Empty && password == string.Empty)
            {
                throw new Exception("I campi nome utente e password non possono essere vuoti.");
            }

            this.nomeutente = nomeutente;
            this.password = password;
        }
    }
}
