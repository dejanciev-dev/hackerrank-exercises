using System.Text;

namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// A or B — change at most <c>k</c> bits of A and B (given in hex) so that A' OR B' = C,
/// choosing the smallest A', then the smallest B'. First make the result correct: where C
/// is 0 both bits must be cleared, and where C is 1 but neither is set, set B (that keeps
/// A small). Then spend what's left, from the top bit down, clearing A's 1 bits. That costs
/// 1 if B already has the bit and 2 otherwise (B must take it over). Returns ["-1"] if even
/// the required changes exceed k.
/// https://www.hackerrank.com/challenges/aorb
/// </summary>
public static class AOrB
{
    public static string[] Solve(int k, string a, string b, string c)
    {
        int width = 4 * Math.Max(a.Length, Math.Max(b.Length, c.Length));
        var bitsA = ToBits(a, width);
        var bitsB = ToBits(b, width);
        var bitsC = ToBits(c, width);
        int budget = k;

        for (int i = 0; i < width; i++)
        {
            if (!bitsC[i])
            {
                budget -= (bitsA[i] ? 1 : 0) + (bitsB[i] ? 1 : 0);
                bitsA[i] = bitsB[i] = false;
            }
            else if (!bitsA[i] && !bitsB[i])
            {
                budget--;
                bitsB[i] = true;
            }
        }

        if (budget < 0)
        {
            return ["-1"];
        }

        for (int i = 0; i < width && budget > 0; i++)
        {
            if (!bitsA[i])
            {
                continue;
            }

            int cost = bitsB[i] ? 1 : 2;
            if (cost <= budget)
            {
                budget -= cost;
                bitsA[i] = false;
                bitsB[i] = true;
            }
        }

        return [ToHex(bitsA), ToHex(bitsB)];
    }

    /// <summary>Bits from most to least significant, left-padded to <paramref name="width"/>.</summary>
    private static bool[] ToBits(string hex, int width)
    {
        var bits = new bool[width];
        int offset = width - 4 * hex.Length;

        for (int i = 0; i < hex.Length; i++)
        {
            int value = Convert.ToInt32(hex[i].ToString(), 16);
            for (int b = 0; b < 4; b++)
            {
                bits[offset + 4 * i + b] = (value & (8 >> b)) != 0;
            }
        }

        return bits;
    }

    private static string ToHex(bool[] bits)
    {
        var hex = new StringBuilder();
        for (int i = 0; i < bits.Length; i += 4)
        {
            int value = 0;
            for (int b = 0; b < 4; b++)
            {
                value = value * 2 + (bits[i + b] ? 1 : 0);
            }

            if (hex.Length > 0 || value != 0)
            {
                hex.Append("0123456789ABCDEF"[value]);
            }
        }

        return hex.Length > 0 ? hex.ToString() : "0";
    }
}
