namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Flipping Bits — invert all 32 bits of an unsigned integer and return the result.
/// https://www.hackerrank.com/challenges/flipping-bits
/// </summary>
public static class FlippingBits
{
    public static long Solve(long n) => ~(uint)n;
}
