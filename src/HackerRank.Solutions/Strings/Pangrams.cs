namespace HackerRank.Solutions.Strings;

/// <summary>
/// Pangrams — does the sentence use every letter of the English alphabet (case-insensitive)?
/// https://www.hackerrank.com/challenges/pangrams
/// </summary>
public static class Pangrams
{
    public static string Solve(string s)
    {
        var letters = new HashSet<char>();

        foreach (var c in s)
        {
            if (char.IsAsciiLetter(c))
            {
                letters.Add(char.ToLowerInvariant(c));
            }
        }

        return letters.Count == 26 ? "pangram" : "not pangram";
    }
}
