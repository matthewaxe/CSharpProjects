namespace MeterPulse.Api.Models;

public class WeatherObservation
{ 
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string? StationReference { get; set; }
    public string? Location { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Parameter { get; set; }
    public string? ParameterName { get; set; }
    public int? Period { get; set; }
    public string? UnitName { get; set; }
    public string? Qualifier { get; set; }
    public double? Value { get; set; }
    public string? Source { get; set; }
    public string? RawData { get; set; }
} 