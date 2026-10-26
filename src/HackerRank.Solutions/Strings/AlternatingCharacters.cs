namespace HackerRank.Solutions.Strings;

/// <summary>
/// Alternating Characters — minimum deletions so that no two adjacent characters match.
/// https://www.hackerrank.com/challenges/alternating-characters
/// </summary>
public static class AlternatingCharacters
{
    public static int Solve(string s)
    {
        int deletions = 0;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                deletions++;
            }
        }

        return deletions;
    }
}
