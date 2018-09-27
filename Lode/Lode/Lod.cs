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
        private int pocetzasahu = 0;
        private bool potopena = false;

        public void NastavitPozici(int x, int y)
        {
            pozicex.Add(x);
            pozicey.Add(y);
            pocetbodu++;
        }
        public void Zasah(int hrac)
        {
            if (hrac == 1)
            {
                Program.Lode = Program.LodeH1;
                Program.Body = Program.BodyH1;
            }
            if (hrac == 2)
            {
                Program.Lode = Program.LodeH2;
                Program.Body = Program.BodyH2;
            }

            pocetzasahu++;
            if (pocetzasahu == pocetbodu)
            {
                potopena = true;
                for (int i = 0; i < pocetbodu; i++)
                {
                    Program.Body[pozicey[i]][pozicex[i]].Stav = 5;
                }
            }
        }
        public bool Kontrola()
        {
            return potopena;
        }
    }
}
