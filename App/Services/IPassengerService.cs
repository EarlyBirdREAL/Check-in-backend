using Core.Entities;

namespace App.Services;

public interface IPassengerService
{
    Task<IEnumerable<Passenger>> GetAllPassengersAsync(string flight);
}