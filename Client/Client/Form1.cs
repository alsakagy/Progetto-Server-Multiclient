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

namespace Client
{
    public partial class Form1 : Form
    {
        // spostare tutta questa parte nel form di accesso/registrazione creando così il socket, poi passare il socket tramite il costruttore di questo form
        public static string data = "";
        public static IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        public static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);
        public static Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        public static byte[] bytes = new byte[1024];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartClient();
        }
        public static void StartClient()
        {
            try
            {
                try
                {
                    sender.Connect(remoteEP);
                    //sender.Shutdown(SocketShutdown.Both);
                    //sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Invia_Messaggio_Click(object sender, EventArgs e)
        {
            InviaMessaggio(Messaggio.Text);
            Messaggio.Text = string.Empty;
        }

        public static void InviaMessaggio(string messaggio)
        {
            try
            {
                try
                {
                    byte[] msg = Encoding.ASCII.GetBytes(messaggio + "$");
                    sender.Send(msg);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
