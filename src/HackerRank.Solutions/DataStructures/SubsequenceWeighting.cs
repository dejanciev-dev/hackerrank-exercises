namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Subsequence Weighting — the heaviest strictly increasing subsequence, where each element
/// has its own weight. Compress the values and keep a Fenwick tree of prefix maxima. The best
/// subsequence ending at element i weighs w[i] plus the best ending at any smaller value.
/// O(n log n).
/// https://www.hackerrank.com/challenges/subsequence-weighting
/// </summary>
public static class SubsequenceWeighting
{
    public static long Solve(IReadOnlyList<int> a, IReadOnlyList<int> w)
    {
        var ranks = a.Distinct().Order().Select((value, i) => (value, i)).ToDictionary(p => p.value, p => p.i + 1);
        var fenwick = new long[ranks.Count + 1];
        long best = 0;

        for (int i = 0; i < a.Count; i++)
        {
            int rank = ranks[a[i]];

            long before = 0;
            for (int j = rank - 1; j > 0; j -= j & -j)
            {
                before = Math.Max(before, fenwick[j]);
            }

            long ending = before + w[i];
            best = Math.Max(best, ending);

            for (int j = rank; j < fenwick.Length; j += j & -j)
            {
                fenwick[j] = Math.Max(fenwick[j], ending);
            }
        }

        return best;
    }
}
