using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class Form2 : Form
    {
        private bool Visualizza_Password = true;
        public Form2()
        {
            InitializeComponent();
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

        }
    }
}
