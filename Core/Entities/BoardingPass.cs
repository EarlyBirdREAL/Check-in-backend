namespace Core.Entities;

public class BoardingPass
{
    public BoardingPass()
    {
        FormatCode = "";
        Legs = -1;
        PassengerName = "";
        ElectronicTicketIndicator = "";
        OperatingCarrierPnrCode = "";
        FromCityAirportCode = "";
        ToCityAirportCode = "";
        OperatingCarrierDesignator = "";
        FlightNumber = "";
        DateOfFlight = "";
        CompartmentCode = "";
        SeatNumber = "";
        CheckInSequenceNumber = "";
    }

    public string FormatCode { get; set; }
    public int Legs { get; set; }
    public string PassengerName { get; set; }
    public string ElectronicTicketIndicator { get; set; }
    public string OperatingCarrierPnrCode { get; set; }
    public string FromCityAirportCode { get; set; }
    public string ToCityAirportCode { get; set; }
    public string OperatingCarrierDesignator { get; set; }
    public string FlightNumber { get; set; }
    public string DateOfFlight { get; set; }
    public string CompartmentCode { get; set; }
    public string SeatNumber { get; set; }
    public string CheckInSequenceNumber { get; set; }
}