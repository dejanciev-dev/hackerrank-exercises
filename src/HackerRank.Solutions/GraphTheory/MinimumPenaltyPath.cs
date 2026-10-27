namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Minimum Penalty Path — a path's penalty is the bitwise OR of its edge costs (each under
/// 1024); find the smallest penalty from A to B, or -1. OR never decreases along a path, so
/// search over (node, OR so far) states: at most n · 1024 of them, each visited once by BFS.
/// https://www.hackerrank.com/challenges/beautiful-path
/// </summary>
public static class MinimumPenaltyPath
{
    private const int Masks = 1024;

    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="edges">Each undirected edge as <c>[u, v, cost]</c>.</param>
    /// <param name="a">The start node.</param>
    /// <param name="b">The target node.</param>
    public static int Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges, int a, int b)
    {
        var adjacency = new List<(int To, int Cost)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            adjacency[i] = [];
        }

        foreach (var edge in edges)
        {
            adjacency[edge[0]].Add((edge[1], edge[2]));
            adjacency[edge[1]].Add((edge[0], edge[2]));
        }

        var seen = new bool[n + 1, Masks];
        var queue = new Queue<(int Node, int Penalty)>();
        seen[a, 0] = true;
        queue.Enqueue((a, 0));

        while (queue.Count > 0)
        {
            var (node, penalty) = queue.Dequeue();
            foreach (var (to, cost) in adjacency[node])
            {
                int next = penalty | cost;
                if (!seen[to, next])
                {
                    seen[to, next] = true;
                    queue.Enqueue((to, next));
                }
            }
        }

        for (int penalty = 0; penalty < Masks; penalty++)
        {
            if (seen[b, penalty])
            {
                return penalty;
            }
        }

        return -1;
    }
}
