namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Count Solutions — pairs 1 ≤ x ≤ c, 1 ≤ y ≤ d with x² + y² = a·x + b·y. For each x this is
/// a quadratic in y, y² - b·y + (x² - a·x) = 0. Its discriminant must be a perfect square s²,
/// giving y = (b ± s) / 2. O(c).
/// https://www.hackerrank.com/challenges/count-solutions
/// </summary>
public static class CountSolutions
{
    public static long Solve(long a, long b, long c, long d)
    {
        long count = 0;

        for (long x = 1; x <= c; x++)
        {
            long discriminant = b * b - 4 * (x * x - a * x);
            if (discriminant < 0)
            {
                continue;
            }

            long s = (long)Math.Sqrt(discriminant);
            while (s * s > discriminant) s--;
            while ((s + 1) * (s + 1) <= discriminant) s++;
            if (s * s != discriminant || (b + s) % 2 != 0)
            {
                continue;
            }

            foreach (var y in s == 0 ? new[] { b / 2 } : new[] { (b + s) / 2, (b - s) / 2 })
            {
                if (y >= 1 && y <= d)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
