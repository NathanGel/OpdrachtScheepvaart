using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    class Vloot {
        public string Naam { get; set; }
        public List<Schip> Schepen { get; set; } = new List<Schip>();

        public double TotaleCargowaarde()
        {
            double totaal = 0;
            foreach (Schip schip in Schepen)
            {
                ICargowaarde cargowaarde = schip as ICargowaarde; //loop voor ieder schip te bekijken, kijk als het icargowaarde gebruikt, zo ja ++
                if(cargowaarde != null)
                {
                    totaal = totaal + cargowaarde.Cargowaarde;
                }                
            }
            return totaal;
        }

        public int TotaalAantalPassagiers()
        {
            int totaal = 0;
            foreach (Schip schip in Schepen)
            {
                IPassagiers passagierschip = schip as IPassagiers;
                if (passagierschip != null)
                {
                    totaal = totaal + passagierschip.AantalPassagiers;
                }
            }
            return totaal;
        }

        public double Tonnage()
        {
            double totaal = 0;
            foreach (Schip schip in Schepen)
            {
                totaal = totaal + schip.Tonnage;
            }
            return totaal;
        }

        public double TotaalVolumeTankers()
        {
            double totaal = 0;
            foreach (Schip schip in Schepen)
            {
                ITanker tanker = schip as ITanker;
                if (tanker != null)
                {
                    totaal = totaal + tanker.Volume;
                }
            }
            return totaal;
        }
    }
    /*Methodes die nodig zullen zijn : 
    voegSchipToe(Schip) void
    verwijderSchip(Schip) void
    zoekSchipOpNaam(String): Schip
    overzichtSchepen(): List<ship>
    verplaatsSchip(Schip, Vloot)*/
}

