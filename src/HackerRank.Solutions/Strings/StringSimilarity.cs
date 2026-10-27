namespace HackerRank.Solutions.Strings;

/// <summary>
/// String Similarity — sum, over every suffix of <c>s</c>, of the length of its longest common
/// prefix with <c>s</c>. That's exactly the sum of the Z-array (plus the whole string for
/// the suffix starting at 0). Z-algorithm, O(n).
/// https://www.hackerrank.com/challenges/string-similarity
/// </summary>
public static class StringSimilarity
{
    public static long Solve(string s)
    {
        int n = s.Length;
        var z = new int[n];
        long total = n;
        int left = 0;
        int right = 0;

        for (int i = 1; i < n; i++)
        {
            if (i < right)
            {
                z[i] = Math.Min(right - i, z[i - left]);
            }

            while (i + z[i] < n && s[z[i]] == s[i + z[i]])
            {
                z[i]++;
            }

            if (i + z[i] > right)
            {
                left = i;
                right = i + z[i];
            }

            total += z[i];
        }

        return total;
    }
}
