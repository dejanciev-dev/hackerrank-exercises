namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Grid Walking — count walks of exactly <c>m</c> unit steps (one coordinate ±1 per step)
/// that stay inside an n-dimensional box, modulo 1e9+7. Each dimension behaves like its own
/// 1-D walk, so count walks of every length t per dimension. Then combine dimensions by
/// choosing which of the steps belong to each:
/// total(s) = Σ_t total_prev(s - t) · walks_i(t) · C(s, t). O(n · m · (D + m)).
/// https://www.hackerrank.com/challenges/grid-walking
/// </summary>
public static class GridWalking
{
    private const long Mod = 1_000_000_007;

    public static long Solve(int m, IReadOnlyList<int> x, IReadOnlyList<int> d)
    {
        var binomial = new long[m + 1, m + 1];
        for (int i = 0; i <= m; i++)
        {
            binomial[i, 0] = 1;
            for (int j = 1; j <= i; j++)
            {
                binomial[i, j] = (binomial[i - 1, j - 1] + binomial[i - 1, j]) % Mod;
            }
        }

        var total = new long[m + 1];
        total[0] = 1;

        for (int dim = 0; dim < x.Count; dim++)
        {
            var walks = OneDimensionalWalks(x[dim], d[dim], m);
            var combined = new long[m + 1];

            for (int s = 0; s <= m; s++)
            {
                for (int t = 0; t <= s; t++)
                {
                    combined[s] = (combined[s] + total[s - t] * walks[t] % Mod * binomial[s, t]) % Mod;
                }
            }

            total = combined;
        }

        return total[m];
    }

    /// <summary>walks[t]: t-step walks on 1..size starting at start that never leave it.</summary>
    private static long[] OneDimensionalWalks(int start, int size, int maxSteps)
    {
        var walks = new long[maxSteps + 1];
        var at = new long[size + 2];
        at[start] = 1;
        walks[0] = 1;

        for (int step = 1; step <= maxSteps; step++)
        {
            var next = new long[size + 2];
            long sum = 0;
            for (int p = 1; p <= size; p++)
            {
                next[p] = (at[p - 1] + at[p + 1]) % Mod;
                sum += next[p];
            }

            at = next;
            walks[step] = sum % Mod;
        }

        return walks;
    }
}
