namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Kingdom Connectivity — number of distinct paths from city 1 to city n in a directed graph
/// (repeated roads count separately), modulo 10^9, or "INFINITE PATHS" if a cycle lies on
/// some 1 → n route. Keep only the cities reachable from 1 that can also reach n. Kahn's
/// algorithm either finds a cycle among them or gives a topological order for counting.
/// https://www.hackerrank.com/challenges/kingdom-connectivity
/// </summary>
public static class KingdomConnectivity
{
    private const long Mod = 1_000_000_000;

    /// <param name="n">Number of cities, labelled 1..n.</param>
    /// <param name="edges">Each directed road as <c>[from, to]</c>.</param>
    public static string Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        var forward = new List<int>[n + 1];
        var backward = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            forward[i] = [];
            backward[i] = [];
        }

        foreach (var edge in edges)
        {
            forward[edge[0]].Add(edge[1]);
            backward[edge[1]].Add(edge[0]);
        }

        var fromStart = Reachable(forward, 1, n);
        var toEnd = Reachable(backward, n, n);
        var relevant = new bool[n + 1];
        for (int i = 1; i <= n; i++)
        {
            relevant[i] = fromStart[i] && toEnd[i];
        }

        if (!relevant[1])
        {
            return "0";
        }

        var inDegree = new int[n + 1];
        for (int u = 1; u <= n; u++)
        {
            if (relevant[u])
            {
                foreach (var v in forward[u].Where(v => relevant[v]))
                {
                    inDegree[v]++;
                }
            }
        }

        var paths = new long[n + 1];
        paths[1] = 1;
        var queue = new Queue<int>(Enumerable.Range(1, n).Where(i => relevant[i] && inDegree[i] == 0));
        int processed = 0;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            processed++;

            foreach (var v in forward[u].Where(v => relevant[v]))
            {
                paths[v] = (paths[v] + paths[u]) % Mod;
                if (--inDegree[v] == 0)
                {
                    queue.Enqueue(v);
                }
            }
        }

        int relevantCount = relevant.Count(r => r);
        return processed < relevantCount ? "INFINITE PATHS" : paths[n].ToString();
    }

    private static bool[] Reachable(List<int>[] adjacency, int start, int n)
    {
        var seen = new bool[n + 1];
        var stack = new Stack<int>();
        stack.Push(start);
        seen[start] = true;

        while (stack.Count > 0)
        {
            foreach (var next in adjacency[stack.Pop()])
            {
                if (!seen[next])
                {
                    seen[next] = true;
                    stack.Push(next);
                }
            }
        }

        return seen;
    }
}
