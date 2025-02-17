using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    public class Vloot {
        public string Naam { get; set; }
        public Dictionary<string, Schip> Schepen { get; } = new Dictionary<string, Schip>();

        public void VoegSchipToe(Schip schip) {
            if (Schepen.ContainsKey(schip.Naam))
                throw new InvalidOperationException("Schip reeds aanwezig.");
            Schepen.Add(schip.Naam, schip);
            schip.HuidigeVloot = this;
        }

        public bool VerwijderSchip(string naam) {
            if (Schepen.Remove(naam, out Schip schip)) {
                schip.HuidigeVloot = null;
                return true;
            }
            return false;
        }
    }
}

