namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Play with words — the largest product of the lengths of two palindromic subsequences that
/// don't overlap (every index of the first is before every index of the second). Fill the
/// longest-palindromic-subsequence table, then try every split point:
/// max over k of lps(0, k) · lps(k + 1, n - 1). O(n²).
/// https://www.hackerrank.com/challenges/strplay
/// </summary>
public static class PlayWithWords
{
    public static long Solve(string s)
    {
        int n = s.Length;
        var lps = new int[n, n];

        for (int i = n - 1; i >= 0; i--)
        {
            lps[i, i] = 1;
            for (int j = i + 1; j < n; j++)
            {
                lps[i, j] = s[i] == s[j]
                    ? lps[i + 1, j - 1] + 2
                    : Math.Max(lps[i + 1, j], lps[i, j - 1]);
            }
        }

        long best = 0;
        for (int k = 0; k + 1 < n; k++)
        {
            best = Math.Max(best, (long)lps[0, k] * lps[k + 1, n - 1]);
        }

        return best;
    }
}
