namespace Haaste6
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            foreach (int num in Enumerable.Range(1, 100))
            {
                if ((num % 3) == 0 && (num % 5 == 0))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{num}: Electric and Fire");
                }
                else if ((num % 3) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{num}: Fire");
                }
                else if (num % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{num}: Electric");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"{num}: Normal");
                }
            }
        }
    }
}