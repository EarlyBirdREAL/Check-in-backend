using Database;
using Flight = Core.Entities.Flight;

namespace App.Services;

public class FlightService : IFlightService
{
    private readonly IFlight _flight;

    public FlightService(IFlight flight)
    {
        _flight = flight;
    }
    /// <summary>
    /// This function requests all the flights from the database Layer.
    /// For each flight it 
    /// then calculates what time boarding is at by a set offset.
    /// It also refactors the julian date (0-365) to DD-MM-YYYY
    /// </summary>
    /// <returns><b>IEnumerable</b> - <see cref="Flight"/></returns>
    public IEnumerable<Flight> GetAllFlightsAsync()
    {
        return  GetAllFlightAsync();
    }

    private IEnumerable<Flight> GetAllFlightAsync()
    {
        List<Flight> flights = new List<Flight>();
        var flight =  _flight.GetAllFlightsAsync();
        foreach (Flights aFlight in flight)
        {
            DateTime date;
            DateTime dateNow = DateTime.Now;
            DateTime dateThen =
                new DateTime(DateTime.Now.Year, 01, 01).AddDays(Int32.Parse(aFlight.Datum));
                // new DateOnly(DateOnly.FromDateTime(DateTime.Now).Year, 01, 01).AddDays(Int32.Parse(aFlight.Datum));
            if (dateNow > dateThen)
            {
                date = dateThen.AddDays(1);
            }
            else
            {
                date = dateThen;
            }

            TimeSpan boardingTime;
            TimeSpan time = aFlight.Tijd.Subtract(new TimeSpan(0, 45, 0));
            if (time < new TimeSpan(0))
            {
                boardingTime = time.Add(new TimeSpan(24, 0, 0));
            }
            else
            {
                boardingTime = time;
            }
            flights.Add(new Flight()
            {
                VluchtNummer = aFlight.VluchtNummer,
                Maatschappij = aFlight.Maatschappij,
                Datum = date,
                Tijd = aFlight.Tijd,
                BoardingTijd = boardingTime,
                Oorsprong = aFlight.Oorsprong,
                Bestemming = aFlight.Bestemming
            });
        }
        IEnumerable<Flight> enumerable = flights as IEnumerable<Flight>;
        return enumerable;
    }
}