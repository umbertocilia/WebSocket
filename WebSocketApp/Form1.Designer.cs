namespace WebSocketApp
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
            this.ringPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTrasmetti = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ringPanel
            // 
            this.ringPanel.Location = new System.Drawing.Point(586, 180);
            this.ringPanel.Name = "ringPanel";
            this.ringPanel.Size = new System.Drawing.Size(5, 5);
            this.ringPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnTrasmetti);
            this.panel1.Controls.Add(this.txtConsole);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 463);
            this.panel1.TabIndex = 1;
            // 
            // btnTrasmetti
            // 
            this.btnTrasmetti.BackColor = System.Drawing.Color.Coral;
            this.btnTrasmetti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrasmetti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrasmetti.Location = new System.Drawing.Point(12, 117);
            this.btnTrasmetti.Name = "btnTrasmetti";
            this.btnTrasmetti.Size = new System.Drawing.Size(177, 29);
            this.btnTrasmetti.TabIndex = 1;
            this.btnTrasmetti.Text = "Abilita trasmissione";
            this.btnTrasmetti.UseVisualStyleBackColor = false;
            this.btnTrasmetti.Click += new System.EventHandler(this.btnTrasmetti_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtConsole.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtConsole.Location = new System.Drawing.Point(12, 152);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(374, 297);
            this.txtConsole.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ringPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ringPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnTrasmetti;
    }
}

