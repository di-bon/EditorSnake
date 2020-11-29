
namespace EditorSnake
{
    partial class frmMenuEditor
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
            this.lblSelezioneDimensione = new System.Windows.Forms.Label();
            this.cmbDimensioneCampo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.btnVai = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelezioneDimensione
            // 
            this.lblSelezioneDimensione.AutoSize = true;
            this.lblSelezioneDimensione.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelezioneDimensione.Location = new System.Drawing.Point(56, 145);
            this.lblSelezioneDimensione.Name = "lblSelezioneDimensione";
            this.lblSelezioneDimensione.Size = new System.Drawing.Size(272, 20);
            this.lblSelezioneDimensione.TabIndex = 0;
            this.lblSelezioneDimensione.Text = "Seleziona la dimensione del campo";
            // 
            // cmbDimensioneCampo
            // 
            this.cmbDimensioneCampo.FormattingEnabled = true;
            this.cmbDimensioneCampo.Location = new System.Drawing.Point(334, 145);
            this.cmbDimensioneCampo.Name = "cmbDimensioneCampo";
            this.cmbDimensioneCampo.Size = new System.Drawing.Size(253, 24);
            this.cmbDimensioneCampo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitolo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 77);
            this.panel1.TabIndex = 2;
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(0, 0);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(327, 67);
            this.lblTitolo.TabIndex = 3;
            this.lblTitolo.Text = "Editor livelli";
            // 
            // btnVai
            // 
            this.btnVai.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnVai.Location = new System.Drawing.Point(0, 252);
            this.btnVai.Name = "btnVai";
            this.btnVai.Size = new System.Drawing.Size(668, 104);
            this.btnVai.TabIndex = 3;
            this.btnVai.Text = "Vai";
            this.btnVai.UseVisualStyleBackColor = true;
            this.btnVai.Click += new System.EventHandler(this.btnVai_Click);
            // 
            // frmMenuEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 356);
            this.Controls.Add(this.btnVai);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbDimensioneCampo);
            this.Controls.Add(this.lblSelezioneDimensione);
            this.Name = "frmMenuEditor";
            this.Text = "frmMenuEditor";
            this.Load += new System.EventHandler(this.frmMenuEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelezioneDimensione;
        private System.Windows.Forms.ComboBox cmbDimensioneCampo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Button btnVai;
    }
}