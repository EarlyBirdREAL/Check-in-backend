namespace Check_in.Models;

public class BoardingPass
{
    public string? FormatCode { get; set; }
    public string? Legs { get; set; }
    public string? FirstName { get; set;  } 
    public string? LastName { get; set; }
    public string? ElectronicTicketIndicator { get; set; }
    public string? OperatingCarrierPnrCode { get; set; }
    public string? FromCityAirportCode { get; set; }
    public string? ToCityAirportCode { get; set; }
    public string? OperatingCarrierDesignator { get; set; }
    public string? FlightNumber { get; set; }
    public string? DateOffFlight { get; set; }
    public string? CompartmentCode { get; set; }
    public string? SeatNumber { get; set; }
    public string? CheckInSequenceNumber { get; set; }
}