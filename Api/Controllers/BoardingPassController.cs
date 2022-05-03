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
        [HttpPost(Name = "PostBoardingPass")]
        public BoardingPass Post([FromBody] BoardingPassString boardingPass)
        {
            
            BoardingPass boarding = new Parser().Decode(boardingPass.BoardingPass);
            string fullName = new DbName().GetNames(boarding.OperatingCarrierPnrCode.Trim());
            if (fullName != "Undefined")
            {
                boarding.PassengerName = fullName;
            }
            else
            {
                return new BoardingPass();
            }
            return boarding;
        }
        
    }
}

