namespace MeterPulse.Api.DTOs;
public class CreateReadingDTO
{
    public required double Reading { get; set; }
    public required string Unit { get; set; }
    public required string MeterId { get; set; }
    public required DateTime Timestamp { get; set; }
}