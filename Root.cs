using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace EditorSnake
{
    public class Root
    {
        public List<Livello> livelli;

        public Root()
        {
            livelli = new List<Livello>();
        }
    }
}
