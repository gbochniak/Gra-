using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{

    class Program
    {
        static void Start()
        {

            Console.Clear();
            Console.WriteLine("Aplikacja GRA");
            Console.WriteLine("============");
            licznik = 0;
            czas = Stopwatch.StartNew();
        }

        static int Losuj()
        {
            Random los = new Random();
            int wylosowana = los.Next(1, 101);
#if DEBUG
            Console.WriteLine(wylosowana);
#endif
            Console.WriteLine("Wylosowalem liczbe z zakresu od 1 do 100. Odgadnij ja");
            return wylosowana;

        }

        static int WczytajPropozycje()
        {
            int propozycja = 0;

            
            while (true)
            {
                Console.Write("Podaj swoja propozycje: ");
                string napis = Console.ReadLine();
                if (napis == "koniec")
                {
                    throw new ArgumentException("Poddaje sie");
                }

                try
                {
                    propozycja = int.Parse(napis);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie podales liczby. \n Sprobuj jeszcze raz");

                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Przesadziles. Za duza liczba");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Niezidentyfikowany wyjatek. Awaria");
                    Environment.Exit(1);
                }
            }
            licznik++;
            return propozycja;
        }

        static bool Ocena(int wylosowana, int propozycja)
        {
            if (wylosowana > propozycja)
            {
                Console.WriteLine("Za malo");
                return false;
            }
            else if (wylosowana < propozycja)
            {
                Console.WriteLine("Za duzo");
                return false;
            }
            else
            {
                Console.WriteLine("Trafiles");

                return true;

            }

        }

        static void Statystyki()
        {
            czas.Stop();
            Console.WriteLine("Statystyki gry: ");
            Console.WriteLine($"- czas gry: {czas.Elapsed}");
            Console.WriteLine($"- liczba ruchow: {licznik} ");




        }

        static int licznik = 0;
        static Stopwatch czas;

        static void Main(string[] args)
        {
            Start();
            int x = Losuj();
            bool trafiono = false;
            do
            {
                //wczytaj
                int y;
                try
                {
                    y = WczytajPropozycje();
                }
                catch(ArgumentException)
                {

                    Console.WriteLine("Poddajesz sie");
                    return;
                }
                //ocen
                trafiono = Ocena(x, y);

            } while (!trafiono);

            Statystyki();

        }
        static void Main1(string[] args)
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
                catch (FormatException)
                {
                    Console.WriteLine("Nie podales liczby. \n Sprobuj jeszcze raz");

                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Przesadziles. Za duza liczba");
                    continue;
                }
                catch (Exception)
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

