using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace EditorSnake
{
    public class Muro
    {
        public int _x;
        public int _y;

        public Muro()
        {
            //serve davvero?
        }

        public int X
        {
            set { _x = value; }
            
        }
        public int Y
        {
            set { _y = value; }
        }
    }
    public class Livello
    {
        public int numLev;
        public IList<Muro> posMuri;

        public Livello()
        {
            //numLev = 
            posMuri = new List<Muro>();
        }
    }

    public class Root
    {
        public IList<Livello> livelli;

        public Root()
        {
            livelli = new List<Livello>();
        }
    }
}
