using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Monolitycznie
{
    class Program
    {
        static void Main(string[] args)
        {
            Random los = new Random();
            int wylosowana = los.Next(1, 101);
#if DEBUG
            Console.WriteLine(wylosowana);
#endif
            Console.WriteLine("Wylosowalem liczbe z zakresu od 1 do 100. Odgadnij ja");

            Stopwatch czas = Stopwatch.StartNew();

            bool odgadniete = false;
            int licznik = 0;


            do
            {
                licznik++;


                Console.Write("Podaj swoja propozycje: ");

                string napis = Console.ReadLine();
                if (napis == "koniec")
                {
                    Console.WriteLine("Szkoda, ze mnie opuszczasz");
                    return;

                }
                int propozycja = 0;
                try
                {
                  propozycja = int.Parse(napis);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Nie podales liczby. \n Sprobuj jeszcze raz");

                    continue;
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Przesadziles. Za duza liczba");
                    continue;
                }
                catch(Exception)
                {
                    Console.WriteLine("Niezidentyfikowany wyjatek. Awaria");
                    Environment.Exit(1);
                }
                if (wylosowana > propozycja)
                {
                    Console.WriteLine("Za malo");
                }
                else if (wylosowana < propozycja)
                {
                    Console.WriteLine("Za duzo");
                }
                else
                {
                    Console.WriteLine("Trafiles");
                    odgadniete = true;

                }
            } while (!odgadniete);
            czas.Stop();

            Console.WriteLine($"* Liczba ruchow: {licznik}");
            Console.WriteLine($"- czas gry: {czas.Elapsed}");

        }
    }
}
