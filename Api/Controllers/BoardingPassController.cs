using System.Text.Json.Nodes;
using Core.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Check_in.Controllers
{
    [Route("api/BoardingPassInfo")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost(Name = "PostBoardingPassInfo")]
        public BoardingPass Post([FromBody] CodeString code)
        {
            return new Parser().Decode(code.Code);
        }
    }
}

