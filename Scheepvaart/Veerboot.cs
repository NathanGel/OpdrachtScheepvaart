using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    public class Veerboot : Schip, IPassagiers {
        public int AantalPassagiers { get; set; }
        public string Haven1 { get; set; }
        public string Haven2 { get; set; }

        public override string ToString() => $"Veerboot {Naam}: Passagiers={AantalPassagiers}, Route={Haven1}-{Haven2}";
    }
}
