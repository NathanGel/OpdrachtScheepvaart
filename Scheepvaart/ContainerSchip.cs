using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    public class ContainerSchip : Schip, ICargowaarde {
        public int AantalContainers { get; set; }
        public double Cargowaarde { get; set; }

        public override string ToString() => $"Containerschip {Naam}: Containers={AantalContainers}, Cargo={Cargowaarde:C}";
    }
}
