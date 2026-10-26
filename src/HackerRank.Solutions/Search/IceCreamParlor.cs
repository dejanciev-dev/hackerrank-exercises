namespace HackerRank.Solutions.Search;

/// <summary>
/// Ice Cream Parlor — 1-based indices (ascending) of the two flavors whose costs add up to
/// <c>m</c>. A dictionary of seen costs finds the pair in one pass (two-sum).
/// https://www.hackerrank.com/challenges/icecream-parlor
/// </summary>
public static class IceCreamParlor
{
    public static int[] Solve(int m, IReadOnlyList<int> cost)
    {
        var seen = new Dictionary<int, int>(); // cost -> 1-based index

        for (int i = 0; i < cost.Count; i++)
        {
            if (seen.TryGetValue(m - cost[i], out var partner))
            {
                return [partner, i + 1];
            }

            seen.TryAdd(cost[i], i + 1);
        }

        return [];
    }
}
