namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Breadth First Search: Shortest Reach — every edge weighs 6; report the distance from
/// <c>s</c> to every other node (in node order), or -1 when unreachable. Plain BFS, O(n + m).
/// https://www.hackerrank.com/challenges/bfsshortreach
/// </summary>
public static class BfsShortestReach
{
    private const int EdgeWeight = 6;

    public static int[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges, int s)
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

        var distance = new int[n + 1];
        Array.Fill(distance, -1);
        distance[s] = 0;

        var queue = new Queue<int>();
        queue.Enqueue(s);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var next in adjacency[node])
            {
                if (distance[next] == -1)
                {
                    distance[next] = distance[node] + EdgeWeight;
                    queue.Enqueue(next);
                }
            }
        }

        return Enumerable.Range(1, n).Where(i => i != s).Select(i => distance[i]).ToArray();
    }
}
