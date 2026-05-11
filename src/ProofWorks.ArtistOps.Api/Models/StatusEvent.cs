namespace ProofWorks.ArtistOps.Api.Models
{
    public class StatusEvent
    {
        public required string ServiceName { get; set; }
        public required HealthSignalType SignalType { get; set; }
        public required DateTimeOffset Timestamp { get; set; }
        public string? Message { get; set; }
    }
}
