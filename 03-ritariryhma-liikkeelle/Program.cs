namespace Haaste3
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ritariryhmä liikkeelle.";

            Kuningas kuningas;

            while (true)
            {
                Console.Write("Kohderivi: ");
                int rivi = Convert.ToInt32(Console.ReadLine());

                Console.Write("Kohdesarake: ");
                int sarake = Convert.ToInt32(Console.ReadLine());

                try
                {
                    kuningas = new Kuningas(rivi, sarake);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            kuningas.LahetaRitarit();

        }

        public class Kuningas
        {
            public int rivi;
            public int sarake;
            List<Tuple<int, int>> ritarit;

            public Kuningas(int rivi, int sarake)
            {
                if (((rivi <= 1) || (rivi >= 8)) || ((sarake <= 1) || (sarake >= 8)))
                {
                    Console.WriteLine("King must not be in the border coordinates.");
                    throw new Exception("King coordinates out of range.");
                }
                else
                {
                    this.rivi = rivi;
                    this.sarake = sarake;
                }
                this.ritarit = new List<Tuple<int, int>>();
                Ritarit();
            }

            public void Ritarit()
            {
                List<Tuple<int, int>> Ritarilista = new List<Tuple<int, int>>();

                for (int sarake = this.sarake - 1; sarake <= this.sarake + 1; sarake++)
                {
                    for (int rivi = this.rivi - 1; rivi <= this.rivi + 1; rivi++)
                    {
                        if ((sarake == this.sarake) ^ (rivi == this.rivi))
                        {
                            this.ritarit.Add(Tuple.Create(rivi, sarake));
                        }
                    }
                }
            }

            public void LahetaRitarit()
            {
                List<string> numerot = new List<string> { "yksi", "kaksi", "kolme", "neljä" };

                int i = 0;
                foreach (Tuple<int, int> ritari in this.ritarit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Lähetetään ritari {numerot[i]} kohteeseen {ritari}");
                    Console.Beep();
                    i++;
                }
            }
        }
    }
}




