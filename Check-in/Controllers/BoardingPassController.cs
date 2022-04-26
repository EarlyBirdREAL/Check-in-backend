using System.Text.Json.Nodes;
using Check_in.Models;
using Check_in.Services;
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

