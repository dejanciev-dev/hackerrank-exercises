namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Floyd : City of Blinding Lights — shortest distances in a directed weighted graph for many
/// (from, to) queries, or -1 when unreachable. A repeated edge replaces the earlier one.
/// Floyd–Warshall once (n ≤ 400), then each query is a lookup. O(n³ + q).
/// https://www.hackerrank.com/challenges/floyd-city-of-blinding-lights
/// </summary>
public static class FloydCityOfBlindingLights
{
    private const int Infinity = int.MaxValue / 2;

    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="edges">Each directed edge as <c>[from, to, weight]</c>.</param>
    /// <param name="queries">Each query as <c>[from, to]</c>.</param>
    public static int[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges, IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var distance = new int[n + 1, n + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                distance[i, j] = i == j ? 0 : Infinity;
            }
        }

        foreach (var edge in edges)
        {
            if (edge[0] != edge[1])
            {
                distance[edge[0], edge[1]] = edge[2];
            }
        }

        for (int k = 1; k <= n; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    int viaK = distance[i, k] + distance[k, j];
                    if (viaK < distance[i, j])
                    {
                        distance[i, j] = viaK;
                    }
                }
            }
        }

        return queries.Select(q => distance[q[0], q[1]] >= Infinity ? -1 : distance[q[0], q[1]]).ToArray();
    }
}
