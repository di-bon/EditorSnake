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
    public enum DimensioneCampo
    {
        Piccolo,
        Medio,
        Grande
    }

    public partial class frmMenuEditor : Form
    {
        private int width, height, sizeButton;
        public frmMenuEditor()
        {
            InitializeComponent();
        }

        private void frmMenuEditor_Load(object sender, EventArgs e)
        {
            cmbDimensioneCampo.Items.Add(DimensioneCampo.Piccolo + "17 x 13");
            cmbDimensioneCampo.Items.Add(DimensioneCampo.Medio + " 25 x 17");
            cmbDimensioneCampo.Items.Add(DimensioneCampo.Grande + " 37 x 25");
            cmbDimensioneCampo.SelectedIndex = 1;
        }

        private void btnVai_Click(object sender, EventArgs e)
        {
            switch (cmbDimensioneCampo.SelectedIndex)    
            {
                case 0:
                    width = 17;
                    height = 13;
                    sizeButton = 64;
                    break;
                case 1:
                    width = 25;
                    height = 17;
                    sizeButton = 56;
                    break;
                case 2:
                    width = 37;
                    height = 25;
                    sizeButton = 48;
                    break;
                default:
                    goto case 1;
            }
            frmEditor frmEditor = new frmEditor(width, height, sizeButton, this);
            frmEditor.Show();
            this.Hide();
        }
    }
}
