using AutoMapper;
using Core.Entities;
using Database;

namespace App.Services;

public class PassengerService : IPassengerService
{

    private readonly IBoarding _boarding;

    public PassengerService(IBoarding boarding)
    {
        _boarding = boarding;
    }
    public async Task<IEnumerable<Passenger>> GetAllPassengersAsync(string flight)
    {

        var members = await _boarding.GetAllPassengerAsync(flight);
        IEnumerable<Passenger> enumerable = members as IEnumerable<Passenger>;
        return enumerable;
    }
}

public class PassengerResponse
{
    public string Voornaam { get; set; }
    public string Achternaam { get; set; }
    public string Stoel { get; set; }
    public string CheckInSequenceNumber { get; set; }
}