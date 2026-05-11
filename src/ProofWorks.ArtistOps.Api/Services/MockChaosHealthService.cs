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

    public HealthStatusResponse GetCurrentStatus()
    {
        GenerateRandomEvent();

        var now = DateTimeOffset.UtcNow;
        var windowStart = now.AddMinutes(-5);

        var eventsInWindow = _statusEvents
            .Where(e => e.Timestamp >= windowStart && e.Timestamp <= now)
            .ToList();

        var degradedEvents = eventsInWindow.Count(e => e.SignalType == HealthSignalType.Degraded);
        var failedEvents = eventsInWindow.Count(e => e.SignalType == HealthSignalType.Failed);

        var latestSignal = _statusEvents
            .OrderByDescending(e => e.Timestamp)
            .First()
            .SignalType;

        var status = DetermineStatus(latestSignal, eventsInWindow.Count, degradedEvents, failedEvents);

        return new HealthStatusResponse
        {
            ServiceName = "ArtistOps API",
            Status = status,
            Timestamp = now,
            Message = GetStatusMessage(status),
            IsUnstable = status is ServiceHealthStatus.AtRisk or ServiceHealthStatus.Failure,
            TotalEventsInWindow = eventsInWindow.Count,
            DegradedEventsInWindow = degradedEvents,
            FailedEventsInWindow = failedEvents
        };
    }

    public bool IsCurrentlyUnstable()
    {
        return _statusEvents.HasThresholdWithinTrailingWindow(
            e => e.Timestamp,
            e => e.SignalType is HealthSignalType.Degraded or HealthSignalType.Failed,
            TimeSpan.FromMinutes(5),
            3,
            DateTimeOffset.UtcNow);
    }

    private void GenerateRandomEvent()
    {
        var roll = _random.Next(1, 101);

        var signalType = roll switch
        {
            <= 80 => HealthSignalType.Healthy,
            <= 95 => HealthSignalType.Degraded,
            _ => HealthSignalType.Failed
        };

        _statusEvents.Add(new StatusEvent
        {
            ServiceName = "ArtistOps API",
            SignalType = signalType,
            Timestamp = DateTimeOffset.UtcNow,
            Message = signalType switch
            {
                HealthSignalType.Healthy => "API responded normally",
                HealthSignalType.Degraded => "Elevated latency detected",
                HealthSignalType.Failed => "API request failed",
                _ => "Unknown signal"
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

    private static ServiceHealthStatus DetermineStatus(
    HealthSignalType latestSignal,
    int totalEvents,
    int degradedEvents,
    int failedEvents)
    {
        if (latestSignal == HealthSignalType.Failed)
            return ServiceHealthStatus.Failure;

        if (totalEvents > 0 && (double)(degradedEvents + failedEvents) / totalEvents >= 0.30)
            return ServiceHealthStatus.AtRisk;

        if (latestSignal == HealthSignalType.Degraded)
            return ServiceHealthStatus.Warning;

        return ServiceHealthStatus.Healthy;
    }

    private static string GetStatusMessage(ServiceHealthStatus status)
    {
        return status switch
        {
            ServiceHealthStatus.Healthy => "API is running normally",
            ServiceHealthStatus.Warning => "Temporary degraded signal detected",
            ServiceHealthStatus.AtRisk => "Recent degraded signal pattern indicates elevated outage risk",
            ServiceHealthStatus.Failure => "Repeated failures indicate the API is not operational",
            ServiceHealthStatus.Unavailable => "Service is intentionally unavailable",
            _ => "Unknown service state"
        };
    }
}
