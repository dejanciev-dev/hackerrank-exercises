namespace HackerRank.Solutions.Strings;

/// <summary>
/// HackerRank in a String! — does <c>s</c> contain "hackerrank" as a subsequence?
/// https://www.hackerrank.com/challenges/hackerrank-in-a-string
/// </summary>
public static class HackerRankInAString
{
    private const string Target = "hackerrank";

    public static string Solve(string s)
    {
        int matched = 0;

        foreach (var c in s)
        {
            if (matched < Target.Length && c == Target[matched])
            {
                matched++;
            }
        }

        return matched == Target.Length ? "YES" : "NO";
    }
}
