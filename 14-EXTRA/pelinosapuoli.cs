namespace HaasteEXTRA

{
    public class pelinOsapuoli
    {
        public int terveyspisteet;
        public int maksimipisteet;
        public pelinOsapuoli(int pisteet)
        {
            this.terveyspisteet = pisteet;
            this.maksimipisteet = pisteet;
        }
        public void muutaTerveyspisteita(int pisteet)
        {
            this.terveyspisteet += pisteet;
        }
    }
}