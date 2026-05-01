namespace MeterPulse.Api.Models;
public class MeterReading
{
    public int Id { get; set; }
    public required ReadingStatus Status { get; set; } = ReadingStatus.Valid;
    public required double Reading { get; set; }
    public required string Unit { get; set; }
    public required int MeterId { get; set; }
    public required DateTime Timestamp { get; set; }
    //navigation property
    public Meter? Meter { get; set; }
}

 