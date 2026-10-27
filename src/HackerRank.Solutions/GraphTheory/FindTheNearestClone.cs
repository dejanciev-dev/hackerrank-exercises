namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Find the nearest clone — shortest path between any two nodes that both have colour
/// <c>val</c>, or -1. Multi-source BFS from every node of that colour, recording which source
/// reached each node first; an edge between regions of two different sources completes a
/// path of length dist[u] + dist[v] + 1. O(n + m).
/// https://www.hackerrank.com/challenges/find-the-nearest-clone
/// </summary>
public static class FindTheNearestClone
{
    /// <param name="graphNodes">Number of nodes, labelled 1..graphNodes.</param>
    /// <param name="graphFrom">Edge start nodes.</param>
    /// <param name="graphTo">Edge end nodes, paired with <paramref name="graphFrom"/>.</param>
    /// <param name="ids">The colour of node i + 1.</param>
    /// <param name="val">The colour to look for.</param>
    public static int Solve(int graphNodes, IReadOnlyList<int> graphFrom, IReadOnlyList<int> graphTo, IReadOnlyList<long> ids, long val)
    {
        var adjacency = new List<int>[graphNodes + 1];
        for (int i = 1; i <= graphNodes; i++)
        {
            adjacency[i] = [];
        }

        for (int i = 0; i < graphFrom.Count; i++)
        {
            adjacency[graphFrom[i]].Add(graphTo[i]);
            adjacency[graphTo[i]].Add(graphFrom[i]);
        }

        var distance = new int[graphNodes + 1];
        var source = new int[graphNodes + 1];
        var queue = new Queue<int>();

        for (int node = 1; node <= graphNodes; node++)
        {
            if (ids[node - 1] == val)
            {
                source[node] = node;
                queue.Enqueue(node);
            }
        }

        int best = int.MaxValue;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var next in adjacency[node])
            {
                if (source[next] == 0)
                {
                    source[next] = source[node];
                    distance[next] = distance[node] + 1;
                    queue.Enqueue(next);
                }
                else if (source[next] != source[node])
                {
                    best = Math.Min(best, distance[node] + distance[next] + 1);
                }
            }
        }

        return best == int.MaxValue ? -1 : best;
    }
}
