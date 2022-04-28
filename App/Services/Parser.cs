using Core.Entities;

namespace App.Services;

public class Parser
{
    public BoardingPass Decode(string code)
    {
        return Parse(code);
    }

    private static BoardingPass Parse(string code)
    {
        var splitBoardingPass = code.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        return new BoardingPass
        {
            FormatCode = ParseFormatCode(splitBoardingPass),
            Legs = ParseNumberOfLegs(splitBoardingPass),
            PassengerName = ParsePassengerName(splitBoardingPass),
            ElectronicTicketIndicator = ParseElectronicTicketIndicator(splitBoardingPass),
            OperatingCarrierPnrCode = ParseOperatingCarrierPnrCode(splitBoardingPass),
            FromCityAirportCode = ParseFromCityAirportCode(splitBoardingPass),
            ToCityAirportCode = ParseToCityAirportCode(splitBoardingPass),
            OperatingCarrierDesignator = ParseOperatingCarrierDesignator(splitBoardingPass),
            FlightNumber = ParseFlightNumber(splitBoardingPass),
            DateOfFlight = ParseDateOfFlight(splitBoardingPass),
            CompartmentCode = ParseCompartmentCode(splitBoardingPass),
            SeatNumber = ParseSeatNumber(splitBoardingPass),
            CheckInSequenceNumber = ParseCheckInSequenceNumber(splitBoardingPass)
        };
    }

    private static string ParseFormatCode(string[] splitBoardingPass)
    {
        return splitBoardingPass[0][..1];
    }

    private static int ParseNumberOfLegs(string[] splitBoardingPass)
    {
        return Convert.ToInt32(splitBoardingPass[0].Substring(1, 1));
    }

    private static string ParsePassengerName(string[] splitBoardingPass)
    {
        return splitBoardingPass[0][2..];
    }

    private static string ParseElectronicTicketIndicator(string[] splitBoardingPass)
    {
        return splitBoardingPass[1][..1];
    }

    private static string ParseOperatingCarrierPnrCode(string[] splitBoardingPass)
    {
        return splitBoardingPass[1][1..];
    }

    private static string ParseFromCityAirportCode(string[] splitBoardingPass)
    {
        return splitBoardingPass[2][..3];
    }

    private static string ParseToCityAirportCode(string[] splitBoardingPass)
    {
        return splitBoardingPass[2][3..6];
    }

    private static string ParseOperatingCarrierDesignator(string[] splitBoardingPass)
    {
        return splitBoardingPass[2][6..];
    }

    private static string ParseFlightNumber(string[] splitBoardingPass)
    {
        return splitBoardingPass[3];
    }

    private static string ParseDateOfFlight(string[] splitBoardingPass)
    {
        return splitBoardingPass[4][..3];
    }

    private static string ParseCompartmentCode(string[] splitBoardingPass)
    {
        return splitBoardingPass[4][3..4];
    }

    private static string ParseSeatNumber(string[] splitBoardingPass)
    {
        return splitBoardingPass[4][4..8];
    }

    private static string ParseCheckInSequenceNumber(string[] splitBoardingPass)
    {
        return splitBoardingPass[4][8..];
    }
}