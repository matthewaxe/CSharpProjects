using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MeterPulse.Api.Data;
using MeterPulse.Api.DTOs;
using MeterPulse.Api.Models;
using System.Data.Common;

namespace MeterPulse.Api.Services;

public class WeatherIngestionService : BackgroundService
{
    private readonly IServiceScopeFactory _iServiceScopeFactory;
    private readonly ILogger<WeatherIngestionService> _logger;
    private readonly IHttpClientFactory _iHttpClientFactory;
    public WeatherIngestionService(IServiceScopeFactory iServiceScopeFactory, ILogger<WeatherIngestionService> logger, IHttpClientFactory iHttpClientFactory)
    {
        _iServiceScopeFactory = iServiceScopeFactory;
        _logger = logger;
        _iHttpClientFactory = iHttpClientFactory;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _iServiceScopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MeterPulseDbContext>();
            var weatherStationReferences = db.Meters.Where(r => r.WeatherStationReference != null).Select(r => r.WeatherStationReference).Distinct().ToList();

            foreach(string? stationReference in weatherStationReferences)
            {
                if (stationReference == null){ continue; }

                var httpClient = _iHttpClientFactory.CreateClient("EnvironmentData");
                var httpResponseMessage = 
                    await httpClient.GetAsync($"https://environment.data.gov.uk/flood-monitoring/data/readings?parameter=rainfall&stationReference={stationReference}&today");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream = 
                        await httpResponseMessage.Content.ReadAsStreamAsync();
                    
                    EaReadingResponseDTO? eaReadingResponse = await JsonSerializer.DeserializeAsync<EaReadingResponseDTO>(contentStream);

                    if (eaReadingResponse == null) { continue; }
                    
                    foreach (EaReadingsDTO eaReading in eaReadingResponse.Items ?? [])
                    {
                        if (!db.WeatherObservations.Any(r => r.StationReference == stationReference && r.Timestamp == eaReading.Timestamp))
                        {
                            WeatherObservation weatherObservation = new WeatherObservation
                            {
                                Timestamp = eaReading.Timestamp,
                                StationReference = stationReference,
                                Value = eaReading.Value,
                            };
                            db.Add(weatherObservation);
                        }
                    }
                    db.SaveChanges();
                }
            }
            
            await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken); 
        } 
    }
}