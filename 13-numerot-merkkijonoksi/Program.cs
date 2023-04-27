#nullable disable

// HUOM! Ohjelma toimii satoihintuhansiin asti, ei siitä ylöspäin...

namespace Haaste13
{
    using System;

    public class Program
    {
        public static readonly string[] ykkoset = { "", "yksi", "kaksi", "kolme", "neljä", "viisi", "kuusi", "seitsemän", "kahdeksan", "yhdeksän" };

        static void Main(string[] args)
        {

            Console.Write(muunnaTekstiksi("Herra huu asuu talossa 765 ja on syntynyt vuonna 1980. Hän on 1000 vuotta vanha."));

        }

        static string muunnaTekstiksi(string teksti)
        {
            string muunnettuTeksti = "";

            // Käy teksti merkki kerrallaan läpi ja tallenna merkit uuteen merkkijonoon, jossa numeroista koostuvat osamerkkijonot on muutettu numeroiksi tekstinä.
            for (int i = 0; i < teksti.Length; i++)
            {
                if (Char.IsDigit(teksti[i]))
                {
                    string uusiNumero = teksti[i].ToString();
                    while (true)
                    {
                        try
                        {
                            if (Char.IsDigit(teksti[i + 1]))
                            {
                                i++;
                                uusiNumero += teksti[i];
                            }
                            else
                            {
                                muunnettuTeksti += (numeroTekstiksi(uusiNumero));
                                break;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            muunnettuTeksti += (numeroTekstiksi(uusiNumero));
                            break;
                        }
                    }
                }
                else
                {
                    muunnettuTeksti += teksti[i];
                }
            }
            return muunnettuTeksti;
        }


        static string numeroTekstiksi(string numero)
        {
            Console.Write($"{numero} : ");

            if (numero == "0")
                return "nolla";
            else if (numero == "1")
                return "yksi";

            // Käännetään numero alusta loppuun, jotta voidaan käsitellä sitä arrayna ykkösistä lähtien.

            char[] numeroAsArray = numero.ToCharArray();
            Array.Reverse(numeroAsArray);
            string numeroReversed = new string(numeroAsArray);

            // Jaetaan array kolmen numeron kokoisiin osiin (sadat-kymmenet-ykköset), jotta näitä palasia voidaan kääntää tekstiksi yksi kerrallaan.

            List<string> hundredSlices = new List<string>();

            int jakojaannos = numero.Length % 3;

            for (int i = 0; i < numero.Length; i += 3)
            {
                try
                {
                    hundredSlices.Add(numeroReversed.Substring(i, 3));
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    hundredSlices.Add(numeroReversed.Substring(i, jakojaannos));
                }
            }

            List<string> kertaluokat = new List<string> { "", "tuhatta", "miljoonaa", "miljardia" };
            List<string> yksittäisetKertaluokat = new List<string> { "", "tuhat", "miljoona", "miljardi" };

            int counter = hundredSlices.Count() - 1;

            // Perustetaan paluuarvomerkkijono, johon seuraavaksi lisätään tekstiksi muutettuja numeron osasia
            string numberAsString = "";

            // Käännetään paloitellun numeron osasten lista jälleen niin, että isoimmat ovat alussa
            hundredSlices.Reverse();

            // Käsitellään jokaista "satasen palikkaa" kokonaislukutaulukkona
            foreach (string substring in hundredSlices)
            {
                int[] digitArray = new int[substring.Length];

                for (int j = 0; j < substring.Length; j++)
                {
                    digitArray[j] = Convert.ToInt32(substring[j].ToString());
                }

                // Jos kaikki arrayn kokonaisluvut eivät ole nollia, käännetään array tekstiksi.
                if (!arrayIsZero(digitArray))
                {
                    bool onlyOne = false;

                    for (int k = 1; k < digitArray.Count() - 1; k++)
                    {
                        if (!(digitArray[k + 1] == 0))
                        {
                            onlyOne = true;
                        }
                    }

                    if (digitArray.Length == 3)
                    {
                        numberAsString += (sadat(digitArray));
                    }

                    // Erityistapaus: jos satatsen palikka alkaa ykkösellä, tulostetaan kertaluokka yksikössä ("tuhat", "sata", vrt. "tuhatta" jne.)
                    if ((digitArray[0] == 1) && (onlyOne = true))
                    {
                        numberAsString += yksittäisetKertaluokat[counter];
                    }
                    else
                    {
                        numberAsString += (ykkosetJaKymmenet(digitArray));
                        numberAsString += (kertaluokat[counter]);
                    }
                    counter--;

                }
            }

            return (numberAsString);


            // Palauttaa tosi, jos kaikki kokonaislukutaulukon jäsenet ovat nollia
            static bool arrayIsZero(int[] intArray)
            {
                foreach (int integer in intArray)
                {
                    if (!(integer == 0))
                    {
                        return false;
                    }
                }
                return true;
            }

            static string sadat(int[] digits)
            {
                string converted = "";

                // Jos sadat on nolla
                if (digits[2] == 0)

                    converted = "";
                // Jos sadat on yksi
                else if (digits[2] == 1)
                    converted = "sata";
                // Muuten tulosta "n sataa"
                else
                    converted = (ykkoset[digits[2]] + "sataa");

                return converted;
            }


            static string ykkosetJaKymmenet(int[] digits)
            {
                // 0-9
                if (digits.Length == 1)
                {
                    if (digits[0] == 0)
                        return "nolla";
                    else
                        return ykkoset[digits[0]];
                }
                // Jos kymmenet on nollassa, älä kirjoita kymmenien kohdalle mitään
                if (digits[1] == 0)
                    if (digits[0] != 0)
                        return ykkoset[digits[0]];
                    else
                        return "";

                // 10 - 19
                if (digits[1] == 1)
                {
                    // kymmenen:
                    if (digits[0] == 0)
                        return "kymmenen";
                    // 11-19
                    else
                        return ykkoset[digits[0]] + "toista";
                }
                // 20-99
                else
                {
                    return ykkoset[digits[1]] + "kymmentä" + ykkoset[digits[0]];
                }
            }
        }
    }
}
