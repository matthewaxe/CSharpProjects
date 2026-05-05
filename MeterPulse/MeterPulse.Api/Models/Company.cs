namespace MeterPulse.Api.Models;
public class Company
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string RegistrationNumber { get; set; }
    public required string Email { get; set; }
    public required decimal FinePerBreach { get; set; }
    public List<Meter> Meters { get; set; } = new();
}

  