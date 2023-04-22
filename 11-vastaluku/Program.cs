namespace Haaste11
{
    using System;
    using ExtensionMethods;

    public class Program
    {
        static void Main(string[] args)
        {
            int[] luvut = new int[] { 8, -103, 76, -5, 236, -56230 };

            Taulukko taulukko = new Taulukko(luvut);

            Console.WriteLine("\nMiten taulukon jäsenet voidaan muuttaa omiksi vastaluvuikseen?\n");
            Console.WriteLine("ENSIMMÄINEN TAPA: luodaan uusi Taulukko-luokka, jolla on arrayn vastaluvuiksi muuttava metodi.\n\nAlkuperäinen taulukko: ");
            Console.WriteLine(taulukko);

            taulukko.Vastaluvuiksi();

            Console.WriteLine("\nVastaluvuiksi muutettu taulukko:");
            Console.WriteLine(taulukko);
            Console.WriteLine("\n****\n");
            Console.WriteLine("TOINEN TAPA: metodi, joka muuttaa luvun omaksi vastaluvukseen. For-toistolauseella muutetaan arrayn luvut vastaluvuiksi luku kerrallaan.\n");
            Console.WriteLine("Alkuperäinen taulukko:");

            tulostaArray(luvut);

            for (int i = 0; i < luvut.Length; i++)
            {
                luvut[i] = vastaluku(luvut[i]);
            }

            Console.WriteLine("\nTaulukon jäsenet muutettu yksi kerrallaan vastaluvuiksi: ");

            tulostaArray(luvut);

            Console.WriteLine("\n****\n");
            Console.WriteLine("KOLMAS TAPA: Extension method Array-luokalle.\n\nAlkuperäinen taulukko: ");

            tulostaArray(luvut);

            luvut.vastaluvut();

            Console.WriteLine("\nTaulukko, joka muutettu vastaluvuiksi Array-luokkaan lisätyllä Extension methodilla: ");

            tulostaArray(luvut);
        }


        public class Taulukko
        {
            public int[] luvut;

            public Taulukko(int[] luvut)
            {
                this.luvut = luvut;
            }

            public void Vastaluvuiksi()
            {
                if (this.luvut != null)
                {
                    for (int i = 0; i < this.luvut.Length; i++)
                    {
                        this.luvut[i] = -this.luvut[i];
                    }
                }
            }
            public override string ToString()
            {
                string returnString = "";
                if (this.luvut == null)
                {
                    return ("Tyhjä taulukko.");
                }
                foreach (int luku in this.luvut)
                {
                    returnString += $"{luku}, ";
                }
                return returnString.TrimEnd(' ', ',');
            }

        }
        static int vastaluku(int luku)
        {
            return (-luku);
        }

        static void tulostaArray(int[] array)
        {
            string returnString = "";
            foreach (int luku in array)
            {
                returnString += $"{luku}, ";
            }
            Console.WriteLine(returnString.TrimEnd(' ', ','));
        }
    }
}

namespace ExtensionMethods
{
    public static class Vastaluvuiksi
    {
        public static void vastaluvut(this int[] luvut)
        {
            for (int i = 0; i < luvut.Length; i++)
            {
                luvut[i] = -luvut[i];
            }
            return;
        }
    }
}