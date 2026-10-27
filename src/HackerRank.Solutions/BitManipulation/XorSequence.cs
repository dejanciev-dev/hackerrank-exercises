namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Xor-sequence — A[i] = 0 ^ 1 ^ ... ^ i; return A[l] ^ ... ^ A[r]. The prefix XOR of A,
/// F(x) = A[0] ^ ... ^ A[x], repeats with period 8: x, x, 2, 2, x + 2, x + 2, 0, 0.
/// So the answer is F(r) ^ F(l - 1), in O(1).
/// https://www.hackerrank.com/challenges/xor-se
/// </summary>
public static class XorSequence
{
    public static long Solve(long l, long r) => PrefixXor(r) ^ PrefixXor(l - 1);

    private static long PrefixXor(long x)
    {
        if (x < 0)
        {
            return 0;
        }

        return (x % 8) switch
        {
            0 or 1 => x,
            2 or 3 => 2,
            4 or 5 => x + 2,
            _ => 0,
        };
    }
}
