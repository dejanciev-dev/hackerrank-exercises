using System.Text;

namespace HackerRank.Solutions.Strings;

/// <summary>
/// Separate the Numbers — is the numeric string a sequence of two or more increasing
/// consecutive positive integers without leading zeros? Returns "YES x" with the first
/// number x, or "NO".
/// https://www.hackerrank.com/challenges/separate-the-numbers
/// </summary>
public static class SeparateTheNumbers
{
    public static string Solve(string s)
    {
        if (s.Length < 2 || s[0] == '0')
        {
            return "NO";
        }

        // Try every possible length for the first number; it must leave room for a second one.
        for (int length = 1; length <= s.Length / 2; length++)
        {
            long first = long.Parse(s[..length]);
            var sequence = new StringBuilder();
            long next = first;

            while (sequence.Length < s.Length)
            {
                sequence.Append(next++);
            }

            if (sequence.ToString() == s)
            {
                return $"YES {first}";
            }
        }

        return "NO";
    }
}
