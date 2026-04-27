using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.Services;
using MeterPulse.Api.DTOs;

namespace MeterPulse.Api.Controllers;

[ApiController]
[Route("api/meters")]

public class MeterController : ControllerBase
{
    private readonly IMeterService _meterService;

    public MeterController(IMeterService meterService)
    {
        _meterService = meterService;
    }
    [HttpGet("{meterId}/summary")]
    public IActionResult GetSummary([FromRoute] string meterId)
    {
        return _meterService.GetSummary(meterId);
    }
}