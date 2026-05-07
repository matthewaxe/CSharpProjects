using System.Text.Json.Serialization;

namespace MeterPulse.Api.DTOs;

public class EaStation
{
    public string? @Id { get; set; }
    public int? Easting { get; set; }
    public string? GridReference { get; set; }
    public string? Label { get; set; }
    [JsonPropertyName("lat")]
    public double Latitude { get; set; }
    [JsonPropertyName("long")]
    public double Longitude { get; set; }
    public List<EaStationMeasures>? Measures { get; set; }
    public string? Northing { get; set; }
    public string? Notation { get; set; }
    public string? StationReference { get; set; }
}