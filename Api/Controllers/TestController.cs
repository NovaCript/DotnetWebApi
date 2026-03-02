using Microsoft.AspNetCore.Mvc;


public class TestController : BaseController
{
    [HttpGet]
    public string GetHelloWorldText()
    {
        return "Hello world!";
    }
}