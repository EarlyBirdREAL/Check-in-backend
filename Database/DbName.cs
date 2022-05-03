
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Database;

public class DbName
{
    
    public string GetNames(string pnrCode)
    {
        return GetName(pnrCode);
    }
    private string GetName(string pnrCode)
    {
        
        MySqlConnection con = new MySqlConnection("server=localhost;user=backend;database=rotterdam;password=root");
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