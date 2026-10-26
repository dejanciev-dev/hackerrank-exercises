namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Minimum Distances — smallest distance between two equal elements, or -1 if all are distinct.
/// https://www.hackerrank.com/challenges/minimum-distances
/// </summary>
public static class MinimumDistances
{
    public static int Solve(IReadOnlyList<int> a)
    {
        var lastSeen = new Dictionary<int, int>();
        int best = int.MaxValue;

        for (int i = 0; i < a.Count; i++)
        {
            if (lastSeen.TryGetValue(a[i], out var previous))
            {
                best = Math.Min(best, i - previous);
            }

            lastSeen[a[i]] = i;
        }

        return best == int.MaxValue ? -1 : best;
    }
}
