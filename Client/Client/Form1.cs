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
        public static byte[] bytes = new byte[1024];
        private string Data = "";
        private static Socket_Account Socket_Account = new Socket_Account();

        public Form1(Socket_Account Socket)
        {
            Socket_Account = Socket;
            InitializeComponent();
        }
    }
}
