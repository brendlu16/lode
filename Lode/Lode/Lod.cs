using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Lod
    {
        List<int> pozicex = new List<int>();
        List<int> pozicey = new List<int>();
        private int pocetbodu = 0;
        private bool potopena = false;

        public void NastavitPozici(int x, int y)
        {
            pozicex.Add(x);
            pozicey.Add(y);
            pocetbodu++;
        }
    }
}
