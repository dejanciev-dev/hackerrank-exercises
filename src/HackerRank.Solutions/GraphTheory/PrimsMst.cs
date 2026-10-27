namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Prim's (MST): Special Subtree — total weight of a minimum spanning tree grown from
/// <c>start</c>. Lazy Prim's with a priority queue of frontier edges, O(m log m).
/// https://www.hackerrank.com/challenges/primsmstsub
/// </summary>
public static class PrimsMst
{
    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="edges">Each edge as <c>[from, to, weight]</c>.</param>
    /// <param name="start">The node the tree grows from.</param>
    public static int Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges, int start)
    {
        var adjacency = new List<(int To, int Weight)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            adjacency[i] = [];
        }

        foreach (var edge in edges)
        {
            adjacency[edge[0]].Add((edge[1], edge[2]));
            adjacency[edge[1]].Add((edge[0], edge[2]));
        }

        var inTree = new bool[n + 1];
        var frontier = new PriorityQueue<int, int>();
        frontier.Enqueue(start, 0);
        int total = 0;

        while (frontier.TryDequeue(out int node, out int weight))
        {
            if (inTree[node])
            {
                continue;
            }

            inTree[node] = true;
            total += weight;

            foreach (var (to, w) in adjacency[node])
            {
                if (!inTree[to])
                {
                    frontier.Enqueue(to, w);
                }
            }
        }

        return total;
    }
}
