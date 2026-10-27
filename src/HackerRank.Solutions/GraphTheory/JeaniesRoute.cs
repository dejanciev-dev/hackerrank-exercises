namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Jeanie's Route — shortest walk through a weighted tree that visits every city with a
/// letter, starting and ending anywhere. Prune leaves that need no visit until only the
/// subtree spanning the letter cities is left. Walking it covers each edge twice except
/// along the path the walk doesn't return over, so the answer is
/// 2 · (subtree weight) - (subtree diameter). O(n).
/// https://www.hackerrank.com/challenges/jeanies-route
/// </summary>
public static class JeaniesRoute
{
    /// <param name="n">Number of cities, labelled 1..n.</param>
    /// <param name="cities">The cities that must be visited.</param>
    /// <param name="roads">Each road as <c>[u, v, length]</c>.</param>
    public static long Solve(int n, IReadOnlyList<int> cities, IReadOnlyList<IReadOnlyList<int>> roads)
    {
        var adjacency = new List<(int To, int Length)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            adjacency[i] = [];
        }

        foreach (var road in roads)
        {
            adjacency[road[0]].Add((road[1], road[2]));
            adjacency[road[1]].Add((road[0], road[2]));
        }

        var needed = new bool[n + 1];
        foreach (var city in cities)
        {
            needed[city] = true;
        }

        var degree = new int[n + 1];
        var removed = new bool[n + 1];
        var leaves = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            degree[i] = adjacency[i].Count;
            if (degree[i] <= 1 && !needed[i])
            {
                leaves.Enqueue(i);
            }
        }

        while (leaves.Count > 0)
        {
            int leaf = leaves.Dequeue();
            removed[leaf] = true;

            foreach (var (to, _) in adjacency[leaf])
            {
                if (!removed[to] && --degree[to] == 1 && !needed[to])
                {
                    leaves.Enqueue(to);
                }
            }
        }

        long total = 0;
        for (int u = 1; u <= n; u++)
        {
            if (!removed[u])
            {
                total += adjacency[u].Where(e => !removed[e.To]).Sum(e => (long)e.Length);
            }
        }

        total /= 2;

        var (farthest, _) = Farthest(adjacency, removed, cities[0], n);
        var (_, diameter) = Farthest(adjacency, removed, farthest, n);

        return 2 * total - diameter;
    }

    private static (int Node, long Distance) Farthest(List<(int To, int Length)>[] adjacency, bool[] removed, int start, int n)
    {
        var distance = new long[n + 1];
        Array.Fill(distance, -1);
        distance[start] = 0;
        var stack = new Stack<int>();
        stack.Push(start);
        (int Node, long Distance) best = (start, 0);

        while (stack.Count > 0)
        {
            int u = stack.Pop();
            if (distance[u] > best.Distance)
            {
                best = (u, distance[u]);
            }

            foreach (var (to, length) in adjacency[u])
            {
                if (!removed[to] && distance[to] == -1)
                {
                    distance[to] = distance[u] + length;
                    stack.Push(to);
                }
            }
        }

        return best;
    }
}
