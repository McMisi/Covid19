using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace covid
{
    public class Nap 
    {
        public string dátum { get; set; }
        public int új { get; set; }
        public List<Kórház> lista { get; set; }
        public Nap(string Dátum, int Új)
        {
            dátum = Dátum;
            új = Új;
            lista = new List<Kórház>();
        }
        public struct Kórház
        {
            public string név { get; set; }
            public int beteg { get; set; }
            public int gép { get; set; }
        }
    }
    internal class Infile
    {
        TextFileReader reader;
        public Infile(string input)
        {
            reader = new TextFileReader(input);
        }

        public bool ReadCovid(out Nap nap)
        {
            nap = null;
            bool l = reader.ReadLine(out string line);
            if (l)
            {
                string[] tokens = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                nap = new Nap(tokens[0], int.Parse(tokens[1]));
                for (int i = 2; i < tokens.Length; i = i + 3)
                {
                    nap.lista.Add(new Nap.Kórház()
                    {
                        név = tokens[i],
                        beteg = int.Parse(tokens[i+1]),
                        gép = int.Parse(tokens[i+2]),
                    });
                }
            }
            return l;
        }

    }
}
