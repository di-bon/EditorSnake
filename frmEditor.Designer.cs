
namespace EditorSnake
{
    partial class frmEditor
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
            this.btnTrasferello = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlGestioneBottoni = new System.Windows.Forms.Panel();
            this.pnlCampoGioco = new System.Windows.Forms.Panel();
            this.pnlGestioneBottoni.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrasferello
            // 
            this.btnTrasferello.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTrasferello.Location = new System.Drawing.Point(0, 0);
            this.btnTrasferello.Name = "btnTrasferello";
            this.btnTrasferello.Size = new System.Drawing.Size(428, 169);
            this.btnTrasferello.TabIndex = 0;
            this.btnTrasferello.Text = "Trasferello";
            this.btnTrasferello.UseVisualStyleBackColor = true;
            this.btnTrasferello.Click += new System.EventHandler(this.btnTrasferello_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReset.Location = new System.Drawing.Point(914, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(491, 169);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlGestioneBottoni
            // 
            this.pnlGestioneBottoni.Controls.Add(this.btnReset);
            this.pnlGestioneBottoni.Controls.Add(this.btnTrasferello);
            this.pnlGestioneBottoni.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGestioneBottoni.Location = new System.Drawing.Point(0, 660);
            this.pnlGestioneBottoni.Name = "pnlGestioneBottoni";
            this.pnlGestioneBottoni.Size = new System.Drawing.Size(1405, 169);
            this.pnlGestioneBottoni.TabIndex = 2;
            // 
            // pnlCampoGioco
            // 
            this.pnlCampoGioco.AutoScroll = true;
            this.pnlCampoGioco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampoGioco.Location = new System.Drawing.Point(0, 0);
            this.pnlCampoGioco.Name = "pnlCampoGioco";
            this.pnlCampoGioco.Size = new System.Drawing.Size(1405, 660);
            this.pnlCampoGioco.TabIndex = 3;
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1405, 829);
            this.Controls.Add(this.pnlCampoGioco);
            this.Controls.Add(this.pnlGestioneBottoni);
            this.Name = "frmEditor";
            this.Text = "EditorSnake";
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.SizeChanged += new System.EventHandler(this.frmEditor_SizeChanged);
            this.pnlGestioneBottoni.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrasferello;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlGestioneBottoni;
        private System.Windows.Forms.Panel pnlCampoGioco;
    }
}

