using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Bod
    {
        public int Pozx { get; set; }
        public int Pozy { get; set; }
        public int Stav = 1; //1 = nic, 2 = lod, 3 = vystrel, 4 = zasah, 5 = potopena
        public bool JeLod = false;
        public void Vypsat()
        {
            if (Stav == 1)
            {
                Console.Write("°");
            }
            if (Stav == 2)
            {
                Console.Write("O");
            }
        }
    }
}
