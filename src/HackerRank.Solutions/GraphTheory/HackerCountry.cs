namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Hacker Country — in a complete directed graph, the cycle with the smallest average edge
/// toll, as a reduced fraction. Karp's minimum mean cycle algorithm: with D_k(v) the
/// cheapest walk of exactly k edges ending at v, the answer is
/// min_v max_k (D_n(v) - D_k(v)) / (n - k). Fractions are compared exactly by cross
/// multiplication. O(n³).
/// https://www.hackerrank.com/challenges/hacker-country
/// </summary>
public static class HackerCountry
{
    public static string Solve(IReadOnlyList<IReadOnlyList<int>> tolls)
    {
        int n = tolls.Count;
        const long Unreachable = long.MaxValue / 4;
        var walk = new long[n + 1, n];

        for (int k = 1; k <= n; k++)
        {
            for (int v = 0; v < n; v++)
            {
                long best = Unreachable;
                for (int u = 0; u < n; u++)
                {
                    if (u != v && walk[k - 1, u] < Unreachable)
                    {
                        best = Math.Min(best, walk[k - 1, u] + tolls[u][v]);
                    }
                }

                walk[k, v] = best;
            }
        }

        (long Num, long Den)? answer = null;

        for (int v = 0; v < n; v++)
        {
            if (walk[n, v] >= Unreachable)
            {
                continue;
            }

            (long Num, long Den)? worst = null;
            for (int k = 0; k < n; k++)
            {
                if (walk[k, v] >= Unreachable)
                {
                    continue;
                }

                var mean = (walk[n, v] - walk[k, v], (long)(n - k));
                if (worst is null || mean.Item1 * worst.Value.Den > worst.Value.Num * mean.Item2)
                {
                    worst = mean;
                }
            }

            if (worst is { } w && (answer is null || w.Num * answer.Value.Den < answer.Value.Num * w.Den))
            {
                answer = w;
            }
        }

        var (num, den) = answer!.Value;
        long g = Mathematics.ModularMath.Gcd(num, den);
        return $"{num / g}/{den / g}";
    }
}
