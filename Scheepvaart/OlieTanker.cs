using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    enum ladingOlie {olie, benzeen, diesel, nafta};
    class OlieTanker : Schip, ICargowaarde, ITanker
    {

        public double Cargowaarde { get; set; }
        public double Volume { get; set; }
        public string Lading { get; set; } //enum gebruiken? --> olie, benzeen, diesel, nafta
    }
}
