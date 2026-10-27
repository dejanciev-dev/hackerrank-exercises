namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Sherlock and MiniMax — the M in [p, q] whose distance to the nearest array element is
/// largest (the smallest such M on a tie). The best M is either an end of the range or the
/// midpoint of two adjacent sorted elements, so only O(n) candidates need checking, each with
/// a binary search. O(n log n).
/// https://www.hackerrank.com/challenges/sherlock-and-minimax
/// </summary>
public static class SherlockAndMinimax
{
    public static int Solve(IReadOnlyList<int> arr, int p, int q)
    {
        var sorted = arr.ToArray();
        Array.Sort(sorted);

        var candidates = new List<int> { p, q };
        for (int i = 0; i + 1 < sorted.Length; i++)
        {
            // The floor of the midpoint is the smaller of the two equally good choices.
            int mid = (int)(((long)sorted[i] + sorted[i + 1]) / 2);
            if (mid >= p && mid <= q)
            {
                candidates.Add(mid);
            }
        }

        int best = p;
        long bestDistance = -1;

        foreach (var m in candidates.Order())
        {
            long distance = NearestDistance(sorted, m);
            if (distance > bestDistance)
            {
                best = m;
                bestDistance = distance;
            }
        }

        return best;
    }

    private static long NearestDistance(int[] sorted, int m)
    {
        int index = Array.BinarySearch(sorted, m);
        if (index >= 0)
        {
            return 0;
        }

        index = ~index;
        long nearest = long.MaxValue;

        if (index < sorted.Length)
        {
            nearest = (long)sorted[index] - m;
        }

        if (index > 0)
        {
            nearest = Math.Min(nearest, (long)m - sorted[index - 1]);
        }

        return nearest;
    }
}
