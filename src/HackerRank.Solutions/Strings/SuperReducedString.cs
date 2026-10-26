using System.Text;

namespace HackerRank.Solutions.Strings;

/// <summary>
/// Super Reduced String — repeatedly delete pairs of adjacent equal letters.
/// A StringBuilder used as a stack does it in a single O(n) pass.
/// https://www.hackerrank.com/challenges/reduced-string
/// </summary>
public static class SuperReducedString
{
    public static string Solve(string s)
    {
        var stack = new StringBuilder(s.Length);

        foreach (var c in s)
        {
            if (stack.Length > 0 && stack[^1] == c)
            {
                stack.Length--;
            }
            else
            {
                stack.Append(c);
            }
        }

        return stack.Length > 0 ? stack.ToString() : "Empty String";
    }
}
