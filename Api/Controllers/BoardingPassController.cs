using Core.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Check_in.Controllers
{
    [Route("api/BoardingPass")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost(Name = "PostBoardingPass")]
        public BoardingPass Post([FromBody] BoardingPassString boardingPass)
        {
            return new Parser().Decode(boardingPass.BoardingPass);
        }
    }
}

