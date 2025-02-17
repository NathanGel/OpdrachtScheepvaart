namespace Scheepvaart
{
    public abstract class Schip //abstracte klassen omdat : 
                                //The purpose of an abstract class is to
                                //provide a common definition of a base class
                                //that multiple derived classes can share. 
    {
        public double Lengte { get; set; }
        public double Breedte { get; set; }
        public int Tonnage { get; set; }
        public string Naam { get; set; }
        public Vloot HuidigeVloot { get; set; } //Nog eens nagelezen en je moet een schip van vloot kunnen wijzigen

        public abstract override string ToString();
    }
}
