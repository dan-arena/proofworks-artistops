using ProofWorks.ArtistOps.Api.Domain.Releases;

namespace ProofWorks.ArtistOps.Api.Tests.Domain.Releases;

public static class ReleaseTests
{
    public static int Main()
    {
        Should_Create_Release_When_Input_Is_Valid();
        Should_Default_Release_To_Draft();
        Should_Define_Approved_ReleaseType_Values();
        Should_Define_Approved_ReleaseLifecycleState_Values();

        return 0;
    }

    private static void Should_Create_Release_When_Input_Is_Valid()
    {
        var release = Release.Create(
            "First Single",
            ReleaseType.Single,
            new DateOnly(2026, 6, 1),
            "Initial release planning.");

        AssertNotEqual(Guid.Empty, release.Id, nameof(release.Id));
        AssertEqual("First Single", release.Title, nameof(release.Title));
        AssertEqual(ReleaseType.Single, release.ReleaseType, nameof(release.ReleaseType));
        AssertEqual(new DateOnly(2026, 6, 1), release.TargetReleaseDate, nameof(release.TargetReleaseDate));
        AssertEqual("Initial release planning.", release.OperationalNotes, nameof(release.OperationalNotes));
        AssertEqual(ReleaseLifecycleState.Draft, release.LifecycleState, nameof(release.LifecycleState));
        AssertTrue(release.CreatedAt != default, nameof(release.CreatedAt));
        AssertEqual(release.CreatedAt, release.UpdatedAt, nameof(release.UpdatedAt));
    }

    private static void Should_Default_Release_To_Draft()
    {
        var release = Release.Create(
            "Release Plan",
            ReleaseType.Album,
            new DateOnly(2026, 7, 15));

        AssertEqual(ReleaseLifecycleState.Draft, release.LifecycleState, nameof(release.LifecycleState));
    }

    private static void Should_Define_Approved_ReleaseType_Values()
    {
        var expectedValues = new[]
        {
            nameof(ReleaseType.Single),
            nameof(ReleaseType.EP),
            nameof(ReleaseType.Album),
            nameof(ReleaseType.LiveRelease),
            nameof(ReleaseType.Other)
        };

        AssertSequenceEqual(expectedValues, Enum.GetNames<ReleaseType>(), nameof(ReleaseType));
    }

    private static void Should_Define_Approved_ReleaseLifecycleState_Values()
    {
        var expectedValues = new[]
        {
            nameof(ReleaseLifecycleState.Draft),
            nameof(ReleaseLifecycleState.Active),
            nameof(ReleaseLifecycleState.AtRisk),
            nameof(ReleaseLifecycleState.Ready),
            nameof(ReleaseLifecycleState.Released),
            nameof(ReleaseLifecycleState.Cancelled)
        };

        AssertSequenceEqual(expectedValues, Enum.GetNames<ReleaseLifecycleState>(), nameof(ReleaseLifecycleState));
    }

    private static void AssertEqual<T>(T expected, T actual, string memberName)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
        {
            throw new InvalidOperationException($"{memberName}: expected {expected}, got {actual}.");
        }
    }

    private static void AssertNotEqual<T>(T notExpected, T actual, string memberName)
    {
        if (EqualityComparer<T>.Default.Equals(notExpected, actual))
        {
            throw new InvalidOperationException($"{memberName}: value must not be {notExpected}.");
        }
    }

    private static void AssertTrue(bool condition, string memberName)
    {
        if (!condition)
        {
            throw new InvalidOperationException($"{memberName}: expected condition to be true.");
        }
    }

    private static void AssertSequenceEqual<T>(IReadOnlyList<T> expected, IReadOnlyList<T> actual, string memberName)
    {
        if (!expected.SequenceEqual(actual))
        {
            throw new InvalidOperationException(
                $"{memberName}: expected [{string.Join(", ", expected)}], got [{string.Join(", ", actual)}].");
        }
    }
}
