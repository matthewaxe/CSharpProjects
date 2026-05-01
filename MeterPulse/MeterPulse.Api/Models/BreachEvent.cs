namespace MeterPulse.Api.Models;

public class BreachEvent
{
    public int Id { get; set; }
    public int MeterId { get; set; }
    public int? PermitLimitId { get; set; }
    public required string Parameter { get; set; }
    public required DateTime StartTimestamp { get; set; }
    public required DateTime EndTimestamp { get; set; }
    public double DurationMinutes { get; set; }
    public decimal FineAmount { get; set; }
    public Guid? EvidencePackId { get; set; }
    //navigation properties
    public EvidencePack? EvidencePack { get; set; }
    public Meter? Meter { get; set; }
    public PermitLimit? PermitLimit { get; set; }
}