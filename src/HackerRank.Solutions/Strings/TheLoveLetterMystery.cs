namespace HackerRank.Solutions.Strings;

/// <summary>
/// The Love-Letter Mystery — minimum single-letter decrements needed to turn <c>s</c> into a palindrome.
/// https://www.hackerrank.com/challenges/the-love-letter-mystery
/// </summary>
public static class TheLoveLetterMystery
{
    public static int Solve(string s)
    {
        int operations = 0;

        for (int i = 0; i < s.Length / 2; i++)
        {
            operations += Math.Abs(s[i] - s[s.Length - 1 - i]);
        }

        return operations;
    }
}
