using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class Form2 : Form
    {
        private bool Visualizza_Password = true;
        private byte[] Messaggio_Ricevuto = new byte[1024];
        private byte[] Messaggio_Invio;
        private string Data = "";
        private Socket_Account Socket_Account = new Socket_Account();

        public Form2()
        {
            InitializeComponent();
            InizializzaSocket_Account();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Scelta_Accesso_Click(object sender, EventArgs e)
        {
            Richiesta_Iniziale.Enabled = false;
            Dati_Accesso.Visible = true;
            Accesso.Visible = true;
            Indietro.Visible = true;
        }

        private void Scelta_Registrazione_Click(object sender, EventArgs e)
        {
            Richiesta_Iniziale.Enabled = false;
            Dati_Accesso.Visible = true;
            Registrazione.Visible = true;
            Info_Password.Visible = true;
            Indietro.Visible = true;
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            Richiesta_Iniziale.Enabled = true;
            Dati_Accesso.Visible = false;
            Registrazione.Visible = false;
            Accesso.Visible = false;
            Info_Password.Visible = false;
            Indietro.Visible = false;
        }

        private void Vedi_Password_Click(object sender, EventArgs e)
        {
            if(Visualizza_Password)
            {
                Vedi_Password.Image = Properties.Resources.Password_Nascosta;
                Vedi_Password.Refresh();
                Password.PasswordChar = '\0';
                Visualizza_Password = !Visualizza_Password;
            }
            else
            {
                Vedi_Password.Image = Properties.Resources.Password_Visibile;
                Vedi_Password.Refresh();
                Password.PasswordChar = '*';
                Visualizza_Password = !Visualizza_Password;
            }
        }

        private void Registrazione_Click(object sender, EventArgs e)
        {
            try
            {
                Account NewAccount = new Account(Nome_Utente.Text, Password.Text);
                RegistrazioneAccount(NewAccount);
            }
            catch(ArgumentNullException Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }

            string[] Dati = Ascolto_Server().Split(' ');

            switch(Dati[0])
            {
                case "OK":
                    Socket_Account.Account = JsonSerializer.Deserialize<Account>(Dati[1]);
                    Svuota_TextBox();
                    Cambio_Form();
                    break;
                case "NOK":
                    MessageBox.Show("La registrazione del nuovo account non è andata a buon fine.");
                    Svuota_TextBox();
                    break;
            }
        }

        private void Cambio_Form()
        {
            Form1 Form1 = new Form1(Socket_Account);
            this.Hide();
            Form1.ShowDialog();
        }

        private void Svuota_TextBox()
        {
            Nome_Utente.Text = string.Empty;
            Password.Text = string.Empty;
        }

        private string Ascolto_Server()
        {
            while (Data.IndexOf("$") == -1)
            {
                //Riceve il messsaggio in byte dal client
                int bytesRec = Socket_Account.Sender.Receive(Messaggio_Ricevuto);
                //Trasforma il messaggio da byte a string
                Data += Encoding.ASCII.GetString(Messaggio_Ricevuto, 0, bytesRec);
            }

            return Data;
        }

        private void Accesso_Click(object sender, EventArgs e)
        {
            try
            {
                Account NewAccount = new Account(Nome_Utente.Text, Password.Text);
                AccessoAccount(NewAccount);
            }
            catch (ArgumentNullException Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }

            string[] Dati = Ascolto_Server().Split(' ');

            switch (Dati[0])
            {
                case "OK":
                    Socket_Account.Account = JsonSerializer.Deserialize<Account>(Dati[1]);
                    Svuota_TextBox();
                    Cambio_Form();
                    break;
                case "NOK":
                    MessageBox.Show("Le credenziali sono sbagliate o inesistenti, riprova.");
                    Svuota_TextBox();
                    break;
            }
        }

        private void AccessoAccount(Account NewAccount)
        {
            try
            {
                string JsonString = JsonSerializer.Serialize(NewAccount);

                try
                {
                    Messaggio_Invio = Encoding.ASCII.GetBytes("ACC " + JsonString + " $");
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
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }
        }

        private void RegistrazioneAccount(Account NewAccount)
        {
            try
            {
                string JsonString = JsonSerializer.Serialize(NewAccount);

                try
                {
                    Messaggio_Invio = Encoding.ASCII.GetBytes("REG " + JsonString + " $");
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
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }
        }

        private void InizializzaSocket_Account()
        {
            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);
            Socket_Account.Sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Socket_Account.Sender.Connect(remoteEP);
            }
            catch (ArgumentNullException Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }
            catch (SocketException Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Errore: " + Ex.Message);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Messaggio_Invio = Encoding.ASCII.GetBytes("QUIT $");
            Socket_Account.Sender.Send(Messaggio_Invio);
        }
    }

    public class Socket_Account
    {
        private Socket sender;
        private Account account;

        public Socket Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        public Socket_Account()
        {

        }
    }

    public class Account
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
