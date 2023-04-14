using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ingatlan
{
    class Program
    {
        struct ugyfel
        {
            public int azonosito;
            public string nev;
            public string tel;
        }
        struct ingatlan
        {
            public int azonosito;
            public string cim;
            public int alapter;
            public int ar;
        }
        static void Main(string[] args)
        {
            List<ingatlan> ingatlanok = new List<ingatlan>();
            string[] ingatlanokfajl = File.ReadAllLines("ingatlanok.txt");
            for (int i = 0; i < ingatlanokfajl.Length; i++)
            {
                ingatlan UjIngatlan = new ingatlan();
                UjIngatlan.azonosito = int.Parse(ingatlanokfajl[i].Split('\t')[0]);
                UjIngatlan.cim = ingatlanokfajl[i].Split('\t')[1];
                UjIngatlan.alapter = int.Parse(ingatlanokfajl[i].Split('\t')[2]);
                UjIngatlan.ar = int.Parse(ingatlanokfajl[i].Split('\t')[3]);
                ingatlanok.Add(UjIngatlan);
            }

            //ügyfelek beolvasása, és listához adása
            List<ugyfel> ugyfelek = new List<ugyfel>();
            string[] ugyfelekfajl = File.ReadAllLines("ugyfelek.txt");
            for (int i = 0; i < ugyfelekfajl.Length; i++)
            {
                ugyfel UjUgyfel = new ugyfel();
                UjUgyfel.azonosito = int.Parse(ugyfelekfajl[i].Split('\t')[0]);
                UjUgyfel.nev = ugyfelekfajl[i].Split('\t')[1];
                UjUgyfel.tel = ugyfelekfajl[i].Split('\t')[2];
                ugyfelek.Add(UjUgyfel);
            }

            string[] menupontok = { "Új ügyfél felvétele", "Új ingatlan felvétele", "Már eladott ingatlan törlése", "Ügyfelek kiíratása", "Ingatlanok kiíratása", "Kilépés" };
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menupontok.Length; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "]" + " " + menupontok[i]);
                }
                char valasz = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (valasz)
                {
                    case '1':
                        
                        break;
                    case '2':
                        Console.WriteLine("Ingatlanos");
                        break;
                    case '3':
                        Console.WriteLine("Eladott ingatlanos");
                        break;
                    case '4':
                        //Ügyféllista kiíratása
                        Console.WriteLine("AZON\tNév");
                        Console.SetCursorPosition(100, 0);
                        Console.WriteLine("Telefonszám");

                        for (int i = 0; i < ugyfelek.Count; i++)
                        {
                            Console.WriteLine("{0}\t{1}", ugyfelek[i].azonosito, ugyfelek[i].nev);
                            Console.SetCursorPosition(100, i + 1);
                            Console.WriteLine("{0}", ugyfelek[i].tel);
                        }

                        break;
                    case '5':
                        //Ingatlanok kiíratása
                        Console.WriteLine("AZON\tCím");
                        Console.SetCursorPosition(95, 0);
                        Console.WriteLine("Alapter.\tÁr");
                        for (int i = 0; i < ingatlanok.Count; i++)
                        {
                            Console.WriteLine("{0}\t{1}", ingatlanok[i].azonosito, ingatlanok[i].cim);
                            Console.SetCursorPosition(95, i + 1);
                            Console.WriteLine("{0}\t{1} Ft", ingatlanok[i].alapter, ingatlanok[i].ar);
                        }

                        break;
                    case '6':
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Ilyen menüpont nem létezik");
                        break;
                }
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("   Nyomj meg egy gombot, hogy visszatérj a menübe!  ");
                Console.WriteLine("----------------------------------------------------");
                Console.ReadKey();
            }
        }
    }
}