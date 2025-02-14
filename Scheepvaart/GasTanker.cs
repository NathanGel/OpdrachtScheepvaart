using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    class GasTanker : Schip{

        public double CargoWaarde { get; set; }
        public double Volume { get; set; }
        public string Lading { get; set; } //enum gebruiken? --> lpg, lnp, ammoniak
    }
}
