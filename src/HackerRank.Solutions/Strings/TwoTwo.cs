using System.Numerics;

namespace HackerRank.Solutions.Strings;

/// <summary>
/// Two Two — count substrings that are powers of two, 2^0 through 2^800. The 801 powers
/// (written in decimal, at most 242 digits) go into a digit trie built once. From each
/// non-zero starting digit, walk the trie and count every power that ends along the way.
/// O(n · 242).
/// https://www.hackerrank.com/challenges/two-two
/// </summary>
public static class TwoTwo
{
    private static readonly (int[] Children, bool[] IsPower) Trie = BuildTrie();

    public static long Solve(string a)
    {
        var (children, isPower) = Trie;
        long count = 0;

        for (int start = 0; start < a.Length; start++)
        {
            if (a[start] == '0')
            {
                continue;
            }

            for (int i = start, node = 0; i < a.Length; i++)
            {
                node = children[node * 10 + (a[i] - '0')];
                if (node == 0)
                {
                    break;
                }

                if (isPower[node])
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static (int[] Children, bool[] IsPower) BuildTrie()
    {
        var children = new List<int>(new int[10]);
        var isPower = new List<bool> { false };
        var power = BigInteger.One;

        for (int exponent = 0; exponent <= 800; exponent++, power <<= 1)
        {
            int node = 0;
            foreach (var digit in power.ToString())
            {
                int slot = node * 10 + (digit - '0');
                if (children[slot] == 0)
                {
                    children[slot] = isPower.Count;
                    isPower.Add(false);
                    children.AddRange(new int[10]);
                }

                node = children[slot];
            }

            isPower[node] = true;
        }

        return (children.ToArray(), isPower.ToArray());
    }
}
