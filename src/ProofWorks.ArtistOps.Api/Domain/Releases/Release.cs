namespace ProofWorks.ArtistOps.Api.Domain.Releases;

public sealed class Release
{
    private Release(
        Guid id,
        string title,
        ReleaseType releaseType,
        DateOnly targetReleaseDate,
        string? operationalNotes,
        DateTimeOffset createdAt)
    {
        Id = id;
        Title = title;
        ReleaseType = releaseType;
        TargetReleaseDate = targetReleaseDate;
        OperationalNotes = operationalNotes;
        LifecycleState = ReleaseLifecycleState.Draft;
        CreatedAt = createdAt;
        UpdatedAt = createdAt;
    }

    public Guid Id { get; }

    public string Title { get; }

    public ReleaseType ReleaseType { get; }

    public DateOnly TargetReleaseDate { get; }

    public ReleaseLifecycleState LifecycleState { get; }

    public string? OperationalNotes { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }

    public static Release Create(
        string title,
        ReleaseType releaseType,
        DateOnly targetReleaseDate,
        string? operationalNotes = null)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Release title is required.", nameof(title));
        }

        if (!Enum.IsDefined(releaseType))
        {
            throw new ArgumentOutOfRangeException(nameof(releaseType), releaseType, "Release type is not supported.");
        }

        var createdAt = DateTimeOffset.UtcNow;

        return new Release(
            Guid.NewGuid(),
            title.Trim(),
            releaseType,
            targetReleaseDate,
            operationalNotes,
            createdAt);
    }
}
