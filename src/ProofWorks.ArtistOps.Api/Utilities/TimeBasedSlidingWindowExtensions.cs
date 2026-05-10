using System;
using System.Collections.Generic;
using System.Linq;

namespace ProofWorks.ArtistOps.Api.Utilities;

public static class TimeBasedSlidingWindowExtensions
{
    public static bool HasThresholdWithinTrailingWindow<T>(
        this IEnumerable<T>? items,
        Func<T, DateTimeOffset> timestampSelector,
        Func<T, bool> matchSelector,
        TimeSpan windowSize,
        int threshold,
        DateTimeOffset windowEnd)
    {
        if (timestampSelector == null)
            throw new ArgumentNullException(nameof(timestampSelector));

        if (matchSelector == null)
            throw new ArgumentNullException(nameof(matchSelector));

        if (windowSize <= TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(windowSize));

        if (threshold <= 0)
            throw new ArgumentOutOfRangeException(nameof(threshold));

        if (items == null)
            return false;

        var windowStart = windowEnd - windowSize;

        var matchCount = items.Count(item =>
        {
            var timestamp = timestampSelector(item);

            return timestamp >= windowStart
                && timestamp <= windowEnd
                && matchSelector(item);
        });

        return matchCount >= threshold;
    }
}