namespace Core.Entities;

public class Passenger
{
    public string Voornaam { get; set; }
    public string Achternaam { get; set; }
    public string Stoel { get; set; }
    public string CheckInSequenceNumber { get; set; }

    public Passenger()
    {
        Voornaam = "";
        Achternaam = "";
        Stoel = "";
        CheckInSequenceNumber = "";
    }
}