
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace Database;

public class DbName : IDbName
{
    private readonly IConfiguration _configuration;

    public DbName(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    
    public string GetNames(string pnrCode)
    {
        return GetName(pnrCode);
    }
    private string GetName(string pnrCode)
    {
        string connectionString = _configuration.GetValue<string>("DbVariables:ConnectionString");
        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlCommand cmd = new MySqlCommand("SELECT voornaam, achternaam FROM passagier WHERE PNR_code = @pnr", con);
        cmd.Parameters.AddWithValue("@pnr", pnrCode);
        con.Open();
        MySqlDataReader reader;
        reader = cmd.ExecuteReader();
        string Name;
        string fName;
        string lName;
        while (reader.Read())
        {
            fName = reader.GetString("voornaam");
            lName = reader.GetString("achternaam");
            Name = lName + "/" + fName;
            return Name;
        }

        return "Undefined";

    }
}