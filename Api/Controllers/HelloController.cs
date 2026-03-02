using Microsoft.AspNetCore.Mvc;

namespace DotnetWebApi.Controllers;


public class HelloController : BaseController
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
