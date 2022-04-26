using Check_in.Models;

namespace Check_in.Services;

public class Parser
{
    public BoardingPass Decode(string code)
    {
        return Parse(code);
    }

    private BoardingPass Parse(string code)
    {
        return new BoardingPass
        {
            // todo: make fail proof for multiple flights
            FormatCode = code[..1],
            Legs = code.Substring(1, 1),
            Name = code.Substring(2, 20),
            ElectronicTicketIndicator = code.Substring(22, 1),
            OperatingCarrierPnrCode = code.Substring(23, 7),
            FromCityAirportCode = code.Substring(30, 3),
            ToCityAirportCode = code.Substring(33, 3),
            OperatingCarrierDesignator = code.Substring(36, 3),
            FlightNumber = code.Substring(39, 5),
            DateOffFlight = code.Substring(44, 3),
            CompartmentCode = code.Substring(47, 1),
            SeatNumber = code.Substring(48, 4),
            CheckInSequenceNumber = code.Substring(52, 5)
        };
    }
}