using ProofWorks.ArtistOps.Api.Models;

namespace ProofWorks.ArtistOps.Api.Services.Interfaces
{
    public interface IHealthStatusService
    {
        IReadOnlyCollection<StatusEvent> GetHistory();
        HealthStatusResponse GetCurrentStatus();
        bool IsCurrentlyUnstable();
    }
}
