namespace Haaste7
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] vaihtoehdot = { "kivi", "paperi", "sakset" };
            Dictionary<string, string> voittajat = new Dictionary<string, string>() {
                {"kivi", "paperi"}, {"paperi", "sakset"}, {"sakset", "kivi"}
            };
            while (true)

            {
                string valinta = kayttajanValinta(vaihtoehdot);
                Console.WriteLine($"Valitsit: {valinta}.");

                Random rnd = new Random();
                string tietokoneenValinta = vaihtoehdot[rnd.Next(0, 3)];
                Console.WriteLine($"Tietokone valitsi: {tietokoneenValinta}.");

                if (voittajat[valinta] == tietokoneenValinta)
                {
                    Console.WriteLine("Tietokone voitti!");
                    break;
                }
                else if (voittajat[tietokoneenValinta] == valinta)
                {
                    Console.WriteLine("Voitit!");
                    break;
                }
                else
                    Console.WriteLine("Tasapeli! Otertaan uusintakierros.");
            }
        }

        static string kayttajanValinta(string[] vaihtoehdot)
        {
            while (true)
            {
                Console.WriteLine("1 = Kivi, 2 = Paperi, 3 = Sakset?");
                try
                {
                    return (vaihtoehdot[Convert.ToInt32(Console.ReadLine()) - 1]);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}