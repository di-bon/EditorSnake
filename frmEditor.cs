using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;

namespace EditorSnake
{
    public partial class frmEditor : Form
    {
        //25, 17 è la dimensione del campo medio, in caso si può fare un menu per fare l'editor anche del campo piccolo e di quello grande
        private int[,] mat = new int[25, 17];
        private int sizeButton = 64;
        public frmEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// load dell'editor. viene inizializzata la matrice e stampati i bottoni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditor_Load(object sender, EventArgs e)
        {
            InizializzaMatriceCampo(GetMatWidth(), GetMatHeight());
            GeneraCampo(GetMatWidth(), GetMatHeight());
            ResizeButtons();
        }

        /// <summary>
        /// inizializzazione del campo gioco. 0 = libero, 1 = muro
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
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

        /// <summary>
        /// viene cancellato tutto il contenuto del pannello che contiene il campo gioco, successivamente vengono generati i bottoni corrispondenti ad ogni cella della matrice
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void GeneraCampo(int width, int height)
        {
            DrawingControl.SuspendDrawing(pnlCampoGioco);
            pnlCampoGioco.Controls.Clear();
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
                    pnlCampoGioco.Controls.Add(b);
                }
            }
            DrawingControl.ResumeDrawing(pnlCampoGioco);
        }

        /// <summary>
        /// ritorna la larghezza della matrice (x)
        /// </summary>
        /// <returns></returns>
        private int GetMatWidth()
        {
            return mat.GetLength(0);
        }

        /// <summary>
        /// ritorna l'altezza della matrice (y)
        /// </summary>
        /// <returns></returns>
        private int GetMatHeight()
        {
            return mat.GetLength(1);
        }

        /// <summary>
        /// scrive nel file json. per debug stampa la matrice con Console.Write()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            List<Muro> lstMuro = new List<Muro>();
            for (int j = 0; j < GetMatHeight(); j++)
            {
                for (int i  = 0; i < GetMatWidth(); i++)
                {
                    if (mat[i, j] == 1)
                    {
                        Muro muro = new Muro();
                        muro.X = i;
                        muro.Y = j;
                        lstMuro.Add(muro);
                    }
                }
            }
            string file = JsonConvert.SerializeObject(lstMuro);
            Console.WriteLine(file);
            try
            {
                File.Open("json1.json", FileMode.Open);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("File di salvataggio non trovato :/", "Errore durante il salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("MA che???", "???", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                File.WriteAllText("json1.json", file);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("bla bla bla");
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("Che razza di errore è questo??");
            }
        }

        /// <summary>
        /// imposta la larghezza dei due bottoni inferiori. metà schermo a ciascuno
        /// </summary>
        private void ResizeButtons()
        {
            btnTrasferello.Size = new Size(pnlGestioneBottoni.Size.Width / 2, pnlGestioneBottoni.Size.Height);
            btnReset.Size = new Size(pnlGestioneBottoni.Size.Width / 2, pnlGestioneBottoni.Size.Height);
        }

        /// <summary>
        /// viene aggiornata la larghezza dei bottoni inferiori se viene modificata la grandezza della finestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditor_SizeChanged(object sender, EventArgs e)
        {
            ResizeButtons();
        }

        /// <summary>
        /// resetta tutta la matrice a 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vuoi davvero ripristinare tutto il campo gioco? Le modifiche non salvate andranno perdute",
                "Conferma",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                InizializzaMatriceCampo(GetMatWidth(), GetMatHeight());
                GeneraCampo(GetMatWidth(), GetMatHeight());
            }
        }
    }

    /// <summary>
    /// classe per evitare lo sfarfallio durante il disegno
    /// </summary>
    class DrawingControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }
}
