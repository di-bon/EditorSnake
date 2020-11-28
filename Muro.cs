using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
