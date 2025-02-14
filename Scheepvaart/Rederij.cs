using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    class Rederij {

        public string Naam { get; set; }
        public List<Vloot> Vloten { get; set; }
        public HashSet<Haven> Havens { get; set; }

        //Methoden die nodig zullen zijn ;
        /*voegVlootToe(Vloot)
        verwijderVloot(Vloot)
        voegHavenToe(String)
        verwijderHaven(String)
        zoekVlootOpNaam(string naam) : Vloot
        overzichtHavens() : List
        totaleCargowaarde() : double
        totaalAantalPassagiers() : int
        tonnagePerVloot() : List<Tuple<Vloot,double>>
        totaalTankVolume() : double
        beschikbareSleepboten() : List
        infoSchip(string) : Schip*/
    }
}
