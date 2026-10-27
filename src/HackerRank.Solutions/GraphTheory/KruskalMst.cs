namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Kruskal (MST): Really Special Subtree — total weight of a minimum spanning tree. Sort the
/// edges by weight and keep each one that joins two components. O(m log m).
/// https://www.hackerrank.com/challenges/kruskalmstrsub
/// </summary>
public static class KruskalMst
{
    /// <param name="nodes">Number of nodes, labelled 1..nodes.</param>
    /// <param name="edges">Each edge as <c>[from, to, weight]</c>.</param>
    public static int Solve(int nodes, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        var set = new DisjointSet(nodes + 1);
        int total = 0;

        foreach (var edge in edges.OrderBy(e => e[2]))
        {
            if (set.Union(edge[0], edge[1]))
            {
                total += edge[2];
            }
        }

        return total;
    }
}
