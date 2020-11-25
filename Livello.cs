using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace EditorSnake
{
    public class Livello
    {
        public static int numLev;
    }
    public class Muro
    {
        public int x;
        public int y;

        public int X
        {
            set { x = value; }
        }
        public int Y
        {
            set { y = value; }
        }
    }
}
