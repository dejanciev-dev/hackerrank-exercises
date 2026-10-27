namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Lego Blocks — count the solid walls of height <c>n</c> and width <c>m</c> built from 1x1..1x4
/// blocks, where "solid" means no vertical line runs through the whole wall; modulo 1e9+7.
/// Rows tile like a tetranacci sequence, any wall is rows^n, and solid(w) subtracts every wall
/// whose first vertical break is at j: solid(w) = all(w) - Σ solid(j) · all(w - j). O(m²).
/// https://www.hackerrank.com/challenges/lego-blocks
/// </summary>
public static class LegoBlocks
{
    private const long Mod = 1_000_000_007;

    public static long Solve(int n, int m)
    {
        var row = new long[m + 1];
        row[0] = 1;

        for (int w = 1; w <= m; w++)
        {
            for (int block = 1; block <= 4 && block <= w; block++)
            {
                row[w] = (row[w] + row[w - block]) % Mod;
            }
        }

        var all = new long[m + 1];
        for (int w = 1; w <= m; w++)
        {
            all[w] = Power(row[w], n);
        }

        var solid = new long[m + 1];
        for (int w = 1; w <= m; w++)
        {
            long broken = 0;
            for (int j = 1; j < w; j++)
            {
                broken = (broken + solid[j] * all[w - j]) % Mod;
            }

            solid[w] = (all[w] - broken + Mod) % Mod;
        }

        return solid[m];
    }

    private static long Power(long value, int exponent)
    {
        long result = 1;
        value %= Mod;

        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                result = result * value % Mod;
            }

            value = value * value % Mod;
            exponent >>= 1;
        }

        return result;
    }
}
