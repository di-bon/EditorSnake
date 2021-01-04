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
        private int[,] mat;
        private int width, height, sizeButton;
        private frmMenuEditor nomeChiamante;
        private RootNomiFile rootNomiFile;
        private Point posHead;
        public frmEditor(int width, int height, int sizeButton, frmMenuEditor nomeChiamante)
        {
            InitializeComponent();
            this.width = width;
            this.height = height;
            this.sizeButton = sizeButton;
            this.nomeChiamante = nomeChiamante;
        }

        /// <summary>
        /// load dell'editor. viene inizializzata la matrice e stampati i bottoni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEditor_Load(object sender, EventArgs e)
        {
            mat = new int[width, height];
            InizializzaMatriceCampo(GetMatWidth(), GetMatHeight());
            GeneraCampo(GetMatWidth(), GetMatHeight());
            ResizeForm();
            ResizeButtons();
            rootNomiFile = new RootNomiFile();
            try
            {
                if (!Directory.Exists("levels"))
                    Directory.CreateDirectory("levels");
                StreamReader reader = new StreamReader("levels/indice_livelli.json");
                rootNomiFile = JsonConvert.DeserializeObject<RootNomiFile>(reader.ReadToEnd());
                reader.Close();
            }
            catch (System.IO.FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch   (System.IO.IOException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (System.StackOverflowException fe)
            {
                Console.WriteLine(fe.Message);
            }
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
                        else if (mat[x, y] == 1)
                        {
                            mat[x, y] = 2;
                            b.BackColor = Color.Orange;
                            posHead = new Point(x, y);
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
            DimensioneCampo dimensioneCampoEditor;
            switch (width)
            {
                case 17:
                    dimensioneCampoEditor = DimensioneCampo.Piccolo;
                    break;
                case 25:
                    dimensioneCampoEditor = DimensioneCampo.Medio;
                    break;
                case 37:
                    dimensioneCampoEditor = DimensioneCampo.Grande;
                    break;
                default:
                    goto case 25;
            }
            Livello livello = new Livello(rootNomiFile.nomeFileDaLeggere.Count, dimensioneCampoEditor, posHead);
            for (int i = 0; i < GetMatWidth(); i++)
            {
                for (int j = 0; j < GetMatHeight(); j++)
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
            int errorMessageLevel = SalvaSuFile(livello, nomeNextLevel);
            switch (errorMessageLevel)
            {
                case 0:
                    MessageBox.Show("Livello salvato correttamente", "Livello salvato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    MessageBox.Show("Impossibile trovate il percorso per il salvataggio del file", "Errore durante il salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("Errore ignoto durante il salvataggio del livello", "Errore durante il salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            rootNomiFile.nomeFileDaLeggere.Add(nomeNextLevel);
            int errorMessageIndice = rootNomiFile.SalvaFileNomiLivelli();
            switch (errorMessageIndice)
            {
                case 0:
                    break;
                case 1:
                    MessageBox.Show("Impossibile trovate il percorso per il salvataggio del file di gestione dei livelli", "Errore durante il salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("Errore ignoto durante l'aggiornamento del file degli indici dei livelli", "Errore durante il salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

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

        /// <summary>
        /// salva il file di livello all'interno della cartella "levels". Ritorna 0 se l'operazione viene completata, altrimenti si è verificato un errore
        /// </summary>
        /// <param name="level"></param>
        /// <param name="nomeFile"></param>
        /// <returns></returns>
        private int SalvaSuFile(Livello level, string nomeFile)
        {
            string strSerializedForJson = JsonConvert.SerializeObject(level);
            string path = "levels/" + nomeFile;
            try
            {
                File.AppendAllText(@path, strSerializedForJson);
                return 0;
            }
            catch (System.IO.FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message, "Errore", MessageBoxIcon.Error, MessageBoxButtons.OK);
                return 1;
            }
            catch (System.IO.IOException fe)
            {
                Console.WriteLine(fe.Message, "Errore", MessageBoxIcon.Error, MessageBoxButtons.OK);
                return 2;
            }
        }

        private void ResizeForm()
        {
            this.Size = new Size(width * sizeButton + 20, height * sizeButton + btnTrasferello.Size.Height + 65);
        }

        /// <summary>
        /// imposta la larghezza dei due bottoni inferiori. metà schermo a ciascuno
        /// </summary>
        private void ResizeButtons()
        {
            btnTrasferello.Size = new Size(pnlGestioneBottoni.Size.Width / 2, pnlGestioneBottoni.Size.Height);
            btnReset.Size = new Size(pnlGestioneBottoni.Size.Width / 2, pnlGestioneBottoni.Size.Height);
        }

        private void frmEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            nomeChiamante.Show();
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
