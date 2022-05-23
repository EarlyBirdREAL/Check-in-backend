using Core.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Database;

public class Flight : IFlight
{
    private readonly IConfiguration _configuration;

    public Flight(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Flights> GetAllFlightsAsync()
    {
        return GetAllFlightAsync();
    }

    private List<Flights> GetAllFlightAsync()
    {
        List<Flights> flights = new List<Flights>();
        string connectionString = _configuration.GetValue<string>("DbVariables:ConnectionString");
        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlCommand cmd =
            new MySqlCommand(
                "SELECT vluchtnummer, vertrekvliegveld, bestemming, datum, maatschappij, VluchtTijd FROM vlucht", con);
        con.Open();
        MySqlDataReader reader;
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            flights.Add(new Flights()
            {
                VluchtNummer = reader.GetValue(0).ToString(),
                Maatschappij = reader.GetValue(4).ToString(),
                Oorsprong = reader.GetValue(1).ToString(),
                Bestemming = reader.GetValue(2).ToString(),
                Datum = reader.GetValue(3).ToString(),
                Tijd = reader.GetTimeSpan(5)
            });


        }

        return flights;
    }
}

public class Flights
{
    public string VluchtNummer { get; set; }
    public string Maatschappij { get; set; }
    public string Datum { get; set; }
    public TimeSpan Tijd { get; set; }
    public string Oorsprong { get; set; }
    public string Bestemming { get; set; }
}

