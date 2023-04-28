
namespace HaasteEXTRA
#nullable disable

{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Peli peli = new Peli();
            peli.lohikaarme = new pelinOsapuoli(10);
            peli.kaupunki = new pelinOsapuoli(15);

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            peli.lohikaarmeenEtaisyys = kysyEtaisyys("Pelaaja 1, kuinka kaukana kaupungista lohikäärme on (0-100)? ");

            Console.Clear();
            Console.WriteLine("Pelaajan 2 vuoro.");
            Console.ResetColor();


            while (!peli.paattynyt)
            {
                peli.uusiKierros();
            }
            Console.WriteLine("Peli päättyi!");
        }

        public static int kysyEtaisyys(string kysymys)
        {
            while (true)
            {
                int etaisyys;
                Console.Write(kysymys);
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    etaisyys = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    if ((etaisyys >= 0) && (etaisyys <= 100))
                    {
                        return etaisyys;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}