namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Deforestation — players take turns cutting an edge of a tree rooted at node 1, and the
/// part no longer connected to the root falls away; whoever can't cut loses. This is Green
/// Hackenbush on a tree. By the colon principle, a node's Grundy number is the XOR over its
/// children of (child's Grundy + 1). Alice, who moves first, wins when the root's is
/// non-zero. O(n).
/// https://www.hackerrank.com/challenges/deforestation-1
/// </summary>
public static class Deforestation
{
    /// <param name="n">Number of nodes, labelled 1..n; node 1 is the root.</param>
    /// <param name="edges">Undirected tree edges.</param>
    public static string Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        var adjacency = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            adjacency[i] = [];
        }

        foreach (var edge in edges)
        {
            adjacency[edge[0]].Add(edge[1]);
            adjacency[edge[1]].Add(edge[0]);
        }

        var parent = new int[n + 1];
        var order = new List<int>(n) { 1 };
        for (int i = 0; i < order.Count; i++)
        {
            foreach (var next in adjacency[order[i]])
            {
                if (next != parent[order[i]])
                {
                    parent[next] = order[i];
                    order.Add(next);
                }
            }
        }

        var grundy = new int[n + 1];
        for (int i = order.Count - 1; i > 0; i--)
        {
            int node = order[i];
            grundy[parent[node]] ^= grundy[node] + 1;
        }

        return grundy[1] != 0 ? "Alice" : "Bob";
    }
}
