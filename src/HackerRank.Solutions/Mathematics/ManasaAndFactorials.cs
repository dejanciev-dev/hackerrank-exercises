namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Manasa and Factorials — find the smallest n whose factorial n! ends with at least z zeros.
/// The number of trailing zeros of n! is the number of factors of 5 in it,
/// ⌊n/5⌋ + ⌊n/25⌋ + ⌊n/125⌋ + …, which never decreases as n grows, so the smallest n can be
/// found by binary search between 0 and 5z (the factorial of 5z has at least z zeros). O(log z · log₅ z).
/// https://www.hackerrank.com/challenges/manasa-and-factorials
/// </summary>
public static class ManasaAndFactorials
{
    public static long Solve(long z)
    {
        long low = 0;
        long high = 5 * z;

        while (low < high)
        {
            long mid = low + (high - low) / 2;
            if (TrailingZeros(mid) >= z)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    private static long TrailingZeros(long n)
    {
        long zeros = 0;
        for (long power = 5; power <= n; power *= 5)
        {
            zeros += n / power;
        }

        return zeros;
    }
}
