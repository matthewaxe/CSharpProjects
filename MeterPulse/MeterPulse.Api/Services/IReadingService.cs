using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.DTOs;
namespace MeterPulse.Api.Services;

public interface IReadingService
{
   
    IActionResult AddReading(CreateReadingDTO dto);
    IActionResult Get(string? meterId, DateTime? from, DateTime? to);
    IActionResult GetAnomalies();
}