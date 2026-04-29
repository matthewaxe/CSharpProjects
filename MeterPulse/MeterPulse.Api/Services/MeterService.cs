using Microsoft.AspNetCore.Mvc;
using MeterPulse.Api.Data;
using MeterPulse.Api.DTOs;
using MeterPulse.Api.Models;

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

        if (!query.Any())
        {
            return new NotFoundResult();
        }

        double average = query.Average(r => r.Reading);
        double min = query.Min(r => r.Reading);
        double max = query.Max(r => r.Reading);
        double count = query.Count();
        int flagged = query.Count(r => r.Status == ReadingStatus.Flagged);
        double percentageFlagged = flagged / count * 100;

        MeterSummaryDTO meterSummary = new MeterSummaryDTO{};

        meterSummary.Average = average;
        meterSummary.Minimum = min;
        meterSummary.Maximum = max;
        meterSummary.Count = count;
        meterSummary.PercentageFlagged = percentageFlagged;

        return new OkObjectResult(meterSummary);
    }
}