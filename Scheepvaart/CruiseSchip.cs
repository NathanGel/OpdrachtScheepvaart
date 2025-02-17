using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    public class CruiseSchip : Schip, IPassagiers {
        public int AantalPassagiers { get; set; }
        public List<Haven> Traject { get; set; }

        public override string ToString() => $"Cruiseschip {Naam}: Passagiers={AantalPassagiers}, Traject={string.Join(" -> ", Traject)}";
    }
}
