using Core.Entities;

namespace App.Services;

public class Parser
{
    public BoardingPass Decode(string code)
    {
        if (code.Length <= 58)
        {
            return new BoardingPass();
        }
        
        return Parse(code);
    }
    
    private static BoardingPass Parse(string code)
    {
        return new BoardingPass
        {
            FormatCode = ParseFormatCode(code),
            Legs = ParseNumberOfLegs(code),
            PassengerName = ParsePassengerName(code),
            ElectronicTicketIndicator = ParseElectronicTicketIndicator(code),
            OperatingCarrierPnrCode = ParseOperatingCarrierPnrCode(code),
            FromCityAirportCode = ParseFromCityAirportCode(code),
            ToCityAirportCode = ParseToCityAirportCode(code),
            OperatingCarrierDesignator = ParseOperatingCarrierDesignator(code),
            FlightNumber = ParseFlightNumber(code),
            DateOfFlight = ParseDateOfFlight(code),
            CompartmentCode = ParseCompartmentCode(code),
            SeatNumber = ParseSeatNumber(code),
            CheckInSequenceNumber = ParseCheckInSequenceNumber(code)
        };
    }

    private static string ParseFormatCode(string boardingPass)
    {
        return boardingPass[..1];
    }

    private static int ParseNumberOfLegs(string boardingPass)
    {
        return Convert.ToInt32(boardingPass.Substring(1, 1));
    }

    private static string ParsePassengerName(string boardingPass)
    {
        return boardingPass.Substring(2, 20).Trim();
    }

    private static string ParseElectronicTicketIndicator(string boardingPass)
    {
        return boardingPass.Substring(22, 1);
    }

    private static string ParseOperatingCarrierPnrCode(string boardingPass)
    {
        return boardingPass.Substring(23, 7).Trim();
    }

    private static string ParseFromCityAirportCode(string boardingPass)
    {
        return boardingPass.Substring(30, 3);
    }

    private static string ParseToCityAirportCode(string boardingPass)
    {
        return boardingPass.Substring(33, 3);
    }

    private static string ParseOperatingCarrierDesignator(string boardingPass)
    {
        return boardingPass.Substring(36, 3).Trim();
    }

    private static string ParseFlightNumber(string boardingPass)
    {
        return boardingPass.Substring(39, 5).Trim();
    }

    private static string ParseDateOfFlight(string boardingPass)
    {
        return boardingPass.Substring(44, 3);
    }

    private static string ParseCompartmentCode(string boardingPass)
    {
        return boardingPass.Substring(47, 1);
    }

    private static string ParseSeatNumber(string boardingPass)
    {
        return boardingPass.Substring(48, 4);
    }

    private static string ParseCheckInSequenceNumber(string boardingPass)
    {
        return boardingPass.Substring(52, 5).Trim();
    }
}