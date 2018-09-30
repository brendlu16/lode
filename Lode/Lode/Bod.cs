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
        public bool JeOkoli = false;
        public bool Umisteni = false;
        public int CisloLode;
        public void Vypsat(bool enemy)
        {
            if (enemy && Stav == 2)
            {
                Stav = 1;
            }
            if (!enemy && Stav == 1 && JeLod)
            {
                Stav = 2;
            }
            if (Umisteni)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Umisteni = false;
            }
            if (Stav == 1)
            {
                
                Console.Write(" o");
            }
            if (Stav == 2)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("[]");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (Stav == 3)
            {
                Console.Write(" *");
            }
            if (Stav == 4)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("[]");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (Stav == 5)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" *");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (Pozx == Program.SirkaPole-1)
            {
                Console.WriteLine("");
            }
        }
        public void Vystrel(int hrac)
        {
            if (hrac == 2)
            {
                Program.Lode = Program.LodeH1;
                Program.Body = Program.BodyH1;
            }
            if (hrac == 1)
            {
                Program.Lode = Program.LodeH2;
                Program.Body = Program.BodyH2;
            }

            if (Stav == 2)
            {
                Stav = 4;
                Program.Lode[CisloLode].Zasah(hrac);
            }
            if (JeLod == false && Stav == 1)
            {
                Stav = 3;
            }
            if (JeLod && Stav == 1)
            {
                Stav = 4;
                Program.Lode[CisloLode].Zasah(hrac);
            }
        }
        public bool JeZasah ()
        {
            if (Stav == 4 || Stav == 5)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
