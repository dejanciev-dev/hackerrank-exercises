namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Square Subsequences — count the subsequences (by index set) of s that read as some
/// non-empty string concatenated with itself, modulo 10^9 + 7.
/// Fix where the first half ends: at index k − 1. Then count pairs of equal subsequences of
/// s[..k] and s[k..] that use s[k − 1], which is the number of common-subsequence pairs of
/// s[..k] and s[k..] minus those of s[..k−1] and s[k..]. O(n³).
/// https://www.hackerrank.com/challenges/square-subsequences
/// </summary>
public static class SquareSubsequences
{
    private const long Mod = 1_000_000_007;

    public static long Solve(string s)
    {
        int n = s.Length;
        long total = 0;

        for (int k = 1; k < n; k++)
        {
            // pairs[i, j]: non-empty equal-subsequence pairs drawn from s[..i] and s[k..k+j].
            int m = n - k;
            var pairs = new long[k + 1, m + 1];
            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    long value = pairs[i - 1, j] + pairs[i, j - 1] - pairs[i - 1, j - 1];
                    if (s[i - 1] == s[k + j - 1])
                    {
                        value += pairs[i - 1, j - 1] + 1;
                    }

                    pairs[i, j] = (value % Mod + Mod) % Mod;
                }
            }

            total += pairs[k, m] - pairs[k - 1, m] + Mod;
        }

        return total % Mod;
    }
}
