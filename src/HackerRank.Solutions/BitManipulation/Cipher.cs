using System.Text;

namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Cipher — the message b was written k times, each shifted one more place right, and the
/// columns XORed into s; recover b. Since s[i] = b[i] ^ ... ^ b[i - k + 1], adjacent output
/// bits give b[i] = s[i] ^ s[i - 1] ^ b[i - k]. O(n).
/// https://www.hackerrank.com/challenges/cipher
/// </summary>
public static class Cipher
{
    public static string Solve(int n, int k, string s)
    {
        var bits = new int[n];
        var decoded = new StringBuilder(n);

        for (int i = 0; i < n; i++)
        {
            bits[i] = s[i] - '0';
            if (i > 0)
            {
                bits[i] ^= s[i - 1] - '0';
            }

            if (i >= k)
            {
                bits[i] ^= bits[i - k];
            }

            decoded.Append((char)('0' + bits[i]));
        }

        return decoded.ToString();
    }
}
