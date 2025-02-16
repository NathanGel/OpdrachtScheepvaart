namespace Scheepvaart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rederij rederij = new Rederij { Naam = "Mijn Rederij" };

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Voeg vloot toe");
                Console.WriteLine("2. Verwijder vloot");
                Console.WriteLine("3. Voeg haven toe");
                Console.WriteLine("4. Verwijder haven");
                Console.WriteLine("5. Bekijk overzicht havens");
                Console.WriteLine("6. Totale cargowaarde");
                Console.WriteLine("7. Totaal aantal passagiers");
                Console.WriteLine("8. Tonnage per vloot");
                Console.WriteLine("9. Totaal volume tankers");
                Console.WriteLine("10. Afsluiten");
                Console.Write("Kies een optie: ");

                string keuze = Console.ReadLine();

                switch (keuze)
                {
                    case "1":
                        Console.Write("Naam van de vloot: ");
                        string naamVloot = Console.ReadLine();
                        rederij.VoegVlootToe(new Vloot { Naam = naamVloot });
                        break;
                    case "2":
                        Console.Write("Naam van de vloot: ");
                        string verwijderNaam = Console.ReadLine();
                        Vloot vloot = rederij.ZoekVlootOpNaam(verwijderNaam);
                        if (vloot != null) rederij.VerwijderVloot(vloot);
                        break;
                    case "3":
                        Console.Write("Naam van de haven: ");
                        string naamHaven = Console.ReadLine();
                        rederij.VoegHavenToe(new Haven { Naam = naamHaven });
                        break;
                    case "4":
                        Console.Write("Naam van de haven: ");
                        string verwijderHaven = Console.ReadLine();
                        foreach (Haven h in rederij.Havens)
                        {
                            if (h.Naam == verwijderHaven)
                            {
                                rederij.VerwijderHaven(h);
                                break;
                            }
                        }
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Ongeldige optie.");
                        break;
                }
            }
        }
    }
}
