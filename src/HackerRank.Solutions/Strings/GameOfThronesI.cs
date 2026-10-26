namespace HackerRank.Solutions.Strings;

/// <summary>
/// Game of Thrones - I — can any anagram of <c>s</c> be a palindrome?
/// True when at most one character appears an odd number of times.
/// https://www.hackerrank.com/challenges/game-of-thrones
/// </summary>
public static class GameOfThronesI
{
    public static string Solve(string s)
    {
        var oddCharacters = new HashSet<char>();

        foreach (var c in s)
        {
            if (!oddCharacters.Remove(c))
            {
                oddCharacters.Add(c);
            }
        }

        return oddCharacters.Count <= 1 ? "YES" : "NO";
    }
}
