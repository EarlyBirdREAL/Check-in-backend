using App.Models;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Check_in.Controllers;

[Route("api/Flights")]
[ApiController]
public class FlightController : ControllerBase
{
    /// <summary>
    /// This function gets all Flights currently in the database,
    /// This calls the function GetAllFlightsAsync from <see cref="FlightService"/>
    /// </summary>
    /// <returns><b>IEnumerable</b> - Flight</returns>
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] IFlightService flightService)
    {
        var flights = flightService.GetAllFlightsAsync();
        var result = ApiResult<IEnumerable<Flight>>.Success(flights);
        return Ok(result);
    }
}