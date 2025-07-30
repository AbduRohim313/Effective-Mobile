using Effective_Mobile.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Effective_Mobile.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private IService _service;

    public HomeController(IService service)
    {
        _service = service;
    }

    [HttpPost("loadFile")]
    public async Task<IActionResult> LoadFile([FromForm] IFormFile file)
    {
        var response = await _service.LoadFile(file);
        if (response.Status == false)
            return BadRequest(response.Message);
        return Ok(response.Message);
    }

    [HttpGet("reklama")]
    public async Task<IActionResult> Reklama([FromQuery] string location)
    {
        var response = _service.Reklama(location);
        if (response == null)
            return BadRequest();
        return Ok(response.Result);
    }
}