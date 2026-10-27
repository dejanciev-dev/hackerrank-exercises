using HackerRank.Solutions.GraphTheory;

namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Kundu and Tree — count triplets of nodes where every pair's path crosses at least one red
/// edge, modulo 1e9+7. Two nodes joined by black edges alone are a bad pair, so group the
/// nodes into black-edge components and pick the three nodes from three different groups.
/// That count is the third elementary symmetric sum of the group sizes. O(n).
/// https://www.hackerrank.com/challenges/kundu-and-tree
/// </summary>
public static class KunduAndTree
{
    private const long Mod = 1_000_000_007;

    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="edges">Each edge as <c>"u v c"</c>, where c is 'r' (red) or 'b' (black).</param>
    public static long Solve(int n, IReadOnlyList<string> edges)
    {
        var set = new DisjointSet(n + 1);
        foreach (var edge in edges)
        {
            var parts = edge.Split(' ');
            if (parts[2] == "b")
            {
                set.Union(int.Parse(parts[0]), int.Parse(parts[1]));
            }
        }

        long e1 = 0, e2 = 0, e3 = 0;
        for (int node = 1; node <= n; node++)
        {
            if (set.Find(node) != node)
            {
                continue;
            }

            long size = set.SizeOf(node);
            e3 = (e3 + e2 * size) % Mod;
            e2 = (e2 + e1 * size) % Mod;
            e1 = (e1 + size) % Mod;
        }

        return e3;
    }
}
