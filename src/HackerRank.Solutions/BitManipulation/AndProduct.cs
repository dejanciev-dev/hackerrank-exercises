namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// AND Product — bitwise AND of every integer in [a, b]. Any bit below the highest bit where a
/// and b differ flips somewhere in the range, so only their common prefix survives. O(log b).
/// https://www.hackerrank.com/challenges/and-product
/// </summary>
public static class AndProduct
{
    public static long Solve(long a, long b)
    {
        int shift = 0;

        while (a != b)
        {
            a >>= 1;
            b >>= 1;
            shift++;
        }

        return a << shift;
    }
}
