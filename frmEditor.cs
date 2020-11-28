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
        private Root root;
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
            root = new Root();
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
            //Debug

            /*
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
            */

            Livello livello = new Livello(root.livelli.Count);
            for (int j = 0; j < GetMatHeight(); j++)
            {
                for (int i  = 0; i < GetMatWidth(); i++)
                {
                    if (mat[i, j] == 1)
                    {
                        Muro muro = new Muro();
                        muro.X = i;
                        muro.Y = j;
                        livello.posMuri.Add(muro);
                    }
                }
            }

            string nomeNextLevel = "livello" + livello.numLev + ".json";
            //Console.WriteLine(nomeNextLevel); //Debug
            SalvaSuFile(livello, nomeNextLevel);

            root.livelli.Add(livello);

            //livello.numLev = int.Parse(System.IO.File.ReadAllText("numLev.txt")); //Usare qualcosa di simile per tenere conto del numero dei livelli crescente

            //Root root = new Root();
            //root.livelli.Add(livello);

            //string strSerializedForJson = JsonConvert.SerializeObject(livello);

            //Console.WriteLine(file);  //Debug


            //Per il momento il file viene scritto solo quando si chiude la form, bisogna trovare il modo di 1. aggiungere al file già esistente oppure 2. copiare tutto quello che c'è già, aggiungere e riscrivere

            /*
            try
            {
                File.AppendAllText(@"json1.json", strSerializedForJson);
            }
            catch (System.IO.FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message, "Errore", MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
            catch (System.IO.IOException fe)
            {
                Console.WriteLine(fe.Message, "Errore", MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
            */
        }

        private void SalvaSuFile(Livello level, string nomeFile)
        {
            string strSerializedForJson = JsonConvert.SerializeObject(level);

            try
            {
                File.AppendAllText(@nomeFile, strSerializedForJson);
            }
            catch (System.IO.FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message, "Errore", MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
            catch (System.IO.IOException fe)
            {
                 Console.WriteLine(fe.Message, "Errore", MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// imposta la larghezza dei due bottoni inferiori. metà schermo a ciascuno
        /// </summary>
        private void ResizeButtons()
        {
            btnTrasferello.Size = new Size(pnlGestioneBottoni.Size.Width / 3, pnlGestioneBottoni.Size.Height);
            btnSalva.Size = new Size(pnlGestioneBottoni.Size.Width / 3, pnlGestioneBottoni.Size.Height);
            btnReset.Size = new Size(pnlGestioneBottoni.Size.Width / 3, pnlGestioneBottoni.Size.Height);
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
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InizializzaMatriceCampo(GetMatWidth(), GetMatHeight());
                GeneraCampo(GetMatWidth(), GetMatHeight());
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {

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
