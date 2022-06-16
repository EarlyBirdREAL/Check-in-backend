using App.Models;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Check_in.Controllers;

[Route("api/scale")]
[ApiController]


public class ScaleController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(int weight)
    {
        var avgWeight = new ScaleService().GetScaleData(weight);
        var result = ApiResult<Task<int>>.Success(avgWeight);
        return Ok(result);
    }
}