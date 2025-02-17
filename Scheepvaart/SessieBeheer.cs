using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart
{
    class SessieBeheer
    {
        private Rederij rederij = new Rederij { Naam = "Mijn Rederij" };

        public void Start() {
            while (true) {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("|             MENU            |");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("|1. Voeg vloot toe            |");
                Console.WriteLine("|2. Verwijder vloot           |");
                Console.WriteLine("|3. Voeg schip toe aan vloot  |");
                Console.WriteLine("|4. Verwijder schip uit vloot |");
                Console.WriteLine("|5. Verplaats schip naar vloot|");
                Console.WriteLine("|6. Voeg haven toe            |");
                Console.WriteLine("|7. Verwijder haven           |");
                Console.WriteLine("|8. Bekijk overzicht havens   |");
                Console.WriteLine("|9. Zoek schip op naam        |");
                Console.WriteLine("|10. Overzicht schepen vloot  |");
                Console.WriteLine("|11. Totale cargowaarde       |");
                Console.WriteLine("|12. Totaal aantal passagiers |");
                Console.WriteLine("|13. Tonnage per vloot        |");
                Console.WriteLine("|14. Totaal volume tankers    |");
                Console.WriteLine("|15. Beschikbare sleepboten   |");
                Console.WriteLine("|16. Afsluiten                |");
                Console.WriteLine("-------------------------------");
                Console.Write("Kies een optie: ");

                string keuze = Console.ReadLine();
                if (keuze == "16") return;

                VerwerkKeuze(keuze);
            }
        }

        private void VerwerkKeuze(string keuze) {
            Console.Clear();
            try {
                switch (keuze) {
                    case "1":
                        Console.Write("Naam van de vloot: ");
                        string naamVloot = Console.ReadLine();
                        rederij.VoegVlootToe(new Vloot { Naam = naamVloot });
                        break;
                    case "2":
                        Console.Write("Naam van de vloot: ");
                        string verwijderNaam = Console.ReadLine();
                        rederij.VerwijderVloot(verwijderNaam);
                        break;
                    case "3":
                        Console.Write("Naam van het schip: ");
                        string naamSchipToevoegen = Console.ReadLine();
                        Console.Write("Naam van de vloot waaraan je het schip wilt toevoegen: ");
                        string vlootNaamToevoegen = Console.ReadLine();

                        Console.WriteLine("Wat voor soort schip wil je toevoegen?");
                        Console.WriteLine("1. Sleepboot");
                        Console.WriteLine("2. Containerschip");
                        Console.WriteLine("3. Cruiseschip");
                        Console.WriteLine("4. Olietanker");
                        Console.WriteLine("5. GasTanker");
                        Console.Write("Keuze:");
                        string schipKeuze = Console.ReadLine();

                        Schip schip = null;
                        switch (schipKeuze) {
                            case "1":
                                schip = new Sleepboot { Naam = naamSchipToevoegen };
                                break;
                            case "2":
                                Console.Write("Aantal containers: ");
                                int containers = int.Parse(Console.ReadLine());
                                Console.Write("Cargowaarde: ");
                                double cargowaarde = double.Parse(Console.ReadLine());
                                schip = new ContainerSchip { Naam = naamSchipToevoegen, AantalContainers = containers, Cargowaarde = cargowaarde };
                                break;
                            case "3":
                                Console.Write("Aantal passagiers: ");
                                int passagiers = int.Parse(Console.ReadLine());
                                schip = new CruiseSchip { Naam = naamSchipToevoegen, AantalPassagiers = passagiers };
                                break;
                            case "4":
                                Console.Write("Volume: ");
                                int volume = int.Parse(Console.ReadLine());
                                Console.Write("Lading (olie, benzeen, diesel, nafta): ");
                                string olieLading = Console.ReadLine();
                                schip = new OlieTanker { Naam = naamSchipToevoegen, Volume = volume, Lading = olieLading };
                                break;
                            case "5":
                                Console.Write("Volume: ");
                                volume = int.Parse(Console.ReadLine());
                                Console.Write("Lading (lpg, lnp, ammoniak): ");
                                string gasLading = Console.ReadLine();
                                schip = new GasTanker { Naam = naamSchipToevoegen, Volume = volume, Lading = gasLading };
                                break;
                            default:
                                Console.WriteLine("Ongeldige keuze.");
                                return;
                        }

                        try {
                            rederij.VoegSchipToe(schip, vlootNaamToevoegen);
                            Console.WriteLine($"Schip {naamSchipToevoegen} toegevoegd aan vloot {vlootNaamToevoegen}.");
                        } catch (Exception ex) {
                            Console.WriteLine($"Fout: {ex.Message}");
                        }
                        break;
                    case "4":
                        Console.Write("Naam van het schip: ");
                        string naamSchipVerwijderen = Console.ReadLine();
                        rederij.VerwijderSchip(naamSchipVerwijderen);
                        break;
                    case "5":
                        Console.Write("Naam van het schip: ");
                        string schipNaamVerplaatsen = Console.ReadLine();
                        Console.Write("Nieuwe vloot naam: ");
                        string nieuweVlootNaam = Console.ReadLine();
                        rederij.VerplaatsSchip(schipNaamVerplaatsen, nieuweVlootNaam);
                        break;
                    case "6":
                        Console.Write("Naam van de haven: ");
                        string naamHaven = Console.ReadLine();
                        rederij.VoegHavenToe(naamHaven);
                        break;
                    case "7":
                        Console.Write("Naam van de haven: ");
                        string verwijderHaven = Console.ReadLine();
                        rederij.VerwijderHaven(verwijderHaven);
                        break;
                    case "8":
                        Console.WriteLine("Havens: " + string.Join(", ", rederij.OverzichtHavens()));
                        break;
                    case "9":
                        Console.Write("Zoek schip op naam: ");
                        string schipNaamZoeken = Console.ReadLine();
                        Console.WriteLine(rederij.SchipInfo(schipNaamZoeken));
                        break;
                    case "10":
                        foreach (var item in rederij.Vloten) {
                            Console.WriteLine($"Vloot {item.Key}:");
                            foreach (var schip_ in item.Value.Schepen.Values) {
                                Console.WriteLine($" - {schip_.Naam}");
                            }
                        }
                        break;
                    case "11":
                        Console.WriteLine($"Totale cargowaarde: {rederij.TotaleCargowaarde():C}");
                        break;
                    case "12":
                        Console.WriteLine($"Totaal aantal passagiers: {rederij.TotaalPassagiers()}");
                        break;
                    case "13":
                        foreach (var item in rederij.TonnagePerVloot())
                            Console.WriteLine($"{item.Key}: {item.Value} ton");
                        break;
                    case "14":
                        Console.WriteLine($"Totaal volume tankers: {rederij.TotaalVolumeTankers()} liter");
                        break;
                    case "15":
                        Console.WriteLine("Beschikbare sleepboten: " + string.Join(", ", rederij.BeschikbareSleepboten()));
                        break;
                    default:
                        Console.WriteLine("Ongeldige optie.");
                        break;
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
            if (keuze == "1" || keuze == "2" || keuze == "3" || keuze == "4" || keuze == "5" || keuze == "6" || keuze == "7") {
                 Console.WriteLine("Wijzigingen geregistreerd.");
            }
            Console.Write("Druk op een toets om verder te gaan.");
            Console.ReadKey();
        }
    }
}
