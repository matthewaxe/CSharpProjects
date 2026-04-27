using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.Data;

namespace MeterPulse.Api.Services;
public class MeterService : IMeterService
{
    private readonly MeterPulseDbContext _meterPulseDbContext;

    public MeterService(MeterPulseDbContext meterPulseDbContext)
    {
        _meterPulseDbContext = meterPulseDbContext; 
    }
    
    public IActionResult GetSummary(string meterId)
    {
        var query = _meterPulseDbContext.MeterReadings.AsQueryable();

        query = query.Where(r => r.MeterId == meterId);
    }
}