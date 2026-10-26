namespace HackerRank.Solutions.Strings;

/// <summary>
/// Two Strings — do the strings share a common substring? A single shared character is enough.
/// https://www.hackerrank.com/challenges/two-strings
/// </summary>
public static class TwoStrings
{
    public static string Solve(string s1, string s2)
    {
        return s1.Intersect(s2).Any() ? "YES" : "NO";
    }
}
