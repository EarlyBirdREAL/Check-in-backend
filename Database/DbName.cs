using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Database;

public class DbName : IDbName
{
    private readonly IConfiguration _configuration;

    private DbName(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pnrCode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public string GetNames(string pnrCode)
    {
        if (pnrCode == null)
        {
            throw new ArgumentNullException(nameof(pnrCode));
        }
        // if (pnrCode.Length != 7)
        // {
        //     throw new ArgumentException(nameof(pnrCode));
        // }
        return GetName(pnrCode);
    }

    private string GetName(string pnrCode)
    {
        string connectionString = _configuration.GetValue<string>("DbVariables:ConnectionString");
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            using (MySqlCommand cmd =
                   new MySqlCommand("SELECT voornaam, achternaam FROM passagier WHERE PNR_code = @pnr", con))
            {
                cmd.Parameters.AddWithValue("@pnr", pnrCode);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    string Name;
                    string fName;
                    string lName;
                    while (reader.Read())
                    {
                        fName = reader.GetString("voornaam");
                        lName = reader.GetString("achternaam");
                        Name = lName + ", " + fName;
                        return Name;
                    }

                    return "Undefined";
                }
            }
        }
    }
}