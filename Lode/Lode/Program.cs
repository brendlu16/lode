using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bod> Body = new List<Bod>();
            for (int i = 0; i < 10; i++)
            {
                for (int i2 = 0; i2 < 10; i2++)
                { 
                    Body.Add(new Bod { Pozx = i, Pozy = i2 });
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Body[i].Vypsat();
            }

            /*Lod testlod = new Lod();
            for (int i = 0; i < 3; i++)
            {
                testlod.NastavitPozici(i + 5, 5);
            }*/
        }
    }
}
