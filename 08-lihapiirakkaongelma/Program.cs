namespace Haaste8
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Lompakko lompakko = new Lompakko(getPositiveInteger("Paljonko rahaa lompakossasi on?"));

            int lihapiirakanHinta = getPositiveInteger("Paljonko lihapiirakka maksaa?");

            if (lompakko.rahaa >= lihapiirakanHinta)
            {
                Console.WriteLine("Sinulla on varaa ostaa lihapiirakka.");
                lompakko.rahaa -= lihapiirakanHinta;
                Console.WriteLine($"Lompakkoon jää {lompakko.rahaa} rahaa.");
            }
            else
                Console.WriteLine("Sinulla ei ole rahaa ostaa lihapiirakkaa. Kehotan sinua paastoamaan.");
        }
        public class Lompakko
        {
            public int rahaa;

            public Lompakko(int rahaa)
            {
                if (rahaa >= 0)
                    this.rahaa = rahaa;
                else
                {
                    this.rahaa = 0;
                }
            }

            public void Decrease(int maara)
            {
                if (rahaa - maara >= 0)
                    this.rahaa = rahaa - maara;
            }
        }
        static int getPositiveInteger(string message)
        {
            while (true)
            {
                Console.WriteLine(message);

                try
                {
                    int integer = Convert.ToInt32(Console.ReadLine());
                    if (integer >= 0)
                        return integer;
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Ole hyvä ja anna positiivinen kokonaisluku.");
                    continue;
                }
            }
        }
    }
}