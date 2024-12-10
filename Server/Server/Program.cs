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
using System.ComponentModel;
using System.Security.Principal;
using System.Globalization;

namespace Server
{
    internal class Program
    {
        //Ultimo ID
        private static int ID;
        //Lista di account registrati
        private static List<Account> AccountsRegistrati = new List<Account>();
        //Lista di Clienti
        private static List<Cliente> Clients = new List<Cliente>();
        //Variabile booleanea per while infinito
        public static int Main(String[] args)
        {
            CaricamentoAccount();
            CaricamentoUltimoID();
            StartListening();
            return 0;
        }

        public static void CaricamentoAccount()
        {
            string Path = "./../../Resources/ElencoAccount.json";
            string[] Righe = File.ReadAllLines(Path);
            foreach(string Riga in Righe)
            {
                AccountsRegistrati.Add(JsonSerializer.Deserialize<Account>(Riga));
            }
        }
        public static void CaricamentoUltimoID()
        {
            if(AccountsRegistrati.Count == 0)
            {
                ID = 0;
            }
            else
            {
                ID = AccountsRegistrati.Last().Id + 1;
            }
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

                //ciclo infinito
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    //Aspetta la connessione del client e l'accetta
                    Socket handler = listener.Accept();

                    //Oggetto che gestisce il client collegato
                    ClientManager clientThread = new ClientManager(handler, ref AccountsRegistrati, ref ID, ref Clients);
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

    class Cliente
    {
        Socket socket;
        Account account;

        public Socket Socket
        {
            get { return socket; }
            set { socket = value; }
        }

        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        public Cliente(Socket socket, Account account)
        {
            this.socket = socket;
            this.account = account;
        }
    }

    class ClientManager //Classe che gestisce il socket del singolo client
    {
        //Id da assegnare
        int Id;
        //Lista Account
        List<Account> AccountsRegistrati = new List<Account>();
        //Socket
        Socket ClientSocket;
        //Lista di Clienti (riferimento)
        List<Cliente> Clients = new List<Cliente>();
        //Messaggio in byte
        byte[] bytes = new byte[1024];
        //Messaggio in string
        string data = "";

        //Costruttore che riceve il socket
        public ClientManager(Socket ClientSocket, ref List<Account> Accounts, ref int Id, ref List<Cliente> Clients)
        {
            this.Clients = Clients;
            this.Id = Id;
            this.ClientSocket = ClientSocket;
            this.AccountsRegistrati = Accounts;
        }

        //Legge il messaggio del client e lo rinvia indietro
        public void doClient()
        {
            //Fino a che il messaggio non è la regola di protocollo che fa terminare la connessione
            while (data != "QUIT $")
            {
                //Inutile
                Console.WriteLine("informazioni client : " + ClientSocket.RemoteEndPoint);
                //Svuota data da messaggi precendeti
                data = "";
                //Fino a che non è arrivato al carattere terminatore del messaggio
                while (data.IndexOf("$") == -1) //Spiegazione --> data viene costruito dalla decodificazione del messaggio che arriva in byte, percio fino a che non viene scritto in data la lettera "$" il suo valore di IndexOf() sara -1 una volta trovato sarà diverso da -1 perciò il messaggio sarà finito
                {
                    //Riceve il messsaggio in byte dal client
                    int bytesRec = ClientSocket.Receive(bytes);
                    //Trasforma il messaggio da byte a string
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                }

                //Stampa il messaggio ricevuto (inutile)
                Console.WriteLine("Messaggio ricevuto : {0}", data);
                string[] Dati = data.Split(' ');

                switch (Dati[0])
                {
                    case "REG":
                        try
                        {
                            Account NewAccount = JsonSerializer.Deserialize<Account>(Dati[1]);
                            NewAccount.Id = Id;
                            Id++;
                            AccountsRegistrati.Add(NewAccount);
                            Clients.Add(new Cliente(ClientSocket, NewAccount));
                            try
                            {
                                string JsonString = JsonSerializer.Serialize(NewAccount);
                                string Path = "./../../Resources/ElencoAccount.json";
                                File.AppendAllText(Path, JsonString + "\n");
                                data = "OK " + JsonString + " $";
                            }
                            catch(JsonException Ex)
                            {
                                Console.WriteLine("Errore: " + Ex.Message);
                                data = "NOK $";
                            }
                            catch(Exception Ex)
                            {
                                Console.WriteLine("Errore: " + Ex.Message);
                                data = "NOK $";
                            }
                        }
                        catch (JsonException Ex)
                        {
                            Console.WriteLine("Errore: " + Ex.Message);
                            data = "NOK $";
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine("Errore: " + Ex.Message);
                            data = "NOK $";
                        }
                        break;
                    case "ACC":
                        try
                        {
                            Account NewAccount = JsonSerializer.Deserialize<Account>(Dati[1]);
                            int Index = AccountsRegistrati.FindIndex(x => x.NomeUtente == NewAccount.NomeUtente && x.Password == NewAccount.Password);

                            if(Index != -1)
                            {
                                NewAccount = AccountsRegistrati[Index];
                                Clients.Add(new Cliente(ClientSocket, NewAccount));
                                try
                                {
                                    string JsonString = JsonSerializer.Serialize(NewAccount);
                                    data = "OK " + JsonString + " $";
                                }
                                catch (JsonException Ex)
                                {
                                    Console.WriteLine("Errore: " + Ex.Message);
                                    data = "NOK $";
                                }
                                catch (Exception Ex)
                                {
                                    Console.WriteLine("Errore: " + Ex.Message);
                                    data = "NOK $";
                                }
                            }
                            else
                            {
                                Console.WriteLine("Credenziali sbagliate o inestistenti");
                                data = "NOK $";
                            }
                        }
                        catch (JsonException Ex)
                        {
                            Console.WriteLine("Errore: " + Ex.Message);
                            data = "NOK $";
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine("Errore: " + Ex.Message);
                            data = "NOK $";
                        }
                        break;
                    default:
                        break;
                }
                //Codifica data in byte
                byte[] msg = Encoding.ASCII.GetBytes(data);
                //Manda il messaggio appena codificato al client
                ClientSocket.Send(msg);
            }
            //Spegne la connessione
            ClientSocket.Shutdown(SocketShutdown.Both);
            //Chiude il socket
            ClientSocket.Close();
            //Rimozione dalla lista dei client attivi
            Clients.Remove(Clients.Find(x => x.Socket == ClientSocket));
            //Svuota data
            data = "";
        }
    }

    class Account
    {
        private string nomeutente;
        private string password;
        private int id;

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

        public int Id
        {
            get { return id; }
            set { id = value; }
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
