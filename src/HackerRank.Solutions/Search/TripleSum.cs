namespace HackerRank.Solutions.Search;

/// <summary>
/// Triple sum — count distinct triplets (p, q, r) with p from a, q from b, r from c, and
/// p ≤ q ≥ r. Deduplicate and sort a and c; then for each distinct q, binary searches count
/// the valid p and r values. O(n log n).
/// https://www.hackerrank.com/challenges/triple-sum
/// </summary>
public static class TripleSum
{
    public static long Solve(IReadOnlyList<int> a, IReadOnlyList<int> b, IReadOnlyList<int> c)
    {
        var sortedA = a.Distinct().Order().ToArray();
        var sortedC = c.Distinct().Order().ToArray();
        long triplets = 0;

        foreach (var q in b.Distinct())
        {
            triplets += (long)CountAtMost(sortedA, q) * CountAtMost(sortedC, q);
        }

        return triplets;
    }

    private static int CountAtMost(int[] sorted, int value)
    {
        int low = 0;
        int high = sorted.Length;
        while (low < high)
        {
            int mid = (low + high) / 2;
            if (sorted[mid] <= value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }
}
