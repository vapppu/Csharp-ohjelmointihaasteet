namespace HaasteEXTRA;

#nullable disable

public class Peli
{
    public pelinOsapuoli lohikaarme;
    public pelinOsapuoli kaupunki;
    public int kierros;
    public int kanuunanVahingollisuus;
    public int lohikaarmeenEtaisyys;
    public bool paattynyt;
    public Peli()
    {
        this.kierros = 0;
        this.paattynyt = false;
    }
    public void uusiKierros()
    {
        this.kierros++;
        this.laskeKanuunanVahingollisuus();
        this.tulostaTilanne();
        this.pelaaKierros();
    }

    public void pelaaKierros()

    {
        int ampumisEtaisyys = Program.kysyEtaisyys("Mille etäisyydelle kanuunalla ammutaan? ");

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        if (ampumisEtaisyys == this.lohikaarmeenEtaisyys)
        {
            Console.WriteLine("Osuma!");
            paivitaPisteet(-this.kanuunanVahingollisuus, this.lohikaarme);
        }
        else if (ampumisEtaisyys > this.lohikaarmeenEtaisyys)
        {
            Console.WriteLine("Tähtäys oli liian pitkä ja osuma ylitti kohteen.");
        }
        else
        {
            Console.WriteLine("Tähtäys oli liian lyhyt ja osuma jäi vajaaksi.");
        }

        if (!(this.paattynyt))
            paivitaPisteet(-1, this.kaupunki);

        Console.ResetColor();
    }

    public void laskeKanuunanVahingollisuus()
    {
        if ((this.kierros % 3 == 0) && (this.kierros % 5 == 0))
            this.kanuunanVahingollisuus = 10;
        else if ((this.kierros % 3 == 0) ^ (this.kierros % 5 == 0))
            this.kanuunanVahingollisuus = 3;
        else
            this.kanuunanVahingollisuus = 1;
    }

    public void paivitaPisteet(int pisteet, pelinOsapuoli osapuoli)
    {
        osapuoli.muutaTerveyspisteita(pisteet);

        this.paattynyt = ((this.lohikaarme.terveyspisteet <= 0) || (this.kaupunki.terveyspisteet <= 0));
    }

    public void tulostaTilanne()
    {
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine($"TILANNE: Kierros: {this.kierros}  Kaupunki: {this.kaupunki.terveyspisteet}/{this.kaupunki.maksimipisteet}  Lohikäärme: {this.lohikaarme.terveyspisteet}/{this.lohikaarme.maksimipisteet}");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Kanuuna tekee {this.kanuunanVahingollisuus} pistettä vahinkoa tällä vuorolla.");
        Console.ResetColor();
    }
}