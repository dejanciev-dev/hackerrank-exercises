namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Far Vertices — remove as few vertices as possible from a tree so that no two remaining
/// ones are more than <c>k</c> apart. A set with diameter at most k lies within k/2 of some
/// centre: a vertex when k is even, an edge when k is odd. So try every centre, count the
/// vertices close enough, and keep the best. All-pairs BFS, O(n²).
/// https://www.hackerrank.com/challenges/far-vertices
/// </summary>
public static class FarVertices
{
    public static int Solve(int n, int k, IReadOnlyList<IReadOnlyList<int>> edges)
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

        var distance = new int[n + 1][];
        for (int source = 1; source <= n; source++)
        {
            distance[source] = Bfs(adjacency, source, n);
        }

        int kept = 0;
        if (k % 2 == 0)
        {
            for (int centre = 1; centre <= n; centre++)
            {
                kept = Math.Max(kept, Enumerable.Range(1, n).Count(v => distance[centre][v] <= k / 2));
            }
        }
        else
        {
            kept = 1;
            foreach (var edge in edges)
            {
                int u = edge[0], w = edge[1];
                kept = Math.Max(kept, Enumerable.Range(1, n).Count(v => Math.Min(distance[u][v], distance[w][v]) <= k / 2));
            }
        }

        return n - kept;
    }

    private static int[] Bfs(List<int>[] adjacency, int source, int n)
    {
        var distance = new int[n + 1];
        Array.Fill(distance, -1);
        distance[source] = 0;
        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            foreach (var v in adjacency[u])
            {
                if (distance[v] == -1)
                {
                    distance[v] = distance[u] + 1;
                    queue.Enqueue(v);
                }
            }
        }

        return distance;
    }
}
