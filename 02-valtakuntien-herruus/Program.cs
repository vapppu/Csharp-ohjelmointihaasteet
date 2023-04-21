using System;

namespace Ohjelmointihaaste2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pelaaja pelaaja = new Pelaaja();

            Console.WriteLine("Syötä maatilojen määrä: ");
            pelaaja.maatilat = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Syötä herttuakuntien määrä: ");
            pelaaja.herttuakunnat = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Syötä maakuntien määrä: ");
            pelaaja.maakunnat = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Pelaalan pistemäärä: {pelaaja.pisteMaara}");

        }
        public class Pelaaja
        {
            public int pisteMaara
            {
                get
                {
                    return ((maatilat * 1) + (herttuakunnat * 3) + (maakunnat * 6));
                }
            }
            public int maatilat;
            public int herttuakunnat;
            public int maakunnat;

            public Pelaaja()
            {
                this.maatilat = 0;
                this.herttuakunnat = 0;
                this.maakunnat = 0;
            }


        }
    }
}