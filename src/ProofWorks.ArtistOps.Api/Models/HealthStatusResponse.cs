namespace ProofWorks.ArtistOps.Api.Models
{
    public class HealthStatusResponse
    {
        public required string ServiceName { get; set; }

        public required ServiceHealthStatus Status { get; set; }

        public required DateTimeOffset Timestamp { get; set; }

        public required string Message { get; set; }

        public required bool IsUnstable { get; set; }

        public required int TotalEventsInWindow { get; set; }

        public required int DegradedEventsInWindow { get; set; }

        public required int FailedEventsInWindow { get; set; }
    }
}
