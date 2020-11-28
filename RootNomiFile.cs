using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace EditorSnake
{
    class RootNomiFile
    {
        public List<string> nomeFileDaLeggere;

        public RootNomiFile()
        {
            nomeFileDaLeggere = new List<string>();
            StreamReader reader = new StreamReader("nomi_livelli.json");
            JsonConvert.DeserializeObject<RootNomiFile>(reader.ReadToEnd());
            reader.Close();
        }

        public void SalvaFileNomiLivelli()
        {
            string classeSerialized = JsonConvert.SerializeObject(this);
            try
            {
                File.WriteAllText(@"nomi_livelli.json", classeSerialized);
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
