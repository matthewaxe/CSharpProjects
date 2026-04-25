using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.DTOs;
namespace MeterPulse.Api.Services;

public class ReadingService : IReadingService
{
    public IActionResult AddReading(CreateReadingDTO dto)
    {
        return new OkObjectResult(null);
    }
}
