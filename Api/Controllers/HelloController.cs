using Microsoft.AspNetCore.Mvc;

namespace DotnetWebApi.Controllers;


[ApiController]
[Route("api/v1/[Controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello, World!" });
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        return Ok(new { Message = $"Hello, {name}!" });
    }
}
