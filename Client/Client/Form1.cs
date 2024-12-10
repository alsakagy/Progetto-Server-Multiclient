using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Principal;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Diagnostics;

namespace Client
{
    public partial class Form1 : Form
    {
        private static List<Contatto> Contatti = new List<Contatto>();
        private byte[] Messaggio_Invio;
        private byte[] Messaggio_Ricevuto = new byte[1024];
        private string Data = "";
        private static Socket_Account Socket_Account = new Socket_Account();

        public Form1(Socket_Account Socket)
        {
            Socket_Account = Socket;
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            Thread listeningThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        // Ricevi il messaggio dal server
                        int bytesRec = Socket_Account.Sender.Receive(Messaggio_Ricevuto);
                        string data = Encoding.ASCII.GetString(Messaggio_Ricevuto, 0, bytesRec);

                        // Mostra il messaggio o aggiornalo nell'interfaccia
                        this.Invoke((MethodInvoker)delegate
                        {
                            Receive(data); // Puoi anche aggiornare un'etichetta o altro controllo
                        });
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show($"Errore di connessione: {ex.Message}");
                        break;
                    }
                }
            });

            listeningThread.IsBackground = true; // Assicura che il thread si chiuda quando il form si chiude
            listeningThread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Messaggio_Invio = Encoding.ASCII.GetBytes("QUIT $");
            Socket_Account.Sender.Send(Messaggio_Invio);
        }

        public void AggiornaContatti()
        {
            Lista_Contatti.Items.Clear();
            foreach (var contatto in Contatti)
            {
                Lista_Contatti.Items.Add(contatto.Nome_Utente);
            }
        }

        private void AggiornaMessaggi(Contatto Contatto)
        {
            Lista_Messaggi.Items.Clear();
            foreach (var messaggio in Contatto.Messaggi)
            {
                Lista_Messaggi.Items.Add(messaggio);
            }
        }

        private void Lista_Contatti_SelectedIndexChanged(object sender, EventArgs e)
        {
            AggiornaMessaggi(Contatti[Lista_Contatti.SelectedIndex]);
        }

        private void Aggiungi_Contatto_Click(object sender, EventArgs e)
        {
            Contatti.Add(new Contatto(Convert.ToInt32(ID_Contatto.Text), Nome_Utente_Contatto.Text));
            AggiornaContatti();

            ID_Contatto.Text = string.Empty;
            Nome_Utente_Contatto.Text = string.Empty;
        }

        private void Invia_Messaggio_Click(object sender, EventArgs e)
        {
            if(Messaggio.Text != string.Empty)
            {
                string Messaggio_Modificato = Messaggio.Text.Replace(' ', '\u001F');
                try
                {
                    Messaggio_Invio = Encoding.ASCII.GetBytes("MSG " + Socket_Account.Account.Id + " " + Contatti[Lista_Contatti.SelectedIndex].Nome_Utente + " " + Contatti[Lista_Contatti.SelectedIndex].ID + " " + Messaggio_Modificato + " $");
                    Socket_Account.Sender.Send(Messaggio_Invio);
                }
                catch (ArgumentNullException Ex)
                {
                    MessageBox.Show("Errore: " + Ex.Message);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Errore: " + Ex.Message);
                }

                Messaggio.Text = string.Empty;
            }
        }

        public void Receive(string a)
        {
                string[] Dati = a.Split(' ');

                switch (Dati[0])
                {
                    case "MSG":
                        int Index = Contatti.FindIndex(x => x.ID == Convert.ToInt32(Dati[1]) && x.Nome_Utente == Dati[2]);
                        if (Index != -1)
                        {
                            Contatti[Index].Messaggi.Add(Dati[2] + ":   " + Dati[4].Replace('\u001F', ' '));
                        }
                        else
                        {
                            Contatti.Add(new Contatto(Convert.ToInt32(Dati[1]), Dati[2]));
                            Contatti.Last().Messaggi.Add(Dati[2] + ":   " + Dati[4].Replace('\u001F', ' '));
                        }
                    AggiornaContatti();
                        break;
                    default:
                        break;
                }
        }
    }

    /*
    class MessageManager
    {
        private Form1 Form1;
        private List<Contatto> Contatti = new List<Contatto>();
        private Socket Socket;
        private byte[] Messaggio_Ricevuto = new byte[1024];
        public MessageManager(Socket Socket, ref List<Contatto> Contatti, Form1 Form1)
        {
            this.Form1 = Form1;
            this.Contatti = Contatti;
            this.Socket = Socket;
        }

        public void Receive()
        {
            while (true)
            {
                //Svuota data da messaggi precendeti
                string Data = "";
                //Fino a che non è arrivato al carattere terminatore del messaggio
                while (Data.IndexOf("$") == -1) //Spiegazione --> data viene costruito dalla decodificazione del messaggio che arriva in byte, percio fino a che non viene scritto in data la lettera "$" il suo valore di IndexOf() sara -1 una volta trovato sarà diverso da -1 perciò il messaggio sarà finito
                {
                    //Riceve il messsaggio in byte dal client
                    int bytesRec = Socket.Receive(Messaggio_Ricevuto);
                    //Trasforma il messaggio da byte a string
                    Data += Encoding.ASCII.GetString(Messaggio_Ricevuto, 0, bytesRec);
                }

                string[] Dati = Data.Split(' ');

                switch(Dati[0])
                {
                    case "MSG":
                        int Index = Contatti.FindIndex(x => x.ID == Convert.ToInt32(Dati[1]) && x.Nome_Utente == Dati[2]);
                        if (Index != -1)
                        {
                            Contatti[Index].Messaggi.Add(Dati[2] + ":   " + Dati[4].Replace('\u001F', ' '));
                        }
                        else
                        {
                            Contatti.Add(new Contatto(Convert.ToInt32(Dati[1]), Dati[2]));
                            Contatti.Last().Messaggi.Add(Dati[2] + ":   " + Dati[4].Replace('\u001F', ' '));
                        }

                        Form1.Invoke((Action)Form1.AggiornaContatti);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    */
    class Contatto
    {
        private int id;
        private string nome_utente;
        private List<string> messaggi = new List<string>();

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome_Utente
        {
            get { return nome_utente; }
            set { nome_utente = value; }
        }

        public List<string> Messaggi
        {
            get { return messaggi; }
            set { messaggi = value; }
        }

        public Contatto(int ID, string Nome_Utente)
        {
            id = ID;
            nome_utente= Nome_Utente;
        }
    }
}
