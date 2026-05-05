namespace MeterPulse.Api.Models;
public class Meter
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public required string Name { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude {get; set; }
    public string? WaterBodyType { get; set; }
    public string? WeatherStationReference { get; set; }
    //Navigation proerties
    public Company? Company { get; set; }
    public WeatherObservation? WeatherObservation { get; set; } 
    public List<MeterReading> Readings { get; set; } = new();
    public List<PermitLimit> PermitLimits{ get; set; } = new();
} 