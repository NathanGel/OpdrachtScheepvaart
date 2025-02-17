using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    public class RoRoSchip : Schip, ICargowaarde {
        public int AantalAutos { get; set; }
        public int AantalTrucks { get; set; }
        public double Cargowaarde { get; set; }

        public override string ToString() => $"RoRoschip {Naam}: Autos={AantalAutos}, Trucks={AantalTrucks}, Cargo={Cargowaarde:C}";

    }
}
