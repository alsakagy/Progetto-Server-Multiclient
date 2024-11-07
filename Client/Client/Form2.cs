using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Scelta_Accesso_Click(object sender, EventArgs e)
        {
            Richiesta_Iniziale.Visible = false;
            Dati_Accesso.Visible = true;
            Accesso.Visible = true;
            Indietro.Visible = true;
        }

        private void Scelta_Registrazione_Click(object sender, EventArgs e)
        {
            Richiesta_Iniziale.Visible = false;
            Dati_Accesso.Visible = true;
            Registrazione.Visible = true;
            Info_Password.Visible = true;
            Indietro.Visible = true;
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            Richiesta_Iniziale.Visible = true;
            Dati_Accesso.Visible = false;
            Registrazione.Visible = false;
            Accesso.Visible = false;
            Info_Password.Visible = false;
            Indietro.Visible = false;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if(Password.Text != string.Empty)
            {
                Vedi_Password.Enabled = true;
            }
            else
            {
                Vedi_Password.Enabled = false;
            }
        }

        private void Vedi_Password_Click(object sender, EventArgs e)
        {
            if(Vedi_Password.Image == Properties.Resources.Password_Visibile)
            {
                Vedi_Password.Image = Properties.Resources.Password_Nascosta;
                Vedi_Password.Refresh();
                Password.PasswordChar = '\0';
            }
            else if(Vedi_Password.Image == Properties.Resources.Password_Nascosta)
            {
                Vedi_Password.Image = Properties.Resources.Password_Visibile;
                Vedi_Password.Refresh();
                Password.PasswordChar = '*';
            }
        }
    }
}
