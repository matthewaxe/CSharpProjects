namespace MeterPulse.Api.DTOs;

public class EaStation
{
    public string? @Id { get; set; }
    public int? Easting { get; set; }
    public string? GridReference { get; set; }
    public string? Label { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<EaStationMeasures> Measures { get; set; }
}