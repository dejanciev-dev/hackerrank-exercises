namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Dijkstra: Shortest Reach 2 — shortest distance from <c>s</c> to every other node (in node
/// order) of an undirected weighted graph, or -1 when unreachable. Dijkstra with a binary heap
/// and lazy deletion, O(m log m).
/// https://www.hackerrank.com/challenges/dijkstrashortreach
/// </summary>
public static class DijkstraShortestReach
{
    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="edges">Each edge as <c>[from, to, weight]</c>; parallel edges are allowed.</param>
    /// <param name="s">The source node.</param>
    public static long[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges, int s)
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

        var distance = new long[n + 1];
        Array.Fill(distance, long.MaxValue);
        distance[s] = 0;

        var queue = new PriorityQueue<int, long>();
        queue.Enqueue(s, 0);

        while (queue.TryDequeue(out int node, out long d))
        {
            if (d > distance[node])
            {
                continue;
            }

            foreach (var (to, weight) in adjacency[node])
            {
                long candidate = d + weight;
                if (candidate < distance[to])
                {
                    distance[to] = candidate;
                    queue.Enqueue(to, candidate);
                }
            }
        }

        return Enumerable.Range(1, n)
            .Where(i => i != s)
            .Select(i => distance[i] == long.MaxValue ? -1 : distance[i])
            .ToArray();
    }
}
