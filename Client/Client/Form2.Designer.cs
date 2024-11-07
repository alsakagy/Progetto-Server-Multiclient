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
            this.Accesso = new System.Windows.Forms.Button();
            this.Registrazione = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Invio_Dati = new System.Windows.Forms.Button();
            this.Richiesta_Iniziale = new System.Windows.Forms.Panel();
            this.Richiesta_Iniziale.SuspendLayout();
            this.SuspendLayout();
            // 
            // Accesso
            // 
            this.Accesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accesso.Location = new System.Drawing.Point(30, 103);
            this.Accesso.Name = "Accesso";
            this.Accesso.Size = new System.Drawing.Size(173, 67);
            this.Accesso.TabIndex = 1;
            this.Accesso.Text = "Accedi";
            this.Accesso.UseVisualStyleBackColor = true;
            // 
            // Registrazione
            // 
            this.Registrazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registrazione.Location = new System.Drawing.Point(209, 103);
            this.Registrazione.Name = "Registrazione";
            this.Registrazione.Size = new System.Drawing.Size(173, 67);
            this.Registrazione.TabIndex = 2;
            this.Registrazione.Text = "Registrati";
            this.Registrazione.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Scegli l\'azione da fare";
            // 
            // Invio_Dati
            // 
            this.Invio_Dati.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Invio_Dati.Location = new System.Drawing.Point(440, 316);
            this.Invio_Dati.Name = "Invio_Dati";
            this.Invio_Dati.Size = new System.Drawing.Size(352, 67);
            this.Invio_Dati.TabIndex = 3;
            this.Invio_Dati.Text = "Invio";
            this.Invio_Dati.UseVisualStyleBackColor = true;
            this.Invio_Dati.Visible = false;
            // 
            // Richiesta_Iniziale
            // 
            this.Richiesta_Iniziale.Controls.Add(this.Registrazione);
            this.Richiesta_Iniziale.Controls.Add(this.Accesso);
            this.Richiesta_Iniziale.Controls.Add(this.label2);
            this.Richiesta_Iniziale.Location = new System.Drawing.Point(410, 102);
            this.Richiesta_Iniziale.Name = "Richiesta_Iniziale";
            this.Richiesta_Iniziale.Size = new System.Drawing.Size(416, 187);
            this.Richiesta_Iniziale.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1257, 670);
            this.Controls.Add(this.Richiesta_Iniziale);
            this.Controls.Add(this.Invio_Dati);
            this.Name = "Form2";
            this.Text = "Accesso / Registrazione";
            this.Richiesta_Iniziale.ResumeLayout(false);
            this.Richiesta_Iniziale.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Accesso;
        private System.Windows.Forms.Button Registrazione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Invio_Dati;
        private System.Windows.Forms.Panel Richiesta_Iniziale;
    }
}