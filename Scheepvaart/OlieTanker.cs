using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    enum LadingOlie {olie, benzeen, diesel, nafta};
    public class OlieTanker : Schip, ICargowaarde, ITanker
    {
        public double Cargowaarde { get; set; }
        public int Volume { get; set; }
        public string Lading { get; set; } //enum gebruiken? --> olie, benzeen, diesel, nafta
        public override string ToString() => $"Olietanker {Naam}: Cargo={Cargowaarde:C}, Volume={Volume}L, Lading={Lading}";
    }
}
