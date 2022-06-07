namespace Core.Entities;

public class Flight
{
    public string VluchtNummer { get; set; }
    public string Maatschappij { get; set; }
    public DateTime Datum { get; set; }
    public TimeSpan Tijd { get; set; }
    public TimeSpan BoardingTijd { get; set; }
    public string Oorsprong { get; set; }
    public string Bestemming { get; set; }
}
