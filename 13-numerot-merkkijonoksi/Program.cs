#nullable disable

namespace Haaste13
{
    using System;

    public class Program
    {
        string[] ykkoset = new string[] { "nolla", "yksi", "kaksi", "kolme", "neljä", "viisi", "kuusi", "seitsemän", "kahdeksan", "yhdeksän" };

        string[] kymmenet = new string[] { "kymmenen", "kymmentä" };

        string[] sadat = new string[] { "sata", "sataa" };

        string[] tuhannet = new string[] { "tuhat", "tuhatta" };

        static void Main(string[] args)
        {
            int numero = 120;
            StringNumero numeroMerkkeina = new StringNumero(numero);
            Console.WriteLine(numeroMerkkeina.merkkijonona());
        }

        public class StringNumero
        {
            int numero;
            string numeroString;
            // string[] ykkoset, kymmenet, sadat, tuhannet;
            public StringNumero(int numero)
            {
                this.numero = numero;
                this.numeroString = numero.ToString();
            }
            public string merkkijonona()
            {
                return ("1");

            }

        }
    }
}
