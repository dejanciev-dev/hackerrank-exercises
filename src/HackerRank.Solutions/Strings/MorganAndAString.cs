using System.Text;

namespace HackerRank.Solutions.Strings;

/// <summary>
/// Morgan and a String — merge two stacks of uppercase letters, always taking from the top of
/// one, into the lexicographically smallest string. Compare the remaining suffixes rather
/// than single letters to break ties correctly; a sentinel after 'Z' makes an exhausted stack
/// lose every comparison and stops a shorter prefix from winning too early.
/// https://www.hackerrank.com/challenges/morgan-and-a-string
/// </summary>
public static class MorganAndAString
{
    private const char Sentinel = 'z';

    public static string Solve(string a, string b)
    {
        string first = a + Sentinel;
        string second = b + Sentinel;
        var merged = new StringBuilder(a.Length + b.Length);
        int i = 0;
        int j = 0;

        while (i < a.Length || j < b.Length)
        {
            if (first.AsSpan(i).SequenceCompareTo(second.AsSpan(j)) <= 0)
            {
                merged.Append(first[i++]);
            }
            else
            {
                merged.Append(second[j++]);
            }
        }

        return merged.ToString();
    }
}
