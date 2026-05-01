namespace MeterPulse.Api.Models;
public class Meter
{
    public int Id { get; set; }
    //Derived from "public Company Company" which EF Ecore uses to infer the value from the database
    public int CompanyId { get; set; }
    public required string Name { get; set; }
    public required string Latitiude { get; set; }
    public required double Longitude {get; set; }
    public required string WaterBodyType { get; set; }
    public string? WeatherStationReference { get; set; }
    //Navigation proerties
    public Company? Company { get; set; }
    public WeatherObservation WeatherObservation { get; set; }
    public List<MeterReading> Readings { get; set; } = new();
    public List<PermitLimit> PermitLimits{ get; set; } = new();
}