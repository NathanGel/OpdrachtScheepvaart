using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheepvaart {
    public class Rederij {
        public string Naam { get; set; }
        public Dictionary<string, Vloot> Vloten { get; } = new Dictionary<string, Vloot>();
        public SortedSet<string> Havens { get; } = new SortedSet<string>();
        public Dictionary<string, Schip> AlleSchepen { get; } = new Dictionary<string, Schip>();

        public void VoegVlootToe(Vloot vloot) {
            if (Vloten.ContainsKey(vloot.Naam))
                throw new ArgumentException("Vloot bestaat al.");
            Vloten.Add(vloot.Naam, vloot);
        }

        public void VerwijderVloot(string naam) {
            if (Vloten.Remove(naam, out Vloot vloot)) {
                foreach (var schip in vloot.Schepen.Values.ToList())
                    VerwijderSchip(schip.Naam);
            }
        }

        public void VoegSchipToe(Schip schip, string vlootNaam) {
            if (AlleSchepen.ContainsKey(schip.Naam))
                throw new ArgumentException("Schipnaam bestaat al.");

            if (!Vloten.TryGetValue(vlootNaam, out Vloot vloot))
                throw new ArgumentException("Vloot niet gevonden.");

            vloot.VoegSchipToe(schip);
            AlleSchepen.Add(schip.Naam, schip);
        }

        public void VerwijderSchip(string naam) {
            if (!AlleSchepen.Remove(naam, out Schip schip)) return;
            schip.HuidigeVloot?.VerwijderSchip(naam);
        }

        public void VerplaatsSchip(string schipNaam, string nieuweVlootNaam) {
            if (!AlleSchepen.TryGetValue(schipNaam, out Schip schip))
                throw new ArgumentException("Schip niet gevonden.");
            if (!Vloten.TryGetValue(nieuweVlootNaam, out Vloot nieuweVloot))
                throw new ArgumentException("Vloot niet gevonden.");

            Vloot oudeVloot = schip.HuidigeVloot;
            oudeVloot?.VerwijderSchip(schipNaam);
            nieuweVloot.VoegSchipToe(schip);
        }

        public double TotaleCargowaarde() {
            return AlleSchepen.Values.Sum(s =>
                s switch {
                    ContainerSchip cs => cs.Cargowaarde,
                    RoRoSchip rs => rs.Cargowaarde,
                    OlieTanker ot => ot.Cargowaarde,
                    GasTanker gt => gt.Cargowaarde,
                    _ => 0
                });
        }

        public int TotaalPassagiers() {
            return AlleSchepen.Values.Sum(s =>
                s switch {
                    CruiseSchip cs => cs.AantalPassagiers,
                    Veerboot vb => vb.AantalPassagiers,
                    _ => 0
                });
        }

        public IEnumerable<KeyValuePair<string, int>> TonnagePerVloot() {
            return Vloten.Values
                .Select(v => new KeyValuePair<string, int>(v.Naam, v.Schepen.Values.Sum(s => s.Tonnage)))
                .OrderByDescending(kv => kv.Value);
        }

        public int TotaalVolumeTankers() {
            return AlleSchepen.Values.Sum(s =>
                s switch {
                    OlieTanker ot => ot.Volume,
                    GasTanker gt => gt.Volume,
                    _ => 0
                });
        }

        public List<Sleepboot> Sleepboten() {
            return AlleSchepen.Values.OfType<Sleepboot>().ToList();
        }

        public string SchipInfo(string naam) {
            return AlleSchepen.TryGetValue(naam, out Schip schip) ? schip.ToString() : "Niet gevonden.";
        }

        public void VoegHavenToe(string haven) => Havens.Add(haven);
        public void VerwijderHaven(string haven) => Havens.Remove(haven);
        public List<string> OverzichtHavens() => Havens.ToList();
        public List<Sleepboot> BeschikbareSleepboten() {
            return AlleSchepen.Values.OfType<Sleepboot>().ToList();
        }
    }
}
