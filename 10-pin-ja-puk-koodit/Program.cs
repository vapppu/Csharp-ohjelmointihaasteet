namespace Haaste10
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string pin = "1234";
            string puk = "12345678";

            if (testaaKoodi(pin, 3, "Anna PIN-koodi"))
            {
                Console.WriteLine("PIN-koodi oikein!");
                return;
            }
            else
                Console.WriteLine("Annoit PIN-koodin väärin kolme kertaa.");

            if (testaaKoodi(puk, 3, "Anna PUK-koodi"))
            {
                Console.WriteLine("PUK-koodi oikein!");
                return;
            }
            else
                Console.WriteLine(
                    "Anoit PUK-koodin kolme kertaa väärin. Puhelimesi lukittuu.");

        }

        static bool testaaKoodi(string oikeaKoodi, int yrityksia, string viesti)
        {
            while (yrityksia > 0)
            {
                Console.WriteLine($"{viesti}. Yrityksiä jäljellä {yrityksia} kpl");
                if (Console.ReadLine() == oikeaKoodi)
                {
                    return true;
                }
                yrityksia--;
            }
            return false;
        }
    }
}