using Microsoft.AspNetCore.Mvc;
namespace MeterPulse.Api.Services;

public interface IMeterService
{
    IActionResult GetSummary(string meterId);
}

