namespace Core.Entities;

public class AddPassenger
{
    public AddPassenger()
    {
        Voornaam = "";
        Achternaam = "";
        Bagage = false;
        VluchtNummer = "";
        BoekingsNummer = 0;
        Stoel = "";
    }

    public string Voornaam { get; set; }
    public string Achternaam { get; set; }
    public bool Bagage { get; set; }
    public string VluchtNummer { get; set; }
    public int BoekingsNummer { get; set; }
    public string Stoel { get; set; }
}