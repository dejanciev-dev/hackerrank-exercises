using System.Text;

namespace HackerRank.Solutions.Strings;

/// <summary>
/// Caesar Cipher — rotate every letter by <c>k</c> positions, wrapping around the alphabet
/// and preserving case. Non-letters are left unchanged.
/// https://www.hackerrank.com/challenges/caesar-cipher-1
/// </summary>
public static class CaesarCipher
{
    public static string Solve(string s, int k)
    {
        var sb = new StringBuilder(s.Length);
        k %= 26;

        foreach (var c in s)
        {
            if (char.IsAsciiLetterUpper(c))
            {
                sb.Append(Rotate(c, 'A', k));
            }
            else if (char.IsAsciiLetterLower(c))
            {
                sb.Append(Rotate(c, 'a', k));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    private static char Rotate(char c, char firstLetter, int k) =>
        (char)(firstLetter + (c - firstLetter + k) % 26);
}
