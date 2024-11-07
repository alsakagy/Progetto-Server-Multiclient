namespace Client
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Scelta_Accesso = new System.Windows.Forms.Button();
            this.Scelta_Registrazione = new System.Windows.Forms.Button();
            this.Accesso = new System.Windows.Forms.Button();
            this.Richiesta_Iniziale = new System.Windows.Forms.Panel();
            this.Nome_Utente = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Dati_Accesso = new System.Windows.Forms.Panel();
            this.Vedi_Password = new System.Windows.Forms.Button();
            this.Registrazione = new System.Windows.Forms.Button();
            this.Info_Password = new System.Windows.Forms.Label();
            this.Indietro = new System.Windows.Forms.Button();
            this.Richiesta_Iniziale.SuspendLayout();
            this.Dati_Accesso.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scelta_Accesso
            // 
            this.Scelta_Accesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scelta_Accesso.Location = new System.Drawing.Point(31, 18);
            this.Scelta_Accesso.Name = "Scelta_Accesso";
            this.Scelta_Accesso.Size = new System.Drawing.Size(173, 67);
            this.Scelta_Accesso.TabIndex = 1;
            this.Scelta_Accesso.Text = "Accedi";
            this.Scelta_Accesso.UseVisualStyleBackColor = true;
            this.Scelta_Accesso.Click += new System.EventHandler(this.Scelta_Accesso_Click);
            // 
            // Scelta_Registrazione
            // 
            this.Scelta_Registrazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scelta_Registrazione.Location = new System.Drawing.Point(208, 18);
            this.Scelta_Registrazione.Name = "Scelta_Registrazione";
            this.Scelta_Registrazione.Size = new System.Drawing.Size(173, 67);
            this.Scelta_Registrazione.TabIndex = 2;
            this.Scelta_Registrazione.Text = "Registrati";
            this.Scelta_Registrazione.UseVisualStyleBackColor = true;
            this.Scelta_Registrazione.Click += new System.EventHandler(this.Scelta_Registrazione_Click);
            // 
            // Accesso
            // 
            this.Accesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accesso.Location = new System.Drawing.Point(365, 392);
            this.Accesso.Name = "Accesso";
            this.Accesso.Size = new System.Drawing.Size(352, 67);
            this.Accesso.TabIndex = 3;
            this.Accesso.Text = "Accedi";
            this.Accesso.UseVisualStyleBackColor = true;
            this.Accesso.Visible = false;
            // 
            // Richiesta_Iniziale
            // 
            this.Richiesta_Iniziale.Controls.Add(this.Scelta_Registrazione);
            this.Richiesta_Iniziale.Controls.Add(this.Scelta_Accesso);
            this.Richiesta_Iniziale.Location = new System.Drawing.Point(335, 106);
            this.Richiesta_Iniziale.Name = "Richiesta_Iniziale";
            this.Richiesta_Iniziale.Size = new System.Drawing.Size(415, 98);
            this.Richiesta_Iniziale.TabIndex = 4;
            // 
            // Nome_Utente
            // 
            this.Nome_Utente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome_Utente.Location = new System.Drawing.Point(66, 45);
            this.Nome_Utente.Name = "Nome_Utente";
            this.Nome_Utente.Size = new System.Drawing.Size(281, 26);
            this.Nome_Utente.TabIndex = 5;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(66, 108);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(281, 26);
            this.Password.TabIndex = 6;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome Utente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(171, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // Dati_Accesso
            // 
            this.Dati_Accesso.Controls.Add(this.Vedi_Password);
            this.Dati_Accesso.Controls.Add(this.label3);
            this.Dati_Accesso.Controls.Add(this.label1);
            this.Dati_Accesso.Controls.Add(this.Password);
            this.Dati_Accesso.Controls.Add(this.Nome_Utente);
            this.Dati_Accesso.Location = new System.Drawing.Point(335, 217);
            this.Dati_Accesso.Name = "Dati_Accesso";
            this.Dati_Accesso.Size = new System.Drawing.Size(415, 146);
            this.Dati_Accesso.TabIndex = 9;
            this.Dati_Accesso.Visible = false;
            // 
            // Vedi_Password
            // 
            this.Vedi_Password.Enabled = false;
            this.Vedi_Password.Image = global::Client.Properties.Resources.Password_Visibile;
            this.Vedi_Password.Location = new System.Drawing.Point(351, 108);
            this.Vedi_Password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Vedi_Password.Name = "Vedi_Password";
            this.Vedi_Password.Size = new System.Drawing.Size(30, 26);
            this.Vedi_Password.TabIndex = 9;
            this.Vedi_Password.UseVisualStyleBackColor = true;
            this.Vedi_Password.Click += new System.EventHandler(this.Vedi_Password_Click);
            // 
            // Registrazione
            // 
            this.Registrazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registrazione.Location = new System.Drawing.Point(366, 392);
            this.Registrazione.Name = "Registrazione";
            this.Registrazione.Size = new System.Drawing.Size(352, 67);
            this.Registrazione.TabIndex = 10;
            this.Registrazione.Text = "Registrati";
            this.Registrazione.UseVisualStyleBackColor = true;
            this.Registrazione.Visible = false;
            // 
            // Info_Password
            // 
            this.Info_Password.AutoSize = true;
            this.Info_Password.Location = new System.Drawing.Point(481, 367);
            this.Info_Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Info_Password.Name = "Info_Password";
            this.Info_Password.Size = new System.Drawing.Size(123, 13);
            this.Info_Password.TabIndex = 11;
            this.Info_Password.Text = "Caratteristiche Password";
            this.Info_Password.Visible = false;
            // 
            // Indietro
            // 
            this.Indietro.Location = new System.Drawing.Point(496, 464);
            this.Indietro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(92, 35);
            this.Indietro.TabIndex = 12;
            this.Indietro.Text = "Torna Indietro";
            this.Indietro.UseVisualStyleBackColor = true;
            this.Indietro.Visible = false;
            this.Indietro.Click += new System.EventHandler(this.Indietro_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 639);
            this.Controls.Add(this.Indietro);
            this.Controls.Add(this.Info_Password);
            this.Controls.Add(this.Registrazione);
            this.Controls.Add(this.Dati_Accesso);
            this.Controls.Add(this.Richiesta_Iniziale);
            this.Controls.Add(this.Accesso);
            this.Name = "Form2";
            this.Text = "Accesso / Registrazione";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Richiesta_Iniziale.ResumeLayout(false);
            this.Dati_Accesso.ResumeLayout(false);
            this.Dati_Accesso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Scelta_Accesso;
        private System.Windows.Forms.Button Scelta_Registrazione;
        private System.Windows.Forms.Button Accesso;
        private System.Windows.Forms.Panel Richiesta_Iniziale;
        private System.Windows.Forms.TextBox Nome_Utente;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Dati_Accesso;
        private System.Windows.Forms.Button Registrazione;
        private System.Windows.Forms.Label Info_Password;
        private System.Windows.Forms.Button Indietro;
        private System.Windows.Forms.Button Vedi_Password;
    }
}