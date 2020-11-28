using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace EditorSnake
{
    class RootSingoloLivello
    {
        public RootSingoloLivello(Livello livello, string nomeFileLivello)
        {
            string serialized = JsonConvert.SerializeObject(livello);
            File.WriteAllText(@nomeFileLivello, serialized);
        }
    }
}
