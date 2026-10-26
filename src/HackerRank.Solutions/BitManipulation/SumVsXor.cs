using System.Numerics;

namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Sum vs XOR — count x in [0, n] with n + x = n XOR x, i.e. x has no bits in common with n.
/// Each zero bit of n below its highest set bit can be freely on or off: 2^(zero bits).
/// https://www.hackerrank.com/challenges/sum-vs-xor
/// </summary>
public static class SumVsXor
{
    public static long Solve(long n)
    {
        if (n == 0)
        {
            return 1;
        }

        int bitLength = BitOperations.Log2((ulong)n) + 1;
        int zeroBits = bitLength - BitOperations.PopCount((ulong)n);

        return 1L << zeroBits;
    }
}
