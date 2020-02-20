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
            this.components = new System.ComponentModel.Container();
            this.ringPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAmbiente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTrasmetti = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spegniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accendiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHum = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ringPanel
            // 
            this.ringPanel.Location = new System.Drawing.Point(578, 170);
            this.ringPanel.Name = "ringPanel";
            this.ringPanel.Size = new System.Drawing.Size(5, 5);
            this.ringPanel.TabIndex = 0;
            this.ringPanel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnAmbiente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnTrasmetti);
            this.panel1.Controls.Add(this.txtConsole);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 463);
            this.panel1.TabIndex = 1;
            // 
            // btnAmbiente
            // 
            this.btnAmbiente.BackColor = System.Drawing.Color.Coral;
            this.btnAmbiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmbiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmbiente.Location = new System.Drawing.Point(195, 330);
            this.btnAmbiente.Name = "btnAmbiente";
            this.btnAmbiente.Size = new System.Drawing.Size(126, 29);
            this.btnAmbiente.TabIndex = 3;
            this.btnAmbiente.Text = "Dati Ambiente";
            this.btnAmbiente.UseVisualStyleBackColor = false;
            this.btnAmbiente.Click += new System.EventHandler(this.BtnAmbiente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "ESP8266 WebSocket";
            // 
            // btnTrasmetti
            // 
            this.btnTrasmetti.BackColor = System.Drawing.Color.Coral;
            this.btnTrasmetti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrasmetti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrasmetti.Location = new System.Drawing.Point(12, 330);
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
            this.txtConsole.Location = new System.Drawing.Point(12, 62);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(374, 250);
            this.txtConsole.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ledToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            // 
            // ledToolStripMenuItem
            // 
            this.ledToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spegniToolStripMenuItem,
            this.accendiToolStripMenuItem});
            this.ledToolStripMenuItem.Name = "ledToolStripMenuItem";
            this.ledToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.ledToolStripMenuItem.Text = "Led";
            // 
            // spegniToolStripMenuItem
            // 
            this.spegniToolStripMenuItem.Name = "spegniToolStripMenuItem";
            this.spegniToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.spegniToolStripMenuItem.Text = "Spegni";
            // 
            // accendiToolStripMenuItem
            // 
            this.accendiToolStripMenuItem.Name = "accendiToolStripMenuItem";
            this.accendiToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.accendiToolStripMenuItem.Text = "Accendi";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblHum);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblTemp);
            this.panel2.Location = new System.Drawing.Point(803, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 371);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monofonto", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(110, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Temperatura";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Monofonto", 71.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTemp.Location = new System.Drawing.Point(63, 79);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(294, 115);
            this.lblTemp.TabIndex = 0;
            this.lblTemp.Text = "00.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monofonto", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(142, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "Umidità";
            // 
            // lblHum
            // 
            this.lblHum.AutoSize = true;
            this.lblHum.Font = new System.Drawing.Font("Monofonto", 71.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHum.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHum.Location = new System.Drawing.Point(63, 229);
            this.lblHum.Name = "lblHum";
            this.lblHum.Size = new System.Drawing.Size(294, 115);
            this.lblHum.TabIndex = 2;
            this.lblHum.Text = "00.00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1204, 371);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ringPanel);
            this.Name = "Form1";
            this.Text = "ESP8266 WebSocket";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ringPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnTrasmetti;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spegniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accendiToolStripMenuItem;
        private System.Windows.Forms.Button btnAmbiente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHum;
    }
}

