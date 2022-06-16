using Core.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Database;

public class Boarding : IBoarding
{
    private readonly IConfiguration _configuration;

    public Boarding(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<List<Passenger>> GetAllPassengerAsync(string flight)
    {
        
        List<Passenger> paxList = new List<Passenger>();
        string connectionString = _configuration.GetValue<string>("DbVariables:ConnectionString");
        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlCommand cmd =
            new MySqlCommand(
                "SELECT voornaam, achternaam, checkInSequenceNumber, stoel  FROM passagier WHERE vluchtnummer = @FN",
                con);
        cmd.Parameters.AddWithValue("@FN", flight);
        con.Open();
        MySqlDataReader reader;
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            paxList.Add(new Passenger()
            {
                Voornaam = reader.GetValue(0).ToString(),
                Achternaam = reader.GetValue(1).ToString(),
                CheckInSequenceNumber = reader.GetValue(2).ToString(),
                Stoel = reader.GetValue(3).ToString()
            });
        }

        return paxList;
    }
}