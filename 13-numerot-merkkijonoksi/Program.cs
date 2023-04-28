#nullable disable

namespace Haaste13
{
    using System;

    public class Program
    {
        public static readonly string[] oneToNine = { "", "yksi", "kaksi", "kolme", "neljä", "viisi", "kuusi", "seitsemän", "kahdeksan", "yhdeksän" };
        public static readonly List<string> thirdPowersOfTen = new List<string> { "", "tuhatta ", "miljoonaa ", "miljardia " };
        public static readonly List<string> singleThirdPowersOfTen = new List<string> { "yksi", "tuhat ", "miljoona ", "miljardi " };

        static void Main(string[] args)
        {
            string text = "1100 1000000 9807987643";
            Console.WriteLine(convertNumbersToText(text));
        }

        static string convertNumbersToText(string text)
        {
            string convertedText = "";

            // Käy teksti merkki kerrallaan läpi 
            for (int i = 0; i < text.Length; i++)
            {
                // Löydä numeroista koostuvat osamerkkijonot, muunna ne tekstimuotoisiksi kirjoita palautettavaan merkkijonoon (muunnettuTeksti)
                if (Char.IsDigit(text[i]))
                {
                    string newNumber = text[i].ToString();

                    while (i < (text.Length - 1))
                    {
                        if (Char.IsDigit(text[i + 1]))
                        {
                            i++;
                            newNumber += text[i];
                        }
                        else
                            break;
                    }
                    convertedText += (numberToText(newNumber));
                }

                // Kirjoita merkit, jotka eivät ole numeroita, palautettavaan merkkijonoon sellaisinaan
                else
                    convertedText += text[i];
            }
            return convertedText;

        }

        static string numberToText(string number)
        {
            // Palauta erityistapaus nolla
            if (number == "0")
                return "nolla";

            // Muunnetaan numero taulukoksi, jossa ykköset ovat ensimmäisellä paikalla, kymmenet toisella jne. 

            char[] numberAsArray = number.ToCharArray();
            Array.Reverse(numberAsArray);
            string numberReversed = new string(numberAsArray);

            // Jaetaan array kolmen numeron kokoisiin osamerkkijonoihin, jotta näitä palasia voidaan kääntää tekstiksi aina sadan joukkio kerrallaan.

            List<string> hundredSlices = new List<string>();

            // Jakojäännöksestä nähdään, onko viimeisen merkkijonon pituus kolme vai vähemmän
            int jakojaannos = number.Length % 3;

            // Lisätään "sataset" listaan.
            for (int i = 0; i < number.Length; i += 3)
            {
                try
                {
                    hundredSlices.Add(numberReversed.Substring(i, 3));
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    hundredSlices.Add(numberReversed.Substring(i, jakojaannos));
                }
            }

            // Käännetään satasen lista taas niin päin, että suurin on ensimmäisenä
            hundredSlices.Reverse();

            // Palautetaan aikaansaatu satasen palikoiden lista tekstiksi muunnettuna
            return (hundredSlicesToText(hundredSlices));

        }
        static string hundredSlicesToText(List<string> hundredSlices)
        {
            string numberAsString = "";

            //  Suurin "kertaluokka", josta lasketellaan alaspäin
            int hundredsCount = hundredSlices.Count() - 1;

            // Käsitellään jokaista "satasen palikkaa" kokonaislukutaulukkona
            foreach (string hundredString in hundredSlices)
            {
                int[] digits = new int[hundredString.Length];

                for (int j = 0; j < hundredString.Length; j++)
                    digits[j] = Convert.ToInt32(hundredString[j].ToString());

                if (isOnlyOne(digits))
                    numberAsString += singleThirdPowersOfTen[hundredsCount];

                else if (!arrayIsZero(digits))
                    numberAsString += hundredsTensOnes(digits, hundredsCount);

                hundredsCount--;
            }

            return (numberAsString);

        }

        // Palauttaa tosi, jos kokonaislukutaulukon ensimmäinen alkio on 1 ja loput nollia
        static bool isOnlyOne(int[] digits)
        {
            for (int i = 0; i < digits.Count() - 1; i++)
                if (digits[i + 1] != 0)
                    return false;
            return (digits[0] == 1);
        }

        // Palauttaa tosi, jos kaikki kokonaislukutaulukon jäsenet ovat nollia
        static bool arrayIsZero(int[] digits)
        {
            foreach (int digit in digits)
                if (digit != 0)
                    return false;
            return true;
        }

        // Palauttaa max. kolmen pituisen kokonaislukutaulukon tekstiksi muunnettuna (X sataa Y kymmentä Z)
        static string hundredsTensOnes(int[] digits, int hundredsCount)
        {
            if ((digits.Length > 3) || (digits.Length == 0))
                throw new IndexOutOfRangeException("Array length must be between 1 and 3.");

            string numberAsString = "";

            // SADAT

            if (digits.Length == 3)
            {
                int hundreds = digits[2];

                if (hundreds == 1)
                    numberAsString += "sata";

                else if (hundreds != 0)
                    numberAsString += (oneToNine[hundreds] + "sataa");
            }

            // KYMMENET JA YKKÖSET:

            if (digits.Length >= 2)
            {
                int tens = digits[1];
                int ones = digits[0];

                // 01-09
                if ((tens == 0) && (ones != 0))
                    numberAsString += oneToNine[ones];

                // 10-19
                else if (tens == 1)
                {
                    if (ones == 0)
                        numberAsString += "kymmenen";
                    else
                        numberAsString += (oneToNine[ones] + "toista");
                }

                // 20-99
                else if (!((ones == 0) && tens == 0))
                    numberAsString += (oneToNine[tens] + "kymmentä" + oneToNine[ones]);
            }

            // PELKÄT YKKÖSET (jos arrayn pituus 1)

            else
            {
                int ones = digits[0];
                numberAsString += oneToNine[ones];
            }

            return (numberAsString + thirdPowersOfTen[hundredsCount]);
        }
    }
}
