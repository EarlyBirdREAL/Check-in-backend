using Core.Entities;
using App.Services;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Check_in.Controllers
{
    
    [Route("api/BoardingPass")]
    [ApiController]
    public class BoardingPassController : ControllerBase
    {

        private readonly IDbName _dbName;

        private BoardingPassController(IDbName dbName)
        {
            _dbName = dbName;
        }
        /// <summary>
        /// This is the POST request for the boarding pass, this then gets send to the parser to parse the string, this will return a BoardingPass object.
        /// This object will then be send to the database to get the full name of the passenger.
        /// Finally this name gets put in the object and then send back to the requester.
        /// </summary>
        /// <param name="boardingPass">BoardingPassString</param>
        /// <returns><b>boarding</b> - BoardingPass</returns>
        [HttpPost(Name = "PostBoardingPass")]
        public BoardingPass Post([FromBody] BoardingPassString boardingPass)
        {
            BoardingPass boarding;
            boarding = new Parser().Decode(boardingPass.BoardingPass);
            string fullName = _dbName.GetNames(boarding.OperatingCarrierPnrCode);
            if (fullName != "Undefined")
            {
                boarding.PassengerName = fullName;
            }
            
            return boarding;
        }
    }
}

