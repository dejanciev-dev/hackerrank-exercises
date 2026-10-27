namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Prime XOR — count the distinct multisets drawn from the array whose XOR is prime, modulo
/// 1e9+7. Values lie in 3500..4500, so every XOR is below 8192. A value appearing c times can
/// be taken an even number of times (⌊c/2⌋ + 1 ways, XOR unchanged) or an odd number of
/// times (⌈c/2⌉ ways, XOR toggled). DP over the 8192 XOR values, once per distinct value.
/// https://www.hackerrank.com/challenges/prime-xor
/// </summary>
public static class PrimeXor
{
    private const long Mod = 1_000_000_007;
    private const int XorRange = 8192;

    public static long Solve(IReadOnlyList<int> a)
    {
        var ways = new long[XorRange];
        ways[0] = 1;

        foreach (var group in a.GroupBy(v => v))
        {
            long even = group.Count() / 2 + 1;
            long odd = (group.Count() + 1) / 2;
            var next = new long[XorRange];

            for (int x = 0; x < XorRange; x++)
            {
                next[x] = (ways[x] * even + ways[x ^ group.Key] * odd) % Mod;
            }

            ways = next;
        }

        var composite = new bool[XorRange];
        long total = 0;
        for (int p = 2; p < XorRange; p++)
        {
            if (composite[p])
            {
                continue;
            }

            total = (total + ways[p]) % Mod;
            for (int multiple = p * p; multiple < XorRange; multiple += p)
            {
                composite[multiple] = true;
            }
        }

        return total;
    }
}
