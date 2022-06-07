using Core.Entities;

namespace Database;

public interface IBoarding
{
    Task<List<Passenger>> GetAllPassengerAsync(string flight);
}