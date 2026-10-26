using System.Numerics;

namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Maximizing XOR — maximum a XOR b for l ≤ a ≤ b ≤ r. Above the highest bit where l and r
/// differ, every pair shares the same bits; below it, some pair can differ everywhere.
/// So the answer is all ones from that bit down. O(1).
/// https://www.hackerrank.com/challenges/maximizing-xor
/// </summary>
public static class MaximizingXor
{
    public static int Solve(int l, int r)
    {
        int differing = l ^ r;
        if (differing == 0)
        {
            return 0;
        }

        int highestBit = BitOperations.Log2((uint)differing);
        return (1 << (highestBit + 1)) - 1;
    }
}
