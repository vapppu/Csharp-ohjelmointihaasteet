namespace Haaste9
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> arvosanat = new Dictionary<int, string>() { { 0, "hylätty" }, { 1, "välttävä" }, { 2, "tyydyttävä" }, { 3, "hyvä" }, { 4, "kiitettävä" }, { 5, "erinomainen" } };

            while (true)
            {
                Console.WriteLine("Anna numeerinen arvosana väliltä 0-5: ");
                try
                {
                    string arvosana = arvosanat[Convert.ToInt32(Console.ReadLine())];
                    Console.WriteLine($"Arvosana: {arvosana}");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Virheellinen syöte!");
                }
            }
        }
    }
}