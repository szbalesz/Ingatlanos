using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ingatlan
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menupontok = { "Új ügyfél felvétele", "Új ingatlan felvétele", "Már eladott ingatlan törlése", "Meglévő adatok kiírása" , "Kilépés"};
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menupontok.Length; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "]" + " " + menupontok[i]);
                }
                char valasz = Console.ReadKey().KeyChar;
                int menupont = int.Parse(valasz.ToString());
                Console.Clear();
                switch (menupont)
                {
                    case 1:
                        Console.WriteLine("Ügyfeles");
                        break;
                    case 2:
                        Console.WriteLine("Ingatlanos");
                        break;
                    case 3:
                        Console.WriteLine("Eladott ingatlanos");
                        break;
                    case 4:
                        Console.WriteLine("Meglévő adatos");
                        break;
                    case 5:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Ilyen menüpont nem létezik");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
