namespace Core.Entities;

public class AddPassenger
{
    public AddPassenger()
    {
        Voornaam = "";
        Achternaam = "";
        PnrCode = "";
        Bagage = false;
        VluchtNummer = 0;
        Datum = 0;
        BoekingsNummer = 0;
        Stoel = "";
        Class = "";
    }

    public string Voornaam { get; set; }
    public string Achternaam { get; set; }
    public string PnrCode { get; set; }
    public bool Bagage { get; set; }
    public int VluchtNummer { get; set; }
    public int Datum { get; set; }
    public int BoekingsNummer { get; set; }
    public string Stoel { get; set; }
    public string Class { get; set; }
}