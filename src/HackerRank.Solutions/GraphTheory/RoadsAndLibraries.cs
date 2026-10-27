namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Roads and Libraries — cheapest way to give every city library access. If a road costs at
/// least as much as a library, build a library everywhere; otherwise each connected component
/// needs one library plus a spanning tree of roads. Union-find, O(m · α(n)).
/// https://www.hackerrank.com/challenges/torque-and-development
/// </summary>
public static class RoadsAndLibraries
{
    public static long Solve(int n, int cLib, int cRoad, IReadOnlyList<IReadOnlyList<int>> cities)
    {
        if (cRoad >= cLib)
        {
            return (long)n * cLib;
        }

        var set = new DisjointSet(n + 1);
        int roads = 0;

        foreach (var road in cities)
        {
            if (set.Union(road[0], road[1]))
            {
                roads++;
            }
        }

        int components = n - roads;
        return (long)components * cLib + (long)roads * cRoad;
    }
}
