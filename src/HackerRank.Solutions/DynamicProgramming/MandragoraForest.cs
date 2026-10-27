namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// The Mandragora Forest — each mandragora is either eaten (+1 strength) or battled (+strength
/// x health points). It's always best to eat the weakest ones and battle the rest, so sort and
/// try every split point using suffix sums: max over i of (i + 1) · sum(h[i..]). O(n log n).
/// https://www.hackerrank.com/challenges/mandragora
/// </summary>
public static class MandragoraForest
{
    public static long Solve(IReadOnlyList<int> h)
    {
        var sorted = h.ToArray();
        Array.Sort(sorted);

        long remaining = 0;
        long best = 0;

        for (int i = sorted.Length - 1; i >= 0; i--)
        {
            remaining += sorted[i];
            best = Math.Max(best, (i + 1) * remaining);
        }

        return best;
    }
}
