namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Synchronous Shopping — two cats leave centre 1 together and meet at centre n, and between
/// them they must buy all <c>k</c> fish types; minimise the later arrival time. Dijkstra over
/// (centre, fish bought so far) states, at most n · 2^k. Then try every pair of fish sets
/// that covers all types at centre n.
/// https://www.hackerrank.com/challenges/synchronous-shopping
/// </summary>
public static class SynchronousShopping
{
    /// <param name="n">Number of centres, labelled 1..n.</param>
    /// <param name="k">Number of fish types, labelled 1..k.</param>
    /// <param name="centers">The fish types sold at centre i + 1.</param>
    /// <param name="roads">Each road as <c>[u, v, time]</c>.</param>
    public static int Solve(int n, int k, IReadOnlyList<IReadOnlyList<int>> centers, IReadOnlyList<IReadOnlyList<int>> roads)
    {
        int full = (1 << k) - 1;
        var sells = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            foreach (var fish in centers[i])
            {
                sells[i + 1] |= 1 << (fish - 1);
            }
        }

        var adjacency = new List<(int To, int Time)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            adjacency[i] = [];
        }

        foreach (var road in roads)
        {
            adjacency[road[0]].Add((road[1], road[2]));
            adjacency[road[1]].Add((road[0], road[2]));
        }

        var distance = new int[n + 1, full + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int mask = 0; mask <= full; mask++)
            {
                distance[i, mask] = int.MaxValue;
            }
        }

        var queue = new PriorityQueue<(int Node, int Mask), int>();
        distance[1, sells[1]] = 0;
        queue.Enqueue((1, sells[1]), 0);

        while (queue.TryDequeue(out var state, out int time))
        {
            if (time > distance[state.Node, state.Mask])
            {
                continue;
            }

            foreach (var (to, cost) in adjacency[state.Node])
            {
                int mask = state.Mask | sells[to];
                int arrival = time + cost;
                if (arrival < distance[to, mask])
                {
                    distance[to, mask] = arrival;
                    queue.Enqueue((to, mask), arrival);
                }
            }
        }

        int best = int.MaxValue;
        for (int a = 0; a <= full; a++)
        {
            if (distance[n, a] == int.MaxValue)
            {
                continue;
            }

            for (int b = a; b <= full; b++)
            {
                if ((a | b) == full && distance[n, b] != int.MaxValue)
                {
                    best = Math.Min(best, Math.Max(distance[n, a], distance[n, b]));
                }
            }
        }

        return best;
    }
}
