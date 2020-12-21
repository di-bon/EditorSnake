using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EditorSnake
{
    public class Livello
    {
        public int numLev;
        public DimensioneCampo dimensioneCampo;
        public Point head;
        public IList<Muro> posMuri;

        public Livello(int numLev, DimensioneCampo dimensioneCampo, Point head)
        {
            posMuri = new List<Muro>();
            this.numLev = numLev;
            this.dimensioneCampo = dimensioneCampo;
            this.head = head;
        }
    }
}
