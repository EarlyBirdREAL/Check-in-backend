using NUnit.Framework;
using App.Services;
using Core.Entities;

namespace UnitTests;

public class TestParser
{
    private Parser _parser;
    private BoardingPass _boardingPass;
    
    [SetUp]
    public void Setup()
    {
        _parser = new Parser();
        
        var code =
            "M1PEETERS/GEORDI      ESNT7OE AMSFRALH 0989 198M019B0067 35D>6180WW8197BLH              2A01651697905940 LH                        N*30600000K09         ";

        _boardingPass = _parser.Decode(code);
    }

    [Test]
    public void TestFormatCode()
    {
        Assert.AreEqual(_boardingPass.FormatCode, "M");
    }    
    
    [Test]
    public void TestLegs()
    {
        Assert.AreEqual(_boardingPass.Legs, 1);
    }  
    
    [Test]
    public void TestPassengerName()
    {
        Assert.AreEqual(_boardingPass.PassengerName, "PEETERS/GEORDI");
    }

    [Test]
    public void TestOperatingCarrierPnrCode()
    {
        Assert.AreEqual(_boardingPass.OperatingCarrierPnrCode, "SNT7OE");
    }
    
    [Test]
    public void TestFromCityAirportCode()
    {
        Assert.AreEqual(_boardingPass.FromCityAirportCode, "AMS");
    }    
    
    [Test]
    public void TestToCityAirportCode()
    {
        Assert.AreEqual(_boardingPass.ToCityAirportCode, "FRA");
    }    
    
    [Test]
    public void TestOperatingCarrierDesignator()
    {
        Assert.AreEqual(_boardingPass.OperatingCarrierDesignator, "LH");
    }   
    
    [Test]
    public void TestFlightNumber()
    {
        Assert.AreEqual(_boardingPass.FlightNumber, "0989");
    }    
    
    [Test]
    public void TestDateOfFlight()
    {
        Assert.AreEqual(_boardingPass.DateOfFlight, "198");
    }   
    
    [Test]
    public void TestCompartmentCode()
    {
        Assert.AreEqual(_boardingPass.CompartmentCode, "M");
    }   
    
    [Test]
    public void TestSeatNumber()
    {
        Assert.AreEqual(_boardingPass.SeatNumber, "019B");
    }   
    
    [Test]
    public void TestCheckInSequenceNumber()
    {
        Assert.AreEqual(_boardingPass.CheckInSequenceNumber, "0067");
    }
}