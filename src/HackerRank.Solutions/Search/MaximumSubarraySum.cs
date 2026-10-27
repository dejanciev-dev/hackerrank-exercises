namespace HackerRank.Solutions.Search;

/// <summary>
/// Maximum Subarray Sum — the largest value of (sum of a contiguous subarray) mod <c>m</c>.
/// A subarray's sum mod m is (prefix[j] - prefix[i]) mod m; it beats prefix[j] alone only when
/// prefix[i] > prefix[j], and is then largest for the smallest such prefix[i]. Earlier prefixes
/// live in a sorted set, so each lookup is O(log n): O(n log n) overall.
/// https://www.hackerrank.com/challenges/maximum-subarray-sum
/// </summary>
public static class MaximumSubarraySum
{
    public static long Solve(IReadOnlyList<long> a, long m)
    {
        var seen = new SortedSet<long>();
        long prefix = 0;
        long best = 0;

        foreach (var value in a)
        {
            prefix = (prefix + value % m) % m;
            best = Math.Max(best, prefix);

            var larger = seen.GetViewBetween(prefix + 1, m);
            if (larger.Count > 0)
            {
                best = Math.Max(best, prefix - larger.Min + m);
            }

            seen.Add(prefix);
        }

        return best;
    }
}
