namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// LCS Returns — count the ways (position, character) to insert one character into a so that
/// LCS(a, b) grows by one.
/// With prefix LCS tables f(i, j) for a[..i], b[..j] and suffix tables g(i, j) for a[i..], b[j..],
/// inserting c at position i helps exactly when some j with b[j] = c has
/// f(i, j) + g(i, j + 1) = LCS(a, b). O(|a| · |b|).
/// https://www.hackerrank.com/challenges/tutorial-lcs-returns
/// </summary>
public static class LcsReturns
{
    public static int Solve(string a, string b)
    {
        int n = a.Length, m = b.Length;
        var prefix = new int[n + 1, m + 1];
        var suffix = new int[n + 2, m + 2];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                prefix[i, j] = a[i - 1] == b[j - 1]
                    ? prefix[i - 1, j - 1] + 1
                    : Math.Max(prefix[i - 1, j], prefix[i, j - 1]);
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                suffix[i, j] = a[i] == b[j]
                    ? suffix[i + 1, j + 1] + 1
                    : Math.Max(suffix[i + 1, j], suffix[i, j + 1]);
            }
        }

        int lcs = prefix[n, m], ways = 0;
        var used = new bool[128];
        for (int i = 0; i <= n; i++)
        {
            Array.Clear(used);
            for (int j = 0; j < m; j++)
            {
                if (!used[b[j]] && prefix[i, j] + suffix[i, j + 1] == lcs)
                {
                    used[b[j]] = true;
                    ways++;
                }
            }
        }

        return ways;
    }
}
