namespace Harjoitus5
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> userPairs = new Dictionary<int, int>() {
                {1, 2}, {2, 1} };

            foreach (var user in userPairs)
            {
                int number = getNumber($"User {user.Key}, enter a number between 0 and 100: ");
                Console.Clear();
                guessNumber(user.Value, number);
            }
        }

        static int getNumber(string message)
        {
            return getNumber(message, $"Invalid input.");
        }

        static int getNumber(string message, string errorMessage)
        {
            while (true)
            {
                Console.Write($"{message}");
                try
                {
                    return (Convert.ToInt32(Console.ReadLine()));
                }
                catch (Exception)
                {
                    Console.WriteLine(errorMessage);
                    continue;
                }
            }
        }

        static void guessNumber(int user, int number)
        {
            Console.WriteLine($"User {user}, guess the number.");
            while (true)
            {
                int guess = getNumber("What is your next guess? ");
                if (guess < number)
                    Console.WriteLine($"{guess} is too low.");
                else if (guess > number)
                    Console.WriteLine($"{number} is too high.");
                else
                {
                    Console.WriteLine("You guessed the number!");
                    break;
                }
            }
        }
    }
}