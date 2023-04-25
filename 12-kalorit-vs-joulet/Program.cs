#nullable disable

namespace Haaste12
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Kalorit jouleiksi\n2. Joulet kaloreiksi");
            string valinta;
            int maara;

            while (true)
            {
                Console.Write("Valitse muunnos: ");
                valinta = Console.ReadLine();
                if ((new List<string> { "1", "2" }).Contains(valinta))
                    break;
            }

            switch (valinta)
            {
                case "1":
                    maara = getAmount("cal");
                    double joulet = jouleiksi(maara);
                    Console.WriteLine($"{joulet} J");
                    break;
                case "2":
                    maara = getAmount("J");
                    double kalorit = kaloreiksi(maara);
                    Console.WriteLine($"{kalorit} cal");
                    break;
                default:
                    break;
            }
        }
        static int getAmount(string yksikko)
        {
            while (true)
            {
                Console.Write($"Anna määrä ({yksikko}): ");
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
        static double jouleiksi(int maara)
        {
            return (maara * 4.184);
        }
        static double kaloreiksi(int maara)
        {
            return (maara * 0.2390);
        }
    }
}
