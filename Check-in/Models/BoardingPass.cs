using System.Diagnostics;

namespace Check_in.Models;

public class BoardingPass
{ public string? FormatCode { get; set; }
    public string? Legs { get; set; }
    public string? FirstName { get; set;  } 
    public string? LastName { get; set; }

    public string? Name
    {
        get => FirstName + " " + LastName;
        set
        {
            Debug.Assert(value != null, nameof(value) + " != null");
            if (value.Contains("/"))
            {
                FirstName = value.Split("/")[1].Trim();
                LastName = value.Split("/")[0].Trim();
            }
            else
            {
                LastName = value;
            }
        }
    }

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