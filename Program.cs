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

            string[] menupontok = { "Új ügyfél felvétele", "Új ingatlan felvétele", "Már eladott ingatlan törlése", "Ügyfelek kiíratása", "Ingatlanok kiíratása", "Ajánlat kérése" ,"Kilépés" };
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
                        ugyfel UjUgyfel = new ugyfel();
                        UjUgyfel.azonosito = ugyfelek[ugyfelek.Count-1].azonosito + 1;
                        Console.WriteLine("Az új ügyfél azonosítója: {0}", UjUgyfel.azonosito);
                        Console.WriteLine("Adja meg az új ügyfél nevét!");
                        UjUgyfel.nev = Console.ReadLine(); ;
                        Console.WriteLine("Adja meg az új ügyfél telefonszámát! (+36 30 123 4567)");
                        UjUgyfel.tel = Console.ReadLine();
                        ugyfelek.Add(UjUgyfel);

                        StreamWriter ujugyfelekfajl = new StreamWriter("ugyfelek.txt");
                        for (int i = 0; i < ugyfelek.Count; i++)
                        {
                            ujugyfelekfajl.WriteLine("{0}\t{1}\t{2}", ugyfelek[i].azonosito, ugyfelek[i].nev, ugyfelek[i].tel);
                        }
                        ujugyfelekfajl.Close();
                        break;
                    case '2':
                        ingatlan  UjIngatlan = new ingatlan();
                        UjIngatlan.azonosito = ingatlanok[ingatlanok.Count-1].azonosito + 1;
                        Console.WriteLine("Az új ingatlan azonosítója: {0}", UjIngatlan.azonosito);
                        Console.WriteLine("Adja meg az új ingatlan címe!");
                        UjIngatlan.cim = Console.ReadLine();
                        Console.WriteLine("Adja meg az új ingatlan alapterületát! (mértékegység nélkül)");
                        UjIngatlan.alapter = int.Parse(Console.ReadLine());
                        Console.WriteLine("Adja meg az új ingatlan árát! (pénznem nélkül)");
                        UjIngatlan.ar = int.Parse(Console.ReadLine());
                        ingatlanok.Add(UjIngatlan);

                        StreamWriter ujingatlanokfajl = new StreamWriter("ingatlanok.txt");
                        for (int i = 0; i < ingatlanok.Count; i++)
                        {
                            ujingatlanokfajl.WriteLine("{0}\t{1}\t{2}\t{3}", ingatlanok[i].azonosito, ingatlanok[i].cim, ingatlanok[i].alapter, ingatlanok[i].ar);
                        }
                        ujingatlanokfajl.Close();
                        break;
                    case '3':
                        Console.WriteLine("Adja meg az eladott ingatlan azonosítóját!");
                        int torolniakart = int.Parse(Console.ReadLine());
                        bool letezik = false;
                        for (int i = 0; i < ingatlanok.Count; i++)
                        {
                            if(torolniakart == ingatlanok[i].azonosito)
                            {
                                letezik = true;
                                ingatlanok.Remove(ingatlanok[i]);
                                break;
                            }
                        }
                        if (letezik)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Sikeresen törölte a {0} azonosítójú ingatlant!",torolniakart);
                            StreamWriter ujingatlanokfajl2 = new StreamWriter("ingatlanok.txt");
                            for (int f = 0; f < ingatlanok.Count; f++)
                            {
                                ujingatlanokfajl2.WriteLine("{0}\t{1}\t{2}\t{3}", ingatlanok[f].azonosito, ingatlanok[f].cim, ingatlanok[f].alapter, ingatlanok[f].ar);
                            }
                            ujingatlanokfajl2.Close();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nem található {0} azonosítójú ingatlan!", torolniakart);
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '4':
                        //Ügyféllista kiíratása
                        int sor = 0;
                        int db = 5;
                        int kijelolt = 0;
                        bool kilepes = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("AZON\tNév");
                            Console.SetCursorPosition(100, 0);
                            Console.WriteLine("Telefonszám");
                            for (int i = sor; i < sor + db; i++)
                            {
                                if (i == kijelolt)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }
                                Console.WriteLine("{0}", ugyfelek[i].azonosito);
                                Console.SetCursorPosition(5,i+1-sor);
                                Console.WriteLine("{0}", ugyfelek[i].nev);
                                Console.SetCursorPosition(100, i+1-sor);
                                Console.WriteLine("{0}", ugyfelek[i].tel);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine("Esc: kilépés, ↑: fel, ↓: le");
                            ConsoleKey valasz2 = Console.ReadKey().Key;
                            switch (valasz2)
                            {
                                case ConsoleKey.UpArrow:
                                    if (kijelolt  >= 4 && sor != 0)
                                    {
                                        sor--;
                                    }
                                    if(kijelolt > 0)
                                    {
                                        kijelolt--;
                                    }
                                    break;
                                case ConsoleKey.DownArrow:
                                    if (kijelolt >= 4 && sor != ugyfelek.Count - db)
                                    {
                                        sor++;
                                        kijelolt++;
                                    }
                                    else if(kijelolt < 4)
                                    {
                                        kijelolt++;
                                    }
                                    break;
                                case ConsoleKey.Escape:
                                    kilepes = true;
                                    break;
                                default:
                                    break;
                            }


                        } while (!kilepes);

                        break;
                    case '5':
                        //Ingatlanok kiíratása
                        int sor2 = 0;
                        int db2 = 5;
                        int kijelolt2 = 0;
                        bool kilepes2 = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("AZON\tCím");
                            Console.SetCursorPosition(95, 0);
                            Console.WriteLine("Alapter.\tÁr");
                            for (int i = sor2; i < sor2 + db2; i++)
                            {
                                if (i == kijelolt2)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }

                                Console.WriteLine("{0}", ingatlanok[i].azonosito);
                                Console.SetCursorPosition(5, i + 1 - sor2);
                                Console.WriteLine("{0}", ingatlanok[i].cim);
                                Console.SetCursorPosition(95, i + 1 - sor2);
                                Console.WriteLine("{0} m2", ingatlanok[i].alapter);
                                Console.SetCursorPosition(104, i + 1 - sor2);
                                Console.WriteLine("{0} Ft", ingatlanok[i].ar);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine("Esc: kilépés, ↑: fel, ↓: le");
                            ConsoleKey valasz2 = Console.ReadKey().Key;
                            switch (valasz2)
                            {
                                case ConsoleKey.UpArrow:
                                    if (kijelolt2 >= 4 && sor2 != 0)
                                    {
                                        sor2--;
                                    }
                                    if (kijelolt2 > 0)
                                    {
                                        kijelolt2--;
                                    }
                                    break;
                                case ConsoleKey.DownArrow:
                                    if (kijelolt2 >= 4 && sor2 != ingatlanok.Count - db2)
                                    {
                                        sor2++;
                                        kijelolt2++;
                                    }
                                    else if (kijelolt2 < 4)
                                    {
                                        kijelolt2++;
                                    }
                                    break;
                                case ConsoleKey.Escape:
                                    kilepes2 = true;
                                    break;
                                default:
                                    break;
                            }


                        } while (!kilepes2);



                        break;
                    case '6':




                        break;
                    case '7':
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Ilyen menüpont nem létezik");
                        break;
                }
                Console.WriteLine("                                   ----------------------------------------------------");
                Console.WriteLine("                                        Nyomj meg egy gombot, hogy visszatérj a menübe!  ");
                Console.WriteLine("                                    ----------------------------------------------------");
                Console.ReadKey();
            }
        }
    }
}