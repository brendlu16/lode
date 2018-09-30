using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Program
    {
        public static List<Lod> Lode = new List<Lod>();
        public static List<List<Bod>> Body = new List<List<Bod>>();
        public static List<Lod> LodeH1 = new List<Lod>();
        public static List<List<Bod>> BodyH1 = new List<List<Bod>>();
        public static List<Lod> LodeH2 = new List<Lod>();
        public static List<List<Bod>> BodyH2 = new List<List<Bod>>();
        public static int SirkaPole = 16;
        public static int VyskaPole = 16;
        static void Main(string[] args)
        {
            InitPole();
            Hra();
        }
        public static void InitPole()
        {
            for (int i = 0; i < VyskaPole; i++)
            {
                List<Bod> Body2H1 = new List<Bod>();
                for (int i2 = 0; i2 < SirkaPole; i2++)
                {
                    Body2H1.Add(new Bod { Pozx = i2, Pozy = i });
                }
                BodyH1.Add(Body2H1);
            }
            for (int i = 0; i < VyskaPole; i++)
            {
                List<Bod> Body2H2 = new List<Bod>();
                for (int i2 = 0; i2 < SirkaPole; i2++)
                {
                    Body2H2.Add(new Bod { Pozx = i2, Pozy = i });
                }
                BodyH2.Add(Body2H2);
            }
        }
        public static void Hra()
        {
            Console.Clear();
            Console.WriteLine("Hráč 1 umisťuje své lodě");
            System.Threading.Thread.Sleep(2500);

            Umisteni(1, 1);
            Umisteni(1, 2);
            Umisteni(1, 3);
            Umisteni(1, 4);
            ZobrazeniLodi(2, false);
            System.Threading.Thread.Sleep(2000);

            Console.Clear();
            Console.WriteLine("Hráč 2 umisťuje své lodě");
            Console.WriteLine("Stiskni klávesu...");
            Console.ReadKey();

            Umisteni(2, 1);
            Umisteni(2, 2);
            Umisteni(2, 3);
            Umisteni(2, 4);
            ZobrazeniLodi(1, false);
            System.Threading.Thread.Sleep(2000);

            while (true)
            {
                if (KontrolaStavu(2))
                {
                    Console.Clear();
                    Console.WriteLine("Konec hry, vyhrál hráč číslo 2!");
                    System.Threading.Thread.Sleep(5000);
                    break;
                }
                Stridani(1);
                Strelba(1);
                if (KontrolaStavu(1))
                {
                    Console.Clear();
                    Console.WriteLine("Konec hry, vyhrál hráč číslo 1!");
                    System.Threading.Thread.Sleep(5000);
                    break;
                }
                Stridani(2);
                Strelba(2);
            }
        }
        public static void Umisteni(int hrac, int lod)
        {
            List<int> pozice1 = new List<int>();
            List<int> pozice2 = new List<int>();
            if (lod == 1)
            {
                Katamaran.Nastaveni();
                pozice1 = Katamaran.Pozice("x");
                pozice2 = Katamaran.Pozice("y");
            }
            if (lod == 2)
            {
                BitevniLod.Nastaveni();
                pozice1 = BitevniLod.Pozice("x");
                pozice2 = BitevniLod.Pozice("y");
            }
            if (lod == 3)
            {
                Kriznik.Nastaveni();
                pozice1 = Kriznik.Pozice("x");
                pozice2 = Kriznik.Pozice("y");
            }
            if (lod == 4)
            {
                LetadlovaLod.Nastaveni();
                pozice1 = LetadlovaLod.Pozice("x");
                pozice2 = LetadlovaLod.Pozice("y");
            }

            if (hrac == 1)
            {
                Lode = LodeH1;
                Body = BodyH1;
            }
            if (hrac == 2)
            {
                Lode = LodeH2;
                Body = BodyH2;
            }

            int kurzorx = 0;
            int kurzory = 0;
            int oldkurzorx = -5;
            int oldkurzory = -5;
            int rotace = 0;
            bool naraz = false;

            while (true)
            {
                List<int> pozicex = new List<int>();
                List<int> pozicey = new List<int>();

                naraz = false;

                for (int i = 0; i < pozice1.Count; i++)
                {
                    while (true)
                    {
                        if (i == 0)
                        {
                            for (int i2 = 0; i2 < VyskaPole; i2++)
                            {
                                for (int i3 = 0; i3 < SirkaPole; i3++)
                                {
                                    Body[i2][i3].Umisteni = false;
                                }
                            }
                        }
                        if (rotace == 0)
                        {
                            pozicex.Add(pozice1[i] + kurzorx);
                            pozicey.Add(pozice2[i] + kurzory);
                        }
                        if (rotace == 1)
                        {
                            pozicex.Add(0-(pozice2[i]) + kurzorx);
                            pozicey.Add(pozice1[i] + kurzory);
                        }
                        if (rotace == 2)
                        {
                            pozicex.Add((0-pozice1[i]) + kurzorx);
                            pozicey.Add((0-pozice2[i]) + kurzory);
                        }
                        if (rotace == 3)
                        {
                            pozicex.Add((pozice2[i]) + kurzorx);
                            pozicey.Add((0-pozice1[i]) + kurzory);
                        }
                        if (pozicey[i] < 0)
                        {
                            pozicex.Clear();
                            pozicey.Clear();
                            i = 0;
                            kurzory++;
                        }
                        else
                        {
                            if (pozicex[i] < 0)
                            {
                                pozicex.Clear();
                                pozicey.Clear();
                                i = 0;
                                kurzorx++;
                            }
                            else
                            {
                                if (pozicey[i] > (VyskaPole-1))
                                {
                                    pozicex.Clear();
                                    pozicey.Clear();
                                    i = 0;
                                    kurzory--;
                                }
                                else
                                {
                                    if (pozicex[i] > (SirkaPole-1))
                                    {
                                        pozicex.Clear();
                                        pozicey.Clear();
                                        i = 0;
                                        kurzorx--;
                                    }
                                    else
                                    {
                                        if (Body[pozicey[i]][pozicex[i]].JeOkoli)
                                        {
                                            naraz = true;
                                        }
                                        Program.Body[pozicey[i]][pozicex[i]].Umisteni = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }                        
                }

                oldkurzorx = kurzorx;
                oldkurzory = kurzory;

                Console.Clear();
                for (int i2 = 0; i2 < VyskaPole; i2++)
                {
                    for (int i3 = 0; i3 < SirkaPole; i3++)
                    {
                        if (kurzory == i2 && kurzorx == i3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Body[i2][i3].Vypsat(false);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Body[i2][i3].Vypsat(false);
                        }
                    }
                }
                if (naraz)
                {
                    Console.WriteLine("Loď nelze umístit, mezi loděmi musí být alespoň jedno volné pole");
                    Console.WriteLine("Hraje hráč číslo " + hrac);
                } else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Hraje hráč číslo " + hrac);
                }
                Console.WriteLine("Šipkami umísti loď, poté potvrď její pozici stiskem mezerníku");
                Console.WriteLine("Loď můžeš otáčet stiskem klávesy R");

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (kurzorx > 0)
                    {
                        kurzorx -= 1;
                    }
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (kurzory > 0)
                    {
                        kurzory -= 1;
                    }
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (kurzorx < (SirkaPole-1))
                    {
                        kurzorx += 1;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (kurzory < (VyskaPole-1))
                    {
                        kurzory += 1;
                    }
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    if (!naraz)
                    {
                        int Cislolode = Lode.Count;
                        Lode.Add(new Lod());
                        for (int i = 0; i < pozicex.Count; i++)
                        {
                            Lode[Cislolode].NastavitPozici(pozicex[i], pozicey[i]);
                            Body[pozicey[i]][pozicex[i]].Stav = 2;
                            Body[pozicey[i]][pozicex[i]].JeLod = true;
                            Body[pozicey[i]][pozicex[i]].JeOkoli = true;
                            Body[pozicey[i]][pozicex[i]].CisloLode = Cislolode;
                            
                            try
                            {
                                Body[pozicey[i] + 1][pozicex[i]].JeOkoli = true;
                                Body[pozicey[i]][pozicex[i] + 1].JeOkoli = true;
                                Body[pozicey[i] - 1][pozicex[i]].JeOkoli = true;
                                Body[pozicey[i]][pozicex[i] - 1].JeOkoli = true;
                                Body[pozicey[i] + 1][pozicex[i] + 1].JeOkoli = true;
                                Body[pozicey[i] - 1][pozicex[i] + 1].JeOkoli = true;
                                Body[pozicey[i] - 1][pozicex[i] - 1].JeOkoli = true;
                                Body[pozicey[i] + 1][pozicex[i] - 1].JeOkoli = true;
                            }
                            catch (Exception)
                            {

                            }
                        }
                        break;
                    }   
                }
                if (key.Key == ConsoleKey.R)
                {
                    if (rotace < 3)
                    {
                        rotace++;
                    } else
                    {
                        rotace = 0;
                    }
                }
            }
        }
        public static void Strelba(int hrac)
        {
            int kurzorx = 0;
            int kurzory = 0;

            bool konectahu = false;

            if (hrac == 1)
            {
                Lode = LodeH2;
                Body = BodyH2;
            }
            if (hrac == 2)
            {
                Lode = LodeH1;
                Body = BodyH1;
            }

            while (true)
            {
                Console.Clear();
                for (int i2 = 0; i2 < VyskaPole; i2++)
                {
                    for (int i3 = 0; i3 < SirkaPole; i3++)
                    {
                        if (kurzory == i2 && kurzorx == i3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Body[i2][i3].Vypsat(true);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Body[i2][i3].Vypsat(true);
                        }
                    }
                }
                if (konectahu)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Netrefil ses! Konec tahu");
                    System.Threading.Thread.Sleep(2000);
                    break;
                } else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Hraje hráč číslo " + hrac);
                    Console.WriteLine("Šipkami zamiř, poté vystřel stiskem mezerníku");
                    if (KontrolaStavu(hrac))
                    {
                        break;
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (kurzorx > 0)
                    {
                        kurzorx -= 1;
                    }
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (kurzory > 0)
                    {
                        kurzory -= 1;
                    }
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (kurzorx < SirkaPole - 1)
                    {
                        kurzorx += 1;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (kurzory < VyskaPole - 1)
                    {
                        kurzory += 1;
                    }
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Body[kurzory][kurzorx].Vystrel(hrac);
                    if (!Body[kurzory][kurzorx].JeZasah())
                    {
                        konectahu = true;
                    }
                }
            }
        }
        public static void Stridani(int hrac)
        {
            if (KontrolaStavu(hrac))
            {
                Console.WriteLine("Hráč " + hrac + " potopil všechny lodě hráče " + (3 - hrac) + " a zvítězil");
                Console.WriteLine("Stiskem klávesy ukončíš hru");
                Console.ReadKey();
            } else
            {
                Console.Clear();
                Console.WriteLine("Hraje hráč číslo " + hrac);
                System.Threading.Thread.Sleep(2500);
            }
        }
        public static void ZobrazeniLodi(int hrac, bool enemy)
        {
            if (hrac == 1)
            {
                Lode = LodeH2;
                Body = BodyH2;
            }
            if (hrac == 2)
            {
                Lode = LodeH1;
                Body = BodyH1;
            }
            Console.Clear();
            for (int i2 = 0; i2 < VyskaPole; i2++)
            {
                for (int i3 = 0; i3 < SirkaPole; i3++)
                {
                    Body[i2][i3].Vypsat(enemy);
                }
            }
        }
        public static bool KontrolaStavu(int hrac)
        {
            if (hrac == 2)
            {
                Lode = LodeH1;
                Body = BodyH1;
            }
            if (hrac == 1)
            {
                Lode = LodeH2;
                Body = BodyH2;
            }
            int pocetpotopenych = 0;
            for (int i = 0; i < Lode.Count; i++)
            {
                if (Lode[i].Kontrola())
                {
                    pocetpotopenych++;
                }
            }
            if (pocetpotopenych == Lode.Count)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
