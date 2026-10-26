using System.Numerics;

namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// The Great XOR — count a in (0, x) with a XOR x > x. Such an a has its highest set bit where
/// x has a 0, so the count is the sum of 2^i over the zero bits of x below its top bit.
/// XOR-ing x with an all-ones mask of the same length gives exactly that sum.
/// https://www.hackerrank.com/challenges/the-great-xor
/// </summary>
public static class TheGreatXor
{
    public static long Solve(long x)
    {
        int bitLength = BitOperations.Log2((ulong)x) + 1;
        long allOnes = (1L << bitLength) - 1;

        return allOnes ^ x;
    }
}
