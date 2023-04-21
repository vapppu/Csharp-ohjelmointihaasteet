using System;

namespace Harj1

{
    public class Program

    {
        public class Kalasaalis
        {
            public int kaloja;
            public int karhuja;
            public int kissalle;
            public int karhulle;
            public int karhuilleYhteensa;

            public Kalasaalis(int karhuja, int kaloja)
            {
                this.karhuja = karhuja;
                this.kaloja = kaloja;
                this.karhulle = this.kaloja / this.karhuja;
                this.kissalle = this.kaloja % this.karhuja;
                this.karhuilleYhteensa = this.karhulle * this.karhuja;
            }

        }
        public static void Main(string[] args)

        {
            Console.WriteLine("Montako kalaa karhut kalastivat?");
            int kaloja = Convert.ToInt32(Console.ReadLine());

            Kalasaalis saalis = new Kalasaalis(karhuja: 4, kaloja: kaloja);

            Console.WriteLine($"\nKarhut kalastivat yhteensä {saalis.kaloja} kalaa. Kukin karhu saa {saalis.karhulle} kalaa. Kissalle jää {saalis.kissalle} kalaa.");

            Console.WriteLine($"\nMissä tilanteissa kissa saa enemmän kaloja kuin karhut yhteensä?\n");

            int kalaMaara = 0;

            while (true)
            {
                Kalasaalis uusiSaalis = new Kalasaalis(4, kalaMaara);
                if (uusiSaalis.kissalle > uusiSaalis.karhuilleYhteensa)
                {
                    Console.WriteLine($"Kaloja kalastettu {uusiSaalis.kaloja}. Kissa saa {uusiSaalis.kissalle} kalaa, mikä on enemmän kuin karhujen yhteensä saamat {uusiSaalis.karhuilleYhteensa} kalaa.");
                }

                kalaMaara++;

                if (kalaMaara > 20)
                    break;
            }

            Console.WriteLine($"\nMissä tilanteissa kissa saa enemmän kaloja kuin yksittäinen karhu?\n");

            kalaMaara = 0;

            while (true)
            {
                Kalasaalis uusiSaalis = new Kalasaalis(4, kalaMaara);

                if (uusiSaalis.kissalle > uusiSaalis.karhulle)
                {
                    Console.WriteLine($"Kissa saa eniten kaloja ({uusiSaalis.kissalle}), kun kaloja on saatu yhteensä {uusiSaalis.kaloja}. Yksittäinen karhu saa {uusiSaalis.karhulle} kalaa.");
                }
                if (kalaMaara > 20)
                    break;
                kalaMaara++;
            }

            /* 
            Karhuja on neljä, eli kalamäärä jaetaan aina neljän karhun kesken. Jakojäännös, eli kissalle jäävien kalojen määrä, on siis maksimissaan 3. Kissa saa siis enemmän kaloja kuin karhut yhteensä silloin, kun kaloja on saatu yhteensä 1, 2 tai 3.
            
            Kukin karhu saa alle kolme kalaa niin kauan kun kalastettujen kalojen määrä on vähemmän kuin 3 * 4 eli 12. Tätä korkeammissa määrissä kissa ei voi saada enemmän kaloja kuin karhut, sillä karhut saavat väistämättä kolme kalaa tai enemmän. 
            
            Karhut saavat 0 kalaa yhteismäärän ollessa alle 4. Näin ollen kissa saa koko kalamäärän silloin, kun kalojen yhteismäärä on 1, 2 ja 3. 

            Karhut saavat 1 kalan silloin, kun kalojen yhteismäärä on 4-7. Kissa saa enemmän kaloja silloin, kun jakojäännös on 2 tai 3, eli (1 * 4) + 2 = 6 sekä (1 * 4) + 3 = 7.

            Kukin karhu saa 2 kalaa silloin, kun kalojen yhteismäärä on vähintään 2 * 4 ja alle 3 * 4, eli kalojen määrän ollessa 8-11. Kissa saa enemmän kaloja, eli 3 kalaa, silloin kun kalojen määrä on (2 * 4) + 3, eli 11.
            */

        }
    }
}