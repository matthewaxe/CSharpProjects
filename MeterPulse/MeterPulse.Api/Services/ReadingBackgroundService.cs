using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MeterPulse.Api.Data;

namespace MeterPulse.Api.Services;

public class ReadingBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _iServiceScopeFactory;
    private readonly ILogger<ReadingBackgroundService> _logger;
    public ReadingBackgroundService(IServiceScopeFactory iServiceScopeFactory, ILogger<ReadingBackgroundService> logger)
    {
        _iServiceScopeFactory = iServiceScopeFactory;
        _logger = logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _iServiceScopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MeterPulseDbContext>();
            var query = db.MeterReadings.AsQueryable();

            query = query.Where(r => r.Timestamp >= DateTime.UtcNow.AddSeconds(-60));
            int count = query.Count();
                     
            _logger.LogInformation("Readings in the last 60 seconds: {count}", count);

            await Task.Delay(60000, stoppingToken);
        }
    }
}