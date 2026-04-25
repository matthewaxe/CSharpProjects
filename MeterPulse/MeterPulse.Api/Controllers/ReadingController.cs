using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.DTOs;
using MeterPulse.Api.Services;
namespace MeterPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReadingsController : ControllerBase
{
    private readonly IReadingService _readingService;

    public ReadingsController(IReadingService readingService)
    {
        _readingService = readingService;
    }
    [HttpPost]
    public IActionResult POST(CreateReadingDTO meterReading)
    {
        return _readingService.AddReading(meterReading);
    }
}