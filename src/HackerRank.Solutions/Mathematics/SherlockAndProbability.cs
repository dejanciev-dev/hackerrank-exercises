namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Sherlock and Probability — pick indices i and j of a binary string uniformly and
/// independently; what is the probability that both hold '1' and |i − j| ≤ k? Print it as a
/// reduced fraction, "0/1" when it is zero.
/// For every '1' at i, a prefix count gives the '1's in [i − k, i + k]. O(n).
/// https://www.hackerrank.com/challenges/sherlock-and-probability
/// </summary>
public static class SherlockAndProbability
{
    public static string Solve(int k, string s)
    {
        int n = s.Length;
        var ones = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            ones[i + 1] = ones[i] + (s[i] == '1' ? 1 : 0);
        }

        long favourable = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1')
            {
                favourable += ones[Math.Min(n, i + k + 1)] - ones[Math.Max(0, i - k)];
            }
        }

        long total = (long)n * n;
        long gcd = favourable == 0 ? total : (long)System.Numerics.BigInteger.GreatestCommonDivisor(favourable, total);
        return $"{favourable / gcd}/{total / gcd}";
    }
}
