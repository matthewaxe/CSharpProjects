using System.Text.Json.Serialization;

namespace MeterPulse.Api.DTOs;

public class EaReadingsDTO
{
    public string? @Id { get; set; }
    [JsonPropertyName("dateTime")]
    public DateTime Timestamp { get; set; }
    public string? Measure { get; set; }
    public double Value { get; set; }
}
