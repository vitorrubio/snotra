using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public UrlController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return StatusCode(505, new   {
                            Mensagem="not found sei lá procura no ipiranga", 
                            Saldo = "100" 
                        });
    }
}
