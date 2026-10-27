namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Angry Children 2 — pick <c>k</c> packets minimising the sum of |a - b| over all pairs.
/// The best pick is k consecutive packets once sorted. For the window starting at l,
/// Σ_{i&lt;j} (a_j - a_i) = Σ_j a[l + j] · (2j - (k - 1)), and prefix sums of a[i] and
/// i · a[i] give that in O(1) per window. Int128 keeps the intermediate sums exact.
/// O(n log n).
/// https://www.hackerrank.com/challenges/angry-children-2
/// </summary>
public static class AngryChildren2
{
    public static long Solve(int k, IReadOnlyList<long> packets)
    {
        var sorted = packets.ToArray();
        Array.Sort(sorted);

        var sum = new Int128[sorted.Length + 1];
        var weighted = new Int128[sorted.Length + 1];
        for (int i = 0; i < sorted.Length; i++)
        {
            sum[i + 1] = sum[i] + sorted[i];
            weighted[i + 1] = weighted[i] + (Int128)i * sorted[i];
        }

        Int128 best = Int128.MaxValue;

        for (int l = 0; l + k <= sorted.Length; l++)
        {
            Int128 windowSum = sum[l + k] - sum[l];
            Int128 positionWeighted = weighted[l + k] - weighted[l] - l * windowSum;
            Int128 unfairness = 2 * positionWeighted - (k - 1) * windowSum;
            best = Int128.Min(best, unfairness);
        }

        return (long)best;
    }
}
