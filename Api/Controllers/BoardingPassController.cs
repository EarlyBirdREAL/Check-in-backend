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

        public BoardingPassController(IDbName dbName)
        {
            _dbName = dbName;
        }
        [HttpPost(Name = "PostBoardingPass")]
        public BoardingPass Post([FromBody] BoardingPassString boardingPass)
        {
            
            BoardingPass boarding = new Parser().Decode(boardingPass.BoardingPass);
            string fullName = _dbName.GetNames(boarding.OperatingCarrierPnrCode);
            if (fullName != "Undefined")
            {
                boarding.PassengerName = fullName;
            }
            
            return boarding;
        }
    }
}

