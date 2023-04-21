namespace Haaste4
{
    using System;

    public class Program
    {
        /* 
        Kuvaus
        Strategiapeliin koodataan vartiotorni. Vartiotornin tulee varoittaa vihollisen liikkeistä ja kertoa mistä suunnasta vihollinen tulee.

        Tehtävä
        Kysy käyttäjältä x ja y arvot. Käytetään näitä koordinaatioina mistä suunnasta vihollinen tulee
        Kuvaa hyödyntäen tulosta oikea lause, perustuen mistä koordinaateista vihollinen tulee
        

           x<0 x=0 x>0 
        y>0 NW  N   NE
        y=0 W   !   E
        y<0 SW  S   SE
        */

        static void Main(string[] args)
        {
            Console.Write("x: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            int y = Convert.ToInt32(Console.ReadLine());

            string[,] ilmansuunnat = new string[3, 3] {
                { "south west", "south",    "south east" },
                { "west",       "!",        "east" },
                { "north west", "north",    "north east" } };

            if ((x == 0) && (y == 0))
                Console.WriteLine("The enemy IS HERE!");
            else
                Console.WriteLine($"The enemy is to the {ilmansuunnat[getIndex(y), getIndex(x)]}!");
        }

        static int getIndex(int integer)
        {
            if (integer < 0)
                return 0;
            else if (integer == 0)
                return 1;
            else
                return 2;
        }
    }
}