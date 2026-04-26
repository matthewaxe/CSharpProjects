using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.DTOs;
using MeterPulse.Api.Data;
using MeterPulse.Api.Models;
namespace MeterPulse.Api.Services;

public class ReadingService : IReadingService
{
    private readonly MeterPulseDbContext _meterPulseDbContext;
    public ReadingService(MeterPulseDbContext meterPulseDbContext)
    {
        _meterPulseDbContext = meterPulseDbContext;
    }
    public IActionResult AddReading(CreateReadingDTO dto)
    {
        MeterReading meterReading = new MeterReading
        {
            Status = validRange(dto.Reading),
            Reading = dto.Reading,
            Unit = dto.Unit,
            MeterId = dto.MeterId,
            Timestamp = dto.Timestamp,    
        };
        
        _meterPulseDbContext.Add(meterReading);
        _meterPulseDbContext.SaveChanges();

        return new CreatedResult((string?)null, null);
    }
    private ReadingStatus validRange(double reading)
    {
        return (reading < 60 && reading > -70) ? ReadingStatus.Valid : ReadingStatus.Flagged;
    }
}
