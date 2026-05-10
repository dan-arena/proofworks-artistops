using ProofWorks.ArtistOps.Api.Models;
using ProofWorks.ArtistOps.Api.Services.Interfaces;
using ProofWorks.ArtistOps.Api.Utilities;

namespace ProofWorks.ArtistOps.Api.Services;

public class MockChaosHealthService : IHealthStatusService
{
    private readonly List<StatusEvent> _statusEvents = [];

    private readonly Random _random = new();

    public MockChaosHealthService()
    {
        SeedInitialEvents();
    }

    public IReadOnlyCollection<StatusEvent> GetHistory()
    {
        return _statusEvents
            .OrderByDescending(e => e.Timestamp)
            .ToList();
    }

    public StatusEvent GetCurrentStatus()
    {
        GenerateRandomEvent();

        return _statusEvents
            .OrderByDescending(e => e.Timestamp)
            .First();
    }

    public bool IsCurrentlyUnstable()
    {
        return _statusEvents.HasThresholdWithinTrailingWindow(
            e => e.Timestamp,
            e => e.Status is ServiceStatus.Warning or ServiceStatus.Unhealthy,
            TimeSpan.FromMinutes(5),
            3,
            DateTimeOffset.UtcNow);
    }

    private void GenerateRandomEvent()
    {
        var roll = _random.Next(1, 101);

        var status = roll switch
        {
            <= 70 => ServiceStatus.Healthy,
            <= 90 => ServiceStatus.Warning,
            _ => ServiceStatus.Unhealthy
        };

        _statusEvents.Add(new StatusEvent
        {
            ServiceName = "ArtistOps API",
            Status = status,
            Timestamp = DateTimeOffset.UtcNow,
            Message = status switch
            {
                ServiceStatus.Healthy => "All systems operational",
                ServiceStatus.Warning => "Elevated latency detected",
                ServiceStatus.Unhealthy => "Service degradation detected",
                _ => "Unknown state"
            }
        });

        TrimHistory();
    }

    private void TrimHistory()
    {
        var cutoff = DateTimeOffset.UtcNow.AddMinutes(-30);

        _statusEvents.RemoveAll(e => e.Timestamp < cutoff);
    }

    private void SeedInitialEvents()
    {
        for (int i = 0; i < 10; i++)
        {
            GenerateRandomEvent();
        }
    }
}
