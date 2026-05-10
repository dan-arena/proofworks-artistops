using ProofWorks.ArtistOps.Api.Models;

namespace ProofWorks.ArtistOps.Api.Services.Interfaces
{
    public interface IHealthStatusService
    {
        IReadOnlyCollection<StatusEvent> GetHistory();
        StatusEvent GetCurrentStatus();
        bool IsCurrentlyUnstable();
    }
}
