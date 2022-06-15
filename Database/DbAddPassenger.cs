using Core.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;

namespace Database;

public class DbAddPassenger : IDbAddPassenger
{
    private readonly IConfiguration _configuration;

    private static readonly Random random = new Random();

    public static string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public DbAddPassenger(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public BoardingPass GetData(BoardingPass boardingPass)
    {
        BoardingPass Boarding = new BoardingPass();
        Boarding.OperatingCarrierPnrCode = GetPnrCode();
        string[] airports = GetFromAndToAirport(/*boardingPass.OperatingCarrierDesignator+*/boardingPass.FlightNumber);
        Boarding.FromCityAirportCode = airports[0];
        Boarding.ToCityAirportCode = airports[1];
        Boarding.CheckInSequenceNumber =
            GetCheckInSequenceNumber(/*boardingPass.OperatingCarrierDesignator + */boardingPass.FlightNumber).ToString();
        return Boarding;
    }

    // TODO More here too asshole
    public void PutPassenger(BoardingPass boardingPass)
    {
        // string connectionString = _configuration.GetValue<string>("DbVariables:ConnectionString");
        // MySqlConnection con = new MySqlConnection(connectionString);
        // MySqlCommand cmd = new MySqlCommand("INSERT INTO ")
    }

    private string GetPnrCode()
    {
        while (true)
        {
            string rand = RandomString();
            string connectionString = _configuration.GetValue<string>("DbVariables:ConnectionString");
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlCommand cmd =
                new MySqlCommand(
                    "SELECT * FROM passagier WHERE PNR_code = @PNR",
                    con);
            cmd.Parameters.AddWithValue("@PNR", rand);
            con.Open();
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (!reader.HasRows) return rand;
        }
    }

    private string[] GetFromAndToAirport(string flight)
    {
        string[] airports = {"", "" };
        string connectionString = _configuration.GetValue<string>("DbVariables:ConnectionString");
        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlCommand cmd =
            new MySqlCommand(
                "SELECT vertrekvliegveld, bestemming FROM vlucht WHERE vluchtnummer = @FN",
                con);
        cmd.Parameters.AddWithValue("@FN", flight);
        con.Open();
        MySqlDataReader reader;
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {


            while (reader.Read())
            {
                airports[0] = reader.GetValue(0).ToString();
                airports[1] = reader.GetValue(1).ToString();
            }
        }

        return airports;
    }

    private int GetCheckInSequenceNumber(string flight)
    {
        string connectionString = _configuration.GetValue<string>("DbVariables:ConnectionString");
        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlCommand cmd =
            new MySqlCommand(
                "SELECT checkInSequenceNumber FROM passagier WHERE vluchtnummer = @FN ORDER BY checkInSequenceNumber desc;",
                con);
        cmd.Parameters.AddWithValue("@FN", flight);
        con.Open();
        MySqlDataReader reader;
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            return Int32.Parse(reader.GetValue(0).ToString()) + 1;
        }

        return 1;
    }
}