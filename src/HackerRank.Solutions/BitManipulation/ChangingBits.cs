using System.Text;

namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Changing Bits — two n-bit numbers a and b with point updates "set_a i x" and "set_b i x",
/// and queries "get_c i" for bit i of a + b. Bit i is a_i ⊕ b_i ⊕ carry_i, and the carry into
/// i is decided by the nearest lower position j where a_j = b_j: a 1 there generates a carry
/// that propagates up, a 0 kills it, and no such j means no carry. A sorted set of the
/// positions where the bits are equal answers that in O(log n).
/// https://www.hackerrank.com/challenges/changing-bits
/// </summary>
public static class ChangingBits
{
    /// <param name="a">a in binary, most significant bit first.</param>
    /// <param name="b">b in binary, most significant bit first, same length as a.</param>
    /// <param name="queries">The operations, in order.</param>
    public static string Solve(string a, string b, IReadOnlyList<string> queries)
    {
        int n = a.Length;
        var bitsA = new bool[n];
        var bitsB = new bool[n];
        var equal = new SortedSet<int>();

        for (int i = 0; i < n; i++)
        {
            bitsA[i] = a[n - 1 - i] == '1';
            bitsB[i] = b[n - 1 - i] == '1';
            if (bitsA[i] == bitsB[i])
            {
                equal.Add(i);
            }
        }

        var output = new StringBuilder();

        foreach (var query in queries)
        {
            var parts = query.Split(' ');
            int index = int.Parse(parts[1]);

            if (parts[0] == "get_c")
            {
                bool carry = false;
                if (index > 0)
                {
                    var below = equal.GetViewBetween(0, Math.Min(index, n) - 1);
                    carry = below.Count > 0 && bitsA[below.Max];
                }

                bool bit = index < n ? bitsA[index] ^ bitsB[index] ^ carry : carry;
                output.Append(bit ? '1' : '0');
                continue;
            }

            bool value = parts[2] == "1";
            if (parts[0] == "set_a")
            {
                bitsA[index] = value;
            }
            else
            {
                bitsB[index] = value;
            }

            if (bitsA[index] == bitsB[index])
            {
                equal.Add(index);
            }
            else
            {
                equal.Remove(index);
            }
        }

        return output.ToString();
    }
}
