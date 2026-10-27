namespace HackerRank.Solutions.Strings;

/// <summary>
/// Save Humanity — the 0-based positions where the virus v matches the patient's DNA p with
/// at most one mismatch, or "No Match!". A Z-function of v against p gives how far each
/// window agrees from the left, and one on the reversed strings gives how far it agrees from
/// the right. A window fits when the two together cover all but at most one character. O(n).
/// https://www.hackerrank.com/challenges/save-humanity
/// </summary>
public static class SaveHumanity
{
    public static string Solve(string p, string v)
    {
        int n = p.Length;
        int m = v.Length;
        if (m > n)
        {
            return "No Match!";
        }

        var fromLeft = MatchLengths(v, p);
        var fromRight = MatchLengths(new string(v.Reverse().ToArray()), new string(p.Reverse().ToArray()));
        var positions = new List<int>();

        for (int i = 0; i + m <= n; i++)
        {
            int left = Math.Min(fromLeft[i], m);
            int right = Math.Min(fromRight[n - (i + m)], m);
            if (left + right >= m - 1)
            {
                positions.Add(i);
            }
        }

        return positions.Count > 0 ? string.Join(' ', positions) : "No Match!";
    }

    /// <summary>For each position i of text, the length of the common prefix of text[i..] and pattern.</summary>
    private static int[] MatchLengths(string pattern, string text)
    {
        string s = pattern + '\u0001' + text;
        var z = new int[s.Length];
        for (int k = 1, left = 0, right = 0; k < s.Length; k++)
        {
            if (k < right)
            {
                z[k] = Math.Min(right - k, z[k - left]);
            }

            while (k + z[k] < s.Length && s[z[k]] == s[k + z[k]])
            {
                z[k]++;
            }

            if (k + z[k] > right)
            {
                left = k;
                right = k + z[k];
            }
        }

        return z[(pattern.Length + 1)..];
    }
}
