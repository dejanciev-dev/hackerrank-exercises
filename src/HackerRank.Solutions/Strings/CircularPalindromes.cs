namespace HackerRank.Solutions.Strings;

/// <summary>
/// Circular Palindromes — for each of the n rotations of s, the length of its longest
/// palindromic substring. Manacher's algorithm on each rotation, O(n) apiece, so O(n²)
/// overall.
/// https://www.hackerrank.com/challenges/circular-palindromes
/// </summary>
public static class CircularPalindromes
{
    public static int[] Solve(string s)
    {
        var lengths = new int[s.Length];
        for (int k = 0; k < s.Length; k++)
        {
            lengths[k] = LongestPalindrome(string.Concat(s.AsSpan(k), s.AsSpan(0, k)));
        }

        return lengths;
    }

    private static int LongestPalindrome(string s)
    {
        // Manacher on the string with separators between characters, so even and odd
        // palindromes are handled the same way.
        var t = new char[2 * s.Length + 1];
        for (int i = 0; i < s.Length; i++)
        {
            t[2 * i] = '\0';
            t[2 * i + 1] = s[i];
        }

        t[^1] = '\0';
        var radius = new int[t.Length];
        int center = 0, right = 0, best = 0;

        for (int i = 0; i < t.Length; i++)
        {
            if (i < right)
            {
                radius[i] = Math.Min(right - i, radius[2 * center - i]);
            }

            while (i - radius[i] - 1 >= 0 && i + radius[i] + 1 < t.Length && t[i - radius[i] - 1] == t[i + radius[i] + 1])
            {
                radius[i]++;
            }

            if (i + radius[i] > right)
            {
                center = i;
                right = i + radius[i];
            }

            best = Math.Max(best, radius[i]);
        }

        return best;
    }
}
