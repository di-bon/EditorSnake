using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorSnake
{
    public partial class frmEditor : Form
    {
        //25, 17 è la dimensione del campo medio
        private int[,] mat = new int[25, 17];
        private int sizeButton = 64;
        public frmEditor()
        {
            InitializeComponent();
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            InizializzaMatriceCampo(GetMatWidth(), GetMatHeight());
            GeneraCampo(GetMatWidth(), GetMatHeight());
            ResizeButtons();
        }

        private void InizializzaMatriceCampo(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mat[i, j] = 0;
                }
            }
        }

        private void GeneraCampo(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int x = i;
                    int y = j;
                    Button b = new Button();
                    b.Enabled = true;
                    b.Visible = true;
                    b.Location = new Point(i * sizeButton, j * sizeButton);
                    b.Size = new Size(sizeButton, sizeButton);
                    b.Text = i.ToString() + " " + j.ToString();
                    b.BackColor = Color.Black;
                    b.Click += delegate {
                        if (mat[x, y] == 0)
                        {
                            mat[x, y] = 1;
                            b.BackColor = Color.White;
                        }
                        else
                        {
                            mat[x, y] = 0;
                            b.BackColor = Color.Black;
                        }
                    };
                    this.Controls.Add(b);
                }
            }
        }

        private int GetMatWidth()
        {
            return mat.GetLength(0);
        }

        private int GetMatHeight()
        {
            return mat.GetLength(1);
        }

        private void btnTrasferello_Click(object sender, EventArgs e)
        {
            Console.Write("\n");
            for (int i = 0; i < GetMatWidth(); i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");

            for (int j = 0; j < GetMatHeight(); j++)
            {
                for (int i = 0; i < GetMatWidth(); i++)
                {
                    Console.Write(mat[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        private void ResizeButtons()
        {
            btnTrasferello.Size = new Size(pnlGestioneBottoni.Size.Width / 2, pnlGestioneBottoni.Size.Height);
            btnReset.Size = new Size(pnlGestioneBottoni.Size.Width / 2, pnlGestioneBottoni.Size.Height);
        }

        private void RipristinaCampo()
        {
            for (int i = 0; i < GetMatWidth(); i++)
            {
                for (int j = 0; j < GetMatHeight(); j++)
                {
                    if (mat[i, j] != 0)
                    {
                        
                    }
                }
            }
        }

        private void frmEditor_SizeChanged(object sender, EventArgs e)
        {
            ResizeButtons();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vuoi davvero ripristinare tutto il campo gioco? Le modifiche non salvate andranno perdute",
                "Conferma",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                /*
                InizializzaMatriceCampo(GetMatWidth(), GetMatHeight());
                GeneraCampo(GetMatWidth(), GetMatHeight());
                */

                RipristinaCampo();
            }
        }
    }
}
