namespace MeterPulse.Api.Models;

public class PermitLimit
{
    public int Id { get; set; }
    public int MeterId { get; set; }
    public required string Parameter { get; set; }
    public double? MinValue { get; set; }
    public double? MaxValue {get; set; }
    public string? WeatherCondition { get; set; }
    public double? WeatherThresholdMm { get; set; }
    public decimal? FineOverride { get; set; }
    //naigation property
    public Meter? Meter { get; set; }
}  