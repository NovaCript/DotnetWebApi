using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string GetHelloWorldText()
    {
        return "Hello world!";
    }
}