using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    class Rederij {

        public string Naam { get; set; }
        public List<Vloot> Vloten { get; set; } = new List<Vloot>(); //maak meteen een lijst aan
        public List<Haven> Havens { get; set; } = new List<Haven>();


        public void VoegVlootToe(Vloot vloot)
        {
            Vloten.Add(vloot);
        }

        public void VerwijderVloot(Vloot vloot)
        {
            Vloten.Remove(vloot);
        }

        public void VoegHavenToe(Haven haven)
        {
            Havens.Add(haven);
        }

        public void VerwijderHaven(Haven haven)
        {
            Havens.Remove(haven);
        }

        public Vloot ZoekVlootOpNaam(string naam)
        {
            foreach (Vloot v in Vloten)
            {
                if (v.Naam == naam)
                    return v;
            }
            return null;
        }

        public List<Haven> OverzichtHavens()
        {
            List<Haven> gesorteerdeHavens = new List<Haven>(Havens);
            gesorteerdeHavens.Sort((h1, h2) => h1.Naam.CompareTo(h2.Naam));
            return gesorteerdeHavens;
        }

        public double TotaleCargowaarde()
        {
            double totaal = 0;
            foreach (Vloot vloot in Vloten)
            {
                totaal = totaal + vloot.TotaleCargowaarde();
            }
            return totaal;
        }

        public int TotaalAantalPassagiers()
        {
            int totaal = 0;
            foreach (Vloot vloot in Vloten)
            {
                totaal = totaal + vloot.TotaalAantalPassagiers();
            }
            return totaal;
        }

        public List<Vloot> TonnagePerVloot()
        {
            List<Vloot> gesorteerdeVloten = new List<Vloot>(Vloten);
            gesorteerdeVloten.Sort((v1, v2) => v2.Tonnage().CompareTo(v1.Tonnage())); //icomparer gebruiken???
            return gesorteerdeVloten;
        }

        public double TotaalVolumeTankers()
        {
            double totaal = 0;
            foreach (Vloot vloot in Vloten)
            {
                totaal = totaal + vloot.TotaalVolumeTankers();
            }
            return totaal;
        }

        public List<Sleepboot> BeschikbareSleepboten()
        {
            List<Sleepboot> sleepboten = new List<Sleepboot>();
            foreach (Vloot vloot in Vloten)
            {
                foreach (Vloot schip in vloot.Schepen)
                {
                    if (schip is Sleepboot sleepboot)
                    {
                        sleepboten.Add(sleepboot);
                    }
                }
            }
            return sleepboten;
        }

        public Schip InfoSchip(string naam)
        {
            foreach (Vloot vloot in Vloten)
            {
                foreach (Vloot schip in vloot.Schepen)
                {
                    if (schip.Naam == naam) return schip;
                }
            }
            return null;
        }



        //Methoden die nodig zullen zijn ;
        /*voegVlootToe(Vloot) void
        verwijderVloot(Vloot) void
        voegHavenToe(String) void
        verwijderHaven(String) void
        zoekVlootOpNaam(string naam) : Vloot
        overzichtHavens() : List<haven>
        totaleCargowaarde() : double
        totaalAantalPassagiers() : int
        tonnagePerVloot() : List<Vloot,double>
        totaalTankVolume() : double
        beschikbareSleepboten() : List<sleepboot>
        infoSchip(string) : Schip*/
    }
}
