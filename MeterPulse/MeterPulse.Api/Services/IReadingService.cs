using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.DTOs;
namespace MeterPulse.Api.Services;

public interface IReadingService
{
   
    IActionResult AddReading(CreateReadingDTO dto);
}