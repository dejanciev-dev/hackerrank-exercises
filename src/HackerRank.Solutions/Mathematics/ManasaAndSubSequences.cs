namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Manasa and Sub-sequences — the sum of the values of all non-empty subsequences of a digit
/// string, modulo 1e9+7. For a new digit d, every earlier subsequence either skips it or
/// becomes 10·value + d, and d also stands alone. So total' = 11·total + d·(count + 1) and
/// count' = 2·count + 1. O(n).
/// https://www.hackerrank.com/challenges/manasa-and-sub-sequences
/// </summary>
public static class ManasaAndSubSequences
{
    public static long Solve(string number)
    {
        const long Mod = ModularMath.Prime;
        long total = 0;
        long count = 0;

        foreach (var c in number)
        {
            long digit = c - '0';
            total = (11 * total + digit * (count + 1)) % Mod;
            count = (2 * count + 1) % Mod;
        }

        return total;
    }
}
