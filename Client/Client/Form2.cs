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
        private byte[] Messaggio;
        private Socket Sender;
        public Form2()
        {
            InitializeComponent();
            InizializzaSocket();
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
        }

        private void Accesso_Click(object sender, EventArgs e)
        {

        }

        private void AccessoAccount()
        {

        }

        private void RegistrazioneAccount(Account NewAccount)
        {
            try
            {
                string JsonString = JsonSerializer.Serialize(NewAccount);

                try
                {
                    Messaggio = Encoding.ASCII.GetBytes("REG " + JsonString + " $");
                    Sender.Send(Messaggio);
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

        private void InizializzaSocket()
        {
            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);
            Sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Sender.Connect(remoteEP);
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
