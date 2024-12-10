namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Lista_Messaggi = new System.Windows.Forms.ListBox();
            this.Lista_Contatti = new System.Windows.Forms.ListBox();
            this.Aggiungi_Contatto = new System.Windows.Forms.Button();
            this.ID_Contatto = new System.Windows.Forms.TextBox();
            this.Indicazioni_Aggiunta_Contatto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lista_Messaggi
            // 
            this.Lista_Messaggi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(60)))));
            this.Lista_Messaggi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lista_Messaggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lista_Messaggi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(221)))));
            this.Lista_Messaggi.FormattingEnabled = true;
            this.Lista_Messaggi.ItemHeight = 24;
            this.Lista_Messaggi.Location = new System.Drawing.Point(318, 22);
            this.Lista_Messaggi.Name = "Lista_Messaggi";
            this.Lista_Messaggi.Size = new System.Drawing.Size(868, 578);
            this.Lista_Messaggi.TabIndex = 0;
            // 
            // Lista_Contatti
            // 
            this.Lista_Contatti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(60)))));
            this.Lista_Contatti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lista_Contatti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lista_Contatti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(221)))));
            this.Lista_Contatti.FormattingEnabled = true;
            this.Lista_Contatti.ItemHeight = 24;
            this.Lista_Contatti.Location = new System.Drawing.Point(12, 22);
            this.Lista_Contatti.Name = "Lista_Contatti";
            this.Lista_Contatti.Size = new System.Drawing.Size(300, 458);
            this.Lista_Contatti.TabIndex = 1;
            // 
            // Aggiungi_Contatto
            // 
            this.Aggiungi_Contatto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(75)))));
            this.Aggiungi_Contatto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(49)))), ((int)(((byte)(44)))));
            this.Aggiungi_Contatto.FlatAppearance.BorderSize = 2;
            this.Aggiungi_Contatto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(75)))));
            this.Aggiungi_Contatto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(75)))));
            this.Aggiungi_Contatto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Aggiungi_Contatto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aggiungi_Contatto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(221)))));
            this.Aggiungi_Contatto.Location = new System.Drawing.Point(12, 545);
            this.Aggiungi_Contatto.Name = "Aggiungi_Contatto";
            this.Aggiungi_Contatto.Size = new System.Drawing.Size(300, 54);
            this.Aggiungi_Contatto.TabIndex = 2;
            this.Aggiungi_Contatto.Text = "Aggiungi Contatto";
            this.Aggiungi_Contatto.UseVisualStyleBackColor = false;
            // 
            // ID_Contatto
            // 
            this.ID_Contatto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(93)))), ((int)(((byte)(75)))));
            this.ID_Contatto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_Contatto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_Contatto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(221)))));
            this.ID_Contatto.Location = new System.Drawing.Point(12, 513);
            this.ID_Contatto.Name = "ID_Contatto";
            this.ID_Contatto.Size = new System.Drawing.Size(300, 26);
            this.ID_Contatto.TabIndex = 3;
            // 
            // Indicazioni_Aggiunta_Contatto
            // 
            this.Indicazioni_Aggiunta_Contatto.AutoSize = true;
            this.Indicazioni_Aggiunta_Contatto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Indicazioni_Aggiunta_Contatto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(221)))));
            this.Indicazioni_Aggiunta_Contatto.Location = new System.Drawing.Point(11, 490);
            this.Indicazioni_Aggiunta_Contatto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Indicazioni_Aggiunta_Contatto.Name = "Indicazioni_Aggiunta_Contatto";
            this.Indicazioni_Aggiunta_Contatto.Size = new System.Drawing.Size(158, 20);
            this.Indicazioni_Aggiunta_Contatto.TabIndex = 12;
            this.Indicazioni_Aggiunta_Contatto.Text = "Inserisci ID Contatto:";
            this.Indicazioni_Aggiunta_Contatto.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(70)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1212, 623);
            this.Controls.Add(this.Indicazioni_Aggiunta_Contatto);
            this.Controls.Add(this.ID_Contatto);
            this.Controls.Add(this.Aggiungi_Contatto);
            this.Controls.Add(this.Lista_Contatti);
            this.Controls.Add(this.Lista_Messaggi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Scambio Messaggi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lista_Messaggi;
        private System.Windows.Forms.ListBox Lista_Contatti;
        private System.Windows.Forms.Button Aggiungi_Contatto;
        private System.Windows.Forms.TextBox ID_Contatto;
        private System.Windows.Forms.Label Indicazioni_Aggiunta_Contatto;
    }
}

