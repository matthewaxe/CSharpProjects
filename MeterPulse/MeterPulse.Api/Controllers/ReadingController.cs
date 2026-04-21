using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.DTOs;
namespace MeterPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReadingsController : ControllerBase
{
    [HttpPost]
    public IActionResult POST(CreateReadingDTO meterReading)
    {
        return Ok();
    }
}