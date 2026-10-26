namespace HackerRank.Solutions.Strings;

/// <summary>
/// CamelCase — count the words in a camelCase string (first word lowercase, others capitalized).
/// https://www.hackerrank.com/challenges/camelcase
/// </summary>
public static class CamelCase
{
    public static int Solve(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }

        return 1 + s.Count(char.IsUpper);
    }
}
