using System.Text.Json.Serialization;
using Core.Entities;
using Database;
using Newtonsoft.Json;
using Flight = Core.Entities.Flight;

namespace App.Services;

public class AddPassengerService : IAddPassengerService
{
    private readonly IDbAddPassenger _dbAddPassenger;
    Random random = new Random();


    public AddPassengerService(IDbAddPassenger dbAddPassenger)
    {
        _dbAddPassenger = dbAddPassenger;
    }
    public BoardingPass CreatePassenger(AddPassenger passenger)
    {
        BoardingPass boardingPass = CreatePassengerBoardingPass(passenger);
        AddPassengerToDb(boardingPass);
        return boardingPass;
    }

    public async Task<IEnumerable<BoardingPass>> CreatePassengers(string flight, int numbOfPax)
    {
        List<BoardingPass> boardingPasses = new List<BoardingPass>();
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync($"https://my.api.mockaroo.com/names/{numbOfPax.ToString()}.json?key=b0ee2c50");
        response.EnsureSuccessStatusCode();
        string fileName = await response.Content.ReadAsStringAsync();
        List<Name> jsonObject = JsonConvert.DeserializeObject<List<Name>>(fileName);
        
        for (int i = 0; i < numbOfPax; i++)
        {
            const string chars = "ABCDEF";
            var namesId = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            Console.WriteLine(jsonObject);
            AddPassenger addPassenger = new AddPassenger()
            {
                Voornaam = jsonObject[i].first_name,
                Achternaam = jsonObject[i].last_name,
                Stoel = jsonObject[i].seat_number + namesId.Substring(0,1),
                VluchtNummer = flight
            };
            var boardingPass = CreatePassenger(addPassenger);
            boardingPasses.Add(boardingPass);
        }

        IEnumerable<BoardingPass> boarding = boardingPasses;
        return boarding;
    }

    // public Flight CreateFlight(Flight flight)
    // {
    //     
    // }

    private void AddPassengerToDb(BoardingPass boardingPass)
    {
        
    }
    private BoardingPass CreatePassengerBoardingPass(AddPassenger passenger)
    {
        BoardingPass boardingPass = new BoardingPass();
        boardingPass.Legs = 1;
        boardingPass.CompartmentCode = "F";
        boardingPass.FlightNumber = passenger.VluchtNummer/*.Substring(2)*/;
        boardingPass.FormatCode = "M";
        boardingPass.PassengerName = passenger.Voornaam + " " + passenger.Achternaam;
        boardingPass.SeatNumber = passenger.Stoel;
        boardingPass.ElectronicTicketIndicator = "E";
        boardingPass.OperatingCarrierDesignator = passenger.VluchtNummer.Substring(0, 2);
        BoardingPass boarding2 = _dbAddPassenger.GetData(boardingPass);
        boardingPass.CheckInSequenceNumber = boarding2.CheckInSequenceNumber;
        boardingPass.FromCityAirportCode = boarding2.FromCityAirportCode;
        boardingPass.ToCityAirportCode = boarding2.ToCityAirportCode;
        boardingPass.OperatingCarrierPnrCode = boarding2.OperatingCarrierPnrCode;
        return boardingPass;
    }
    
}

public class Name
{
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string seat_number { get; set; }
}