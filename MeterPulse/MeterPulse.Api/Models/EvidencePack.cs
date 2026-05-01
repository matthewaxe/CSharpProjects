using System.ComponentModel.DataAnnotations.Schema;
namespace MeterPulse.Api.Models;

public class EvidencePack
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? FilePath { get; set; }
    public EvidencePackStatus Status { get; set; } = EvidencePackStatus.Pending;
    public List<BreachEvent> BreachEvents { get; set; } = new();
}