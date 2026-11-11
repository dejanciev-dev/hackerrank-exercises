namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Closest Number — find the multiple of x closest to a^b (0 &lt; a^b ≤ 10^9, b may be
/// negative); on a tie, take the smaller multiple.
/// For b ≥ 0 the power is an exact integer, so compare the multiples just below and above it.
/// For b &lt; 0, a^b ≤ 1 and the answer is 0, unless a = 1 and x = 1 make it exactly 1.
/// https://www.hackerrank.com/challenges/closest-number
/// </summary>
public static class ClosestNumber
{
    public static long Solve(long a, long b, long x)
    {
        if (b < 0)
        {
            return a == 1 && x == 1 ? 1 : 0;
        }

        long value = 1;
        for (long i = 0; i < b && value <= 1_000_000_000; i++)
        {
            value *= a;
            if (a == 1)
            {
                break;
            }
        }

        long lower = value / x * x;
        long upper = lower + x;
        return value - lower <= upper - value ? lower : upper;
    }
}
