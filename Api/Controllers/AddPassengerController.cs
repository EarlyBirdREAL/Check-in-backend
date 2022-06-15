using App.Models;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Check_in.Controllers;
[Route("api/AddPassenger")]
[ApiController]
public class AddPassengerController : ControllerBase
{
    // TODO Add Correct DB Events with regard to Flight Number and operatingCarierDesignator
    [HttpGet("{flight}")]
    public async Task<IActionResult> Get([FromServices] IAddPassengerService addPassengerService, string flight, int passengers)
    {
        var BoardingPasses = await addPassengerService.CreatePassengers(flight, passengers);
        var result = ApiResult<IEnumerable<BoardingPass>>.Success(BoardingPasses);

        return Ok(result);
    }
}