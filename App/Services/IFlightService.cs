using Core.Entities;

namespace App.Services;

public interface IFlightService
{
    IEnumerable<Flight> GetAllFlightsAsync();
}