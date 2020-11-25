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
}
