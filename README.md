# OpdrachtScheepvaart7
een paar dingen aangepast : 

Rederij
Attributen:
naam: String
vloten: List
havens: Set
Methoden:
voegVlootToe(Vloot)
verwijderVloot(Vloot)
voegHavenToe(String)
verwijderHaven(String)
zoekVlootOpNaam(String): Vloot
overzichtHavens(): List
totaleCargowaarde(): double
totaalAantalPassagiers(): int
tonnagePerVloot(): List<Tuple<Vloot, double>>
totaalTankVolume(): double
beschikbareSleepboten(): List
infoSchip(String): Schip


Vloot
Attributen:
naam: String
schepen: List
Methoden:
voegSchipToe(Schip)
verwijderSchip(Schip)
zoekSchipOpNaam(String): Schip
overzichtSchepen(): List
verplaatsSchip(Schip, Vloot)


Schip (Abstracte Klasse)
Attributen:
naam: String
lengte: double
breedte: double
tonnage: double
Methoden:
getInfo(): String


Containerschip
Attributen:
aantalContainers: int
cargowaarde: double


RoRoschip
Attributen:
aantalAutos: int
aantalTrucks: int
cargowaarde: double


Cruiseschip
Attributen:
aantalPassagiers: int
traject: List


Veerboot
Attributen:
aantalPassagiers: int
traject: String


Olietanker
Attributen:
cargowaarde: double
volume: double
lading: String (Enum: Olie, Benzeen, Diesel, Nafta)


Gastanker
Attributen:
cargowaarde: double
volume: double
lading: String (Enum: LPG, LNG, Ammoniak)


Sleepboot -> niks aangepast
!!! cargowaarde, lading.... die we apart gingen zetten staan VOORLOPIG in de klassen zelf !!!
