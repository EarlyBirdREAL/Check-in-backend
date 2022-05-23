using App.Models;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Check_in.Controllers;

[Route("api/Passengers")]
[ApiController]
public class PassengerController : ControllerBase
{
    [HttpGet("{flight}")]
    public async Task<IActionResult> Get([FromServices] IPassengerService passengerService, string flight)
    {
        var passengers = await passengerService.GetAllPassengersAsync(flight);
        var result = ApiResult<IEnumerable<Passenger>>.Success(passengers);

        return Ok(result);
    }
    
}