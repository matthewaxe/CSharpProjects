using Microsoft.EntityFrameworkCore;
using MeterPulse.Api.Models;
namespace MeterPulse.Api.Data;

public class MeterPulseDbContext : DbContext
{
    public DbSet<BreachEvent> BreachEvents { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<EvidencePack> EvidencePacks { get; set; }
    public DbSet<Meter> Meters { get; set; }
     public DbSet<MeterReading> MeterReadings { get; set; }
    public DbSet<PermitLimit> PermitLimits { get; set; }
    public DbSet<WeatherObservation> WeatherObservations { get; set; }

    public MeterPulseDbContext(DbContextOptions<MeterPulseDbContext> options) : base(options)
    {
    }
    
}