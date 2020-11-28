using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace EditorSnake
{
    //su form_load bisogna deserializzare la classe root ed in segiuto alla chiusura bisogna serializzarla per mantenere corretti gli indici
    public class Root
    {
        public List<Livello> livelli;

        public Root()
        {
            livelli = new List<Livello>();
        }
    }
}
