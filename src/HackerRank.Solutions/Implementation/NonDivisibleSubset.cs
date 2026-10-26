namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Non-Divisible Subset — largest subset in which no two elements sum to a multiple of <c>k</c>.
/// Remainders r and k - r can't coexist, so keep the larger group of each pair; remainder 0
/// (and k/2 when k is even) contributes at most one element.
/// https://www.hackerrank.com/challenges/non-divisible-subset
/// </summary>
public static class NonDivisibleSubset
{
    public static int Solve(int k, IReadOnlyList<int> s)
    {
        var counts = new int[k];
        foreach (var value in s)
        {
            counts[value % k]++;
        }

        int size = Math.Min(counts[0], 1);

        for (int r = 1; r <= k / 2; r++)
        {
            size += r == k - r
                ? Math.Min(counts[r], 1)
                : Math.Max(counts[r], counts[k - r]);
        }

        return size;
    }
}
