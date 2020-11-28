using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorSnake
{
    public class Livello
    {
        public int numLev;
        public IList<Muro> posMuri;

        public Livello(int numLev)
        {
            posMuri = new List<Muro>();
            this.numLev = numLev;
        }
    }
}
