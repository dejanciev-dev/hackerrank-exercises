namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Balanced Brackets — is every bracket in the string properly opened and closed in order?
/// Classic stack problem.
/// https://www.hackerrank.com/challenges/balanced-brackets
/// </summary>
public static class BalancedBrackets
{
    private static readonly Dictionary<char, char> Pairs = new()
    {
        [')'] = '(',
        [']'] = '[',
        ['}'] = '{',
    };

    public static string Solve(string s)
    {
        var open = new Stack<char>();

        foreach (var c in s)
        {
            if (Pairs.TryGetValue(c, out var expectedOpen))
            {
                if (!open.TryPop(out var top) || top != expectedOpen)
                {
                    return "NO";
                }
            }
            else
            {
                open.Push(c);
            }
        }

        return open.Count == 0 ? "YES" : "NO";
    }
}
