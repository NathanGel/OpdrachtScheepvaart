using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    enum LadingGas {lpg, lnp, ammoniak}
    public class GasTanker : Schip, ICargowaarde {
        public double Cargowaarde { get; set; }
        public int Volume { get; set; }
        public string Lading { get; set; } //enum gebruiken? --> lpg, lnp, ammoniak
        public override string ToString() => $"Gastanker {Naam}: Cargo={Cargowaarde:C}, Volume={Volume}L, Lading={Lading}";
    }
}
