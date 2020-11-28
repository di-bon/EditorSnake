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
        public IList<string> nomeFileDaLeggere;

        public RootNomiFile()
        {
            nomeFileDaLeggere = new List<string>();
            /*
            try
            {
                StreamReader reader = new StreamReader("indice_livelli.json");
                JsonConvert.DeserializeObject<RootNomiFile>(reader.ReadToEnd());
                reader.Close();
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.StackOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            */
        }

        /// <summary>
        /// salva i nomi dei livelli all'interno della cartella "levels"
        /// </summary>
        /// <returns></returns>
        public int SalvaFileNomiLivelli()
        {
            string classeSerialized = JsonConvert.SerializeObject(this);
            try
            {
                File.WriteAllText(@"levels/indice_livelli.json", classeSerialized);
                return 0;
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return 2;
            }
        }
    }
}
