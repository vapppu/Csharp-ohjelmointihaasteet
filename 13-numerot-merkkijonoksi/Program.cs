﻿#nullable disable

// HUOM! Ohjelma toimii satoihintuhansiin asti, ei siitä ylöspäin...

namespace Haaste13
{
    using System;

    public class Program
    {
        public static readonly string[] ykkoset = { "", "yksi", "kaksi", "kolme", "neljä", "viisi", "kuusi", "seitsemän", "kahdeksan", "yhdeksän" };

        static void Main(string[] args)
        {
            string teksti = "Herra Huun osoite on tattisuonkatu 42 A 123.";
            Console.WriteLine(teksti);
            Console.WriteLine(muunnaTekstiksi(teksti));
        }


        static string muunnaTekstiksi(string teksti)
        {
            string muunnettuTeksti = "";

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
            int[] digits = new int[numero.Length];

            for (int i = 0; i < numero.Length; i++)
            {
                digits[i] = Convert.ToInt32(numero[i].ToString());
            }

            Array.Reverse(digits);

            return (sadatTuhannet(digits) + kymmenetTuhannetJaTuhannet(digits) + sadat(digits) + (ykkosetJaKymmenet(digits)));
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
        static string sadat(int[] digits)
        {
            // Jos luku on alle sata
            if (digits.Length < 3)
                return "";
            // Jos sadat on nolla
            else if (digits[2] == 0)
                return "";
            // Jos sadat on yksi
            else if (digits[2] == 1)
                return "sata";
            // Muuten tulosta "n sataa"
            else
                return (ykkoset[digits[2]] + "sataa");
        }
        static string tuhannet(int[] digits)
        {
            // Jos luku on alle tuhat
            if (digits.Length < 4)
                return "";
            // Jos tuhannet on nolla
            else if (digits[3] == 0)
                return "";
            // Jos tuhannet on yksi
            else if (digits[3] == 1)
                return "tuhat";
            // Muuten tulosta "n tuhatta"
            else
                return (ykkoset[digits[3]] + "tuhatta");
        }

        static string kymmenetTuhannetJaTuhannet(int[] digits)
        {
            // Jos luku on alle kymmenentuhatta
            if (digits.Length == 4)
            {
                return tuhannet(digits);
            }
            else if (digits.Length >= 5)
            {
                // Jos tuhannet ja kymmenettuhannet on nolla
                if (digits[4] == 0)
                    if (digits[3] == 0)
                        return "";
                    else
                        // Jos kymmenettuhannet on nolla mutta tuhannet ei -> palauta tuhannet
                        return tuhannet(digits);
                // Kymmenettuhannet ja tuhannet ei ole nolla -> palauta montako kymmentä tuhatta
                return (ykkosetJaKymmenet(new int[] { digits[3], digits[4] }) + "tuhatta");
            }
            else
                return "";
        }

        static string sadatTuhannet(int[] digits)
        {
            // Jos luku on miljoona tai yli ja sadattuhannet on nolla, palauta tyhjä merkkijono
            if (digits.Length >= 6)
                if (digits[5] == 0)
                    return "";
                else
                    // Palauta montako sataa tuhatta
                    return sadat(new int[] { digits[3], digits[4], digits[5] });
            // Jos luku on alle satatuhatta
            else
                return "";
        }
    }
}
