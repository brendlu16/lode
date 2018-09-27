using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Kriznik
    {
        static List<int> pozicex = new List<int>();
        static List<int> pozicey = new List<int>();
        public static void Nastaveni()
        {
            pozicex.Add(-1);
            pozicex.Add(0);
            pozicex.Add(1);
            pozicex.Add(0);
            pozicey.Add(0);
            pozicey.Add(0);
            pozicey.Add(0);
            pozicey.Add(-1);
        }
        public static List<int> Pozice(string arg)
        {
            if (arg == "x")
            {
                return pozicex;
            }
            else
            {
                return pozicey;
            }
        }
    }
}
