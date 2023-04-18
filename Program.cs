using System;

namespace covid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Infile inf = new Infile("inp.txt");
            string mikor = "";
            bool l = false;
            int max = 0;
            while(inf.ReadCovid(out Nap nap))
            {
                l = l || nap.új > 5000;
                int s = össz(nap.lista);
                if (s > max)
                {
                    max = s;
                    mikor = nap.dátum;
                }
            }
            if(l)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            Console.WriteLine(mikor);

        }
        static int össz(List<Nap.Kórház> nap)
        {
            int s = 0;
            for (int i = 0; i < nap.Count; i++)
            {
                s += nap[i].beteg;
            }
            return s;
        }
    }
}
