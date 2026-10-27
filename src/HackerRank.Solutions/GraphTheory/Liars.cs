namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Liars — each clue says soldiers A..B include exactly C liars; return the fewest and most
/// liars overall. With prefix counts S_i these are difference constraints: 0 ≤ S_i - S_{i-1}
/// ≤ 1 and S_B - S_{A-1} = C. In the constraint graph, the shortest path from 0 to n gives the
/// largest S_n, and the negated shortest path from n back to 0 gives the smallest.
/// Bellman–Ford, O(n · (n + m)).
/// https://www.hackerrank.com/challenges/liars
/// </summary>
public static class Liars
{
    /// <param name="n">Number of soldiers.</param>
    /// <param name="sets">Each clue as <c>[A, B, C]</c>.</param>
    public static int[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> sets)
    {
        // Edge u → v with weight w encodes S_v - S_u ≤ w.
        var edges = new List<(int From, int To, int Weight)>();
        for (int i = 1; i <= n; i++)
        {
            edges.Add((i - 1, i, 1));
            edges.Add((i, i - 1, 0));
        }

        foreach (var clue in sets)
        {
            edges.Add((clue[0] - 1, clue[1], clue[2]));
            edges.Add((clue[1], clue[0] - 1, -clue[2]));
        }

        int most = ShortestPath(n, edges, 0)[n];
        int fewest = -ShortestPath(n, edges, n)[0];
        return [fewest, most];
    }

    private static int[] ShortestPath(int n, List<(int From, int To, int Weight)> edges, int source)
    {
        var distance = new int[n + 1];
        Array.Fill(distance, int.MaxValue);
        distance[source] = 0;

        for (int round = 0; round < n; round++)
        {
            bool changed = false;
            foreach (var (from, to, weight) in edges)
            {
                if (distance[from] != int.MaxValue && distance[from] + weight < distance[to])
                {
                    distance[to] = distance[from] + weight;
                    changed = true;
                }
            }

            if (!changed)
            {
                break;
            }
        }

        return distance;
    }
}
