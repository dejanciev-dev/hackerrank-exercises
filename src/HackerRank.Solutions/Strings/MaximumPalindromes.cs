namespace HackerRank.Solutions.Strings;

/// <summary>
/// Maximum Palindromes — for each query (l, r), the number of longest palindromes that can be
/// built from the letters of s[l..r], modulo 1e9+7. With p_i pairs of each letter, the left
/// half is any arrangement of the pairs, (Σp)! / Π(p_i!), and any one leftover letter can sit
/// in the middle. Prefix letter counts and precomputed (inverse) factorials make each query
/// O(26).
/// https://www.hackerrank.com/challenges/maximum-palindromes
/// </summary>
public static class MaximumPalindromes
{
    private const long Mod = 1_000_000_007;

    /// <param name="s">The lowercase string the queries refer to.</param>
    /// <param name="queries">Each query as a 1-based inclusive <c>[l, r]</c>.</param>
    public static long[] Solve(string s, IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var prefix = new int[s.Length + 1, 26];
        for (int i = 0; i < s.Length; i++)
        {
            for (int letter = 0; letter < 26; letter++)
            {
                prefix[i + 1, letter] = prefix[i, letter];
            }

            prefix[i + 1, s[i] - 'a']++;
        }

        var factorial = new long[s.Length / 2 + 1];
        var inverse = new long[factorial.Length];
        factorial[0] = 1;
        for (int i = 1; i < factorial.Length; i++)
        {
            factorial[i] = factorial[i - 1] * i % Mod;
        }

        inverse[^1] = Power(factorial[^1], Mod - 2);
        for (int i = inverse.Length - 1; i > 0; i--)
        {
            inverse[i - 1] = inverse[i] * i % Mod;
        }

        var answers = new long[queries.Count];

        for (int q = 0; q < queries.Count; q++)
        {
            int l = queries[q][0];
            int r = queries[q][1];
            int pairs = 0;
            int singles = 0;
            long denominator = 1;

            for (int letter = 0; letter < 26; letter++)
            {
                int count = prefix[r, letter] - prefix[l - 1, letter];
                pairs += count / 2;
                singles += count % 2;
                denominator = denominator * inverse[count / 2] % Mod;
            }

            answers[q] = factorial[pairs] * denominator % Mod * Math.Max(singles, 1) % Mod;
        }

        return answers;
    }

    private static long Power(long value, long exponent)
    {
        long result = 1;
        value %= Mod;

        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                result = result * value % Mod;
            }

            value = value * value % Mod;
            exponent >>= 1;
        }

        return result;
    }
}
