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
            this.Messaggio = new System.Windows.Forms.TextBox();
            this.Invia_Messaggio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Messaggio
            // 
            this.Messaggio.Location = new System.Drawing.Point(197, 44);
            this.Messaggio.Multiline = true;
            this.Messaggio.Name = "Messaggio";
            this.Messaggio.Size = new System.Drawing.Size(650, 343);
            this.Messaggio.TabIndex = 0;
            // 
            // Invia_Messaggio
            // 
            this.Invia_Messaggio.Location = new System.Drawing.Point(37, 44);
            this.Invia_Messaggio.Name = "Invia_Messaggio";
            this.Invia_Messaggio.Size = new System.Drawing.Size(125, 63);
            this.Invia_Messaggio.TabIndex = 1;
            this.Invia_Messaggio.Text = "Invia";
            this.Invia_Messaggio.UseVisualStyleBackColor = true;
            this.Invia_Messaggio.Click += new System.EventHandler(this.Invia_Messaggio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(70)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1212, 623);
            this.Controls.Add(this.Invia_Messaggio);
            this.Controls.Add(this.Messaggio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Scambio Messaggi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Messaggio;
        private System.Windows.Forms.Button Invia_Messaggio;
    }
}

