namespace HackerRank.Solutions.Search;

/// <summary>
/// Cut the Tree — remove one edge so the two resulting trees' value sums differ as little as
/// possible. Cutting above a node splits off its subtree, so compute every subtree sum and
/// minimise |total - 2 · subtree|. Iterative BFS order, O(n).
/// https://www.hackerrank.com/challenges/cut-the-tree
/// </summary>
public static class CutTheTree
{
    /// <param name="data">The value of node i + 1.</param>
    /// <param name="edges">Undirected edges between 1-based node labels.</param>
    public static int Solve(IReadOnlyList<int> data, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        int n = data.Count;
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
            int node = order[i];
            foreach (var next in adjacency[node])
            {
                if (next != parent[node])
                {
                    parent[next] = node;
                    order.Add(next);
                }
            }
        }

        var subtree = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            subtree[i] = data[i - 1];
        }

        for (int i = order.Count - 1; i > 0; i--)
        {
            subtree[parent[order[i]]] += subtree[order[i]];
        }

        int total = subtree[1];
        int best = int.MaxValue;

        for (int i = 1; i < order.Count; i++)
        {
            best = Math.Min(best, Math.Abs(total - 2 * subtree[order[i]]));
        }

        return best;
    }
}
