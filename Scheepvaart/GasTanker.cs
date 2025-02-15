using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    enum LadingGas {lpg, lnp, ammoniak}
    class GasTanker : Schip, ICargowaarde {
        public double Cargowaarde { get; set; }
        public double Volume { get; set; }
        public string Lading { get; set; } //enum gebruiken? --> lpg, lnp, ammoniak
    }
}
