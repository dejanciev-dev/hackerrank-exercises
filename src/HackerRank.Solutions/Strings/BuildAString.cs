namespace HackerRank.Solutions.Strings;

/// <summary>
/// Build a String — build s left to right: appending one character costs <c>a</c>, and
/// appending any substring of what's already built costs <c>b</c>; minimise the total.
/// best[i] is the cheapest way to build the first i characters. From position i, a
/// Z-function of s[i..] against s[0..i) finds the longest piece that can be copied.
/// O(n²).
/// https://www.hackerrank.com/challenges/build-a-string
/// </summary>
public static class BuildAString
{
    public static long Solve(int a, int b, string s)
    {
        int n = s.Length;
        var best = new long[n + 1];
        Array.Fill(best, long.MaxValue);
        best[0] = 0;

        for (int i = 0; i < n; i++)
        {
            best[i + 1] = Math.Min(best[i + 1], best[i] + a);

            int copyable = LongestEarlierMatch(s, i);
            for (int length = 1; length <= copyable; length++)
            {
                best[i + length] = Math.Min(best[i + length], best[i] + b);
            }
        }

        return best[n];
    }

    /// <summary>Longest prefix of s[i..] that occurs entirely inside s[0..i).</summary>
    private static int LongestEarlierMatch(string s, int i)
    {
        if (i == 0)
        {
            return 0;
        }

        // Z-function of pattern + separator + text; the text is the last part, so a match
        // starting at text position j can never run past index i.
        string t = string.Concat(s.AsSpan(i), "\u0001", s.AsSpan(0, i));
        var z = new int[t.Length];
        int left = 0, right = 0, best = 0;
        int textStart = s.Length - i + 1;

        for (int k = 1; k < t.Length; k++)
        {
            if (k < right)
            {
                z[k] = Math.Min(right - k, z[k - left]);
            }

            while (k + z[k] < t.Length && t[z[k]] == t[k + z[k]])
            {
                z[k]++;
            }

            if (k + z[k] > right)
            {
                left = k;
                right = k + z[k];
            }

            if (k >= textStart)
            {
                best = Math.Max(best, z[k]);
            }
        }

        return best;
    }
}
