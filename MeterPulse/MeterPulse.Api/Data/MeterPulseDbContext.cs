using Microsoft.EntityFrameworkCore;
using MeterPulse.Api.Models;
namespace MeterPulse.Api.Data;

public class MeterPulseDbContext : DbContext
{
    public DbSet<MeterReading> MeterReadings { get; set; }

    public MeterPulseDbContext(DbContextOptions<MeterPulseDbContext> options) : base(options)
    {
    }
    
}