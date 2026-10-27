namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// 2's complement — total number of 1 bits in the 32-bit two's complement form of every
/// integer from a to b. For x ≥ 0, bit i is set in exactly
/// ⌊(x+1) / 2^(i+1)⌋ · 2^i + max(0, (x+1) mod 2^(i+1) - 2^i) of the numbers 0..x. A negative
/// -m is the complement of m - 1, so it has 32 - popcount(m - 1) ones. O(32).
/// https://www.hackerrank.com/challenges/2s-complement
/// </summary>
public static class TwosComplement
{
    private const int Bits = 32;

    public static long Solve(long a, long b)
    {
        long total = 0;

        if (a < 0)
        {
            long lastNegative = Math.Min(b, -1);

            // n in [a, lastNegative] maps to -n - 1 in [-lastNegative - 1, -a - 1].
            long count = lastNegative - a + 1;
            total += Bits * count - (OnesUpTo(-a - 1) - OnesUpTo(-lastNegative - 2));
            a = 0;
        }

        if (b >= 0)
        {
            total += OnesUpTo(b) - OnesUpTo(a - 1);
        }

        return total;
    }

    /// <summary>Total set bits in 0..x; 0 when x &lt; 0.</summary>
    private static long OnesUpTo(long x)
    {
        if (x < 0)
        {
            return 0;
        }

        long ones = 0;
        for (int bit = 0; bit < Bits; bit++)
        {
            long cycle = 1L << (bit + 1);
            long half = 1L << bit;
            ones += (x + 1) / cycle * half + Math.Max(0, (x + 1) % cycle - half);
        }

        return ones;
    }
}
