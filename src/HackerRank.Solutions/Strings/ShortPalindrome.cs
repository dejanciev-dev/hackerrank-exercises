namespace HackerRank.Solutions.Strings;

/// <summary>
/// Short Palindrome — count index tuples a &lt; b &lt; c &lt; d with s[a] = s[d] and
/// s[b] = s[c], modulo 1e9+7. Scan once, keeping counts of the subsequences "x", "xy" and
/// "xyy" so far for every letter pair; each new letter x closes every earlier "xyy".
/// O(26 · n) time, O(26²) memory.
/// https://www.hackerrank.com/challenges/short-palindrome
/// </summary>
public static class ShortPalindrome
{
    private const long Mod = 1_000_000_007;

    public static long Solve(string s)
    {
        var single = new long[26];
        var pair = new long[26, 26];   // pair[x, y]: subsequences "x y"
        var triple = new long[26, 26]; // triple[x, y]: subsequences "x y y"
        long total = 0;

        foreach (var ch in s)
        {
            int c = ch - 'a';

            for (int other = 0; other < 26; other++)
            {
                total = (total + triple[c, other]) % Mod;
            }

            for (int first = 0; first < 26; first++)
            {
                triple[first, c] = (triple[first, c] + pair[first, c]) % Mod;
                pair[first, c] = (pair[first, c] + single[first]) % Mod;
            }

            single[c]++;
        }

        return total;
    }
}
