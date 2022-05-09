using NUnit.Framework;
using App.Services;
using Core.Entities;

namespace UnitTests;

public class TestParser
{
    private Parser _parser;
    private string _code;
    
    [SetUp]
    public void Setup()
    {
        _parser = new Parser();
        
        _code = "M1PEETERS/GEORDI      ESNT7OE AMSFRALH 0989 198M019B0067 35D>6180WW8197BLH              2A01651697905940 LH                        N*30600000K09         ";
    }

    [Test]
    public void TestFormatCode()
    {
        var boardingPass = _parser.Decode(_code);
        
        Assert.AreEqual(boardingPass.FormatCode, "M");
    }    
    
    [Test]
    public void TestLegs()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.Legs, 1);
    }  
    
    [Test]
    public void TestPassengerName()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.PassengerName, "PEETERS/GEORDI");
    }

    [Test]
    public void TestOperatingCarrierPnrCode()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.OperatingCarrierPnrCode, "SNT7OE");
    }
    
    [Test]
    public void TestFromCityAirportCode()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.FromCityAirportCode, "AMS");
    }    
    
    [Test]
    public void TestToCityAirportCode()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.ToCityAirportCode, "FRA");
    }    
    
    [Test]
    public void TestOperatingCarrierDesignator()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.OperatingCarrierDesignator, "LH");
    }   
    
    [Test]
    public void TestFlightNumber()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.FlightNumber, "0989");
    }    
    
    [Test]
    public void TestDateOfFlight()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.DateOfFlight, "198");
    }   
    
    [Test]
    public void TestCompartmentCode()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.CompartmentCode, "M");
    }   
    
    [Test]
    public void TestSeatNumber()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.SeatNumber, "019B");
    }   
    
    [Test]
    public void TestCheckInSequenceNumber()
    {
        var boardingPass = _parser.Decode(_code);

        Assert.AreEqual(boardingPass.CheckInSequenceNumber, "0067");
    }
}