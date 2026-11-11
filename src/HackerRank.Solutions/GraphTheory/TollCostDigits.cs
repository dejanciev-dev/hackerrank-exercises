namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Toll Cost Digits — road (x, y, r) costs r from x to y and 1000 − r back. For each digit d,
/// count the ordered pairs (x, y), x ≠ y, with some walk from x to y whose total cost ends in d.
/// Within a component, give every junction a potential (cost mod 10 along a BFS tree). Every
/// edge's mismatch against the potentials is a closed-walk cost, and together they generate
/// the subgroup gZ₁₀ with g = gcd(10, mismatches). So x reaches y with exactly the digits
/// d ≡ pot(y) − pot(x) (mod g). O(n + e).
/// https://www.hackerrank.com/challenges/toll-cost-digits
/// </summary>
public static class TollCostDigits
{
    /// <param name="n">The number of junctions.</param>
    /// <param name="roads">Each road as <c>[x, y, r]</c>, junctions numbered from 1.</param>
    public static long[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> roads)
    {
        var adjacency = new List<(int To, int Cost)>[n + 1];
        for (int v = 1; v <= n; v++)
        {
            adjacency[v] = [];
        }

        foreach (var road in roads)
        {
            int cost = road[2] % 10;
            adjacency[road[0]].Add((road[1], cost));
            adjacency[road[1]].Add((road[0], (10 - cost) % 10));
        }

        var answer = new long[10];
        var potential = new int[n + 1];
        Array.Fill(potential, -1);

        for (int root = 1; root <= n; root++)
        {
            if (potential[root] >= 0)
            {
                continue;
            }

            var component = new List<int> { root };
            potential[root] = 0;
            int g = 10;
            for (int head = 0; head < component.Count; head++)
            {
                int v = component[head];
                foreach (var (to, cost) in adjacency[v])
                {
                    int reached = (potential[v] + cost) % 10;
                    if (potential[to] < 0)
                    {
                        potential[to] = reached;
                        component.Add(to);
                    }
                    else
                    {
                        g = Gcd(g, (reached - potential[to] + 10) % 10);
                    }
                }
            }

            var inClass = new long[g];
            foreach (int v in component)
            {
                inClass[potential[v] % g]++;
            }

            for (int from = 0; from < g; from++)
            {
                for (int to = 0; to < g; to++)
                {
                    long pairs = from == to ? inClass[from] * (inClass[from] - 1) : inClass[from] * inClass[to];
                    for (int d = (to - from + g) % g; d < 10; d += g)
                    {
                        answer[d] += pairs;
                    }
                }
            }
        }

        return answer;
    }

    private static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
}
