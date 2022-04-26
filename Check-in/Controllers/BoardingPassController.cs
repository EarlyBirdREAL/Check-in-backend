using Check_in.Models;
using Microsoft.AspNetCore.Mvc;

namespace Check_in.Controllers
{
    [Route("api/BoardingPassInfo")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet(Name = "GetBoardingPassInfo")]
        public BoardingPass Get(string code)
        {
            return new BoardingPass
            {
                FormatCode = code[..1],
                Legs = code.Substring(1, 1),
                FirstName = code.Substring(2, 20).Split("/")[1].Trim(),
                LastName = code.Substring(2, 20).Split("/")[0].Trim(),
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
}

