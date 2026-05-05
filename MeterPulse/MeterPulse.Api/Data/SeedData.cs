using MeterPulse.Api.Models;
using MeterPulse.Api.Data;

namespace MeterPulse.Api.Data;

public class SeedData
{
    public static void Initialise(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        MeterPulseDbContext _meterPulseDbContext = scope.ServiceProvider.GetRequiredService<MeterPulseDbContext>();
        
        if (_meterPulseDbContext.Companies.Any())
        {
            return;
        }
                
        var company = new Company 
        {
            Name = "United Utilities",
            RegistrationNumber = "02366616",
            Email = "EIRrequests@uuplc.co.uk",
            FinePerBreach = 20000,
        };
        
        _meterPulseDbContext.Companies.Add(company);
        _meterPulseDbContext.SaveChanges();

        var meter = new Meter 
        {
            CompanyId = company.Id,
            Name = "pH",
            Latitude = null,
            Longitude = null,
            WaterBodyType = null,
            WeatherStationReference = null,
        };

        _meterPulseDbContext.Meters.Add(meter);
        _meterPulseDbContext.SaveChanges();

        DateTime BaseDate = new DateTime(2026, 5, 3);

        List<MeterReading> readings = Enumerable.Range(0, 50)
            .Select(i => new MeterReading
            {
                Status = ReadingStatus.Valid,
                Reading = 15,
                Unit = "pH",
                MeterId = meter.Id,
                Timestamp = BaseDate.AddMinutes(i)
            })
            .ToList();

        var permitLimit = new PermitLimit
        {
            MeterId = meter.Id,
            Parameter = "pH",
            MinValue = 6.0,
            MaxValue = 9.0
        };
        
        meter.Readings = readings;
        meter.PermitLimits = [permitLimit];
        company.Meters = [meter];

        _meterPulseDbContext.SaveChanges();
    
    }
}
