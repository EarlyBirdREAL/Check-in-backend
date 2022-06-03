using Core.Entities;

namespace App.Services;

public interface IAddPassengerService
{
    BoardingPass CreatePassenger(AddPassenger passenger);
    Task<IEnumerable<BoardingPass>> CreatePassengers(string flight, int numbOfPax);
    // Flight CreateFlight(Flight flight);
}