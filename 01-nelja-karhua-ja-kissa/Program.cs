using System;

namespace Haaste01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int bears = 4;

            Console.WriteLine("How many fish?");
            int fish = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine($"Fish for bears: {fishPerBear(fish, bears)}");
            Console.WriteLine($"Fish left for cat: {fishToCat(fish, bears)}");

            List<int> moreFishToCat = new List<int>();

            fish = 0;

            while (true)
            {
                if (fishToCat(fish, bears) > fishPerBear(fish, bears))
                {
                    moreFishToCat.Add(fish);

                    if (moreFishToCat.Count == 3)
                    {
                        break;
                    }
                    fish++;
                }
            }

            Console.WriteLine("Amounts of fish where cat gets more fish than bears: ");
            foreach (int amount in moreFishToCat)
            {
                Console.WriteLine(amount);
            }



        }

        static int fishPerBear(int fish, int bears)
        {
            return (fish / bears);
        }

        static int fishToCat(int fish, int bears)
        {
            return (fish % bears);
        }


    }
}