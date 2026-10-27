namespace HackerRank.Solutions.Recursion;

/// <summary>
/// Password Cracker — split <c>loginAttempt</c> into a sequence of the given passwords
/// (reuse allowed), or report "WRONG PASSWORD". Depth-first search over split points, with a
/// memo of positions already known to be dead ends, so each position is explored once.
/// https://www.hackerrank.com/challenges/password-cracker
/// </summary>
public static class PasswordCracker
{
    public static string Solve(IReadOnlyList<string> passwords, string loginAttempt)
    {
        var deadEnd = new bool[loginAttempt.Length];
        var used = new List<string>();

        return Split(passwords, loginAttempt, 0, deadEnd, used)
            ? string.Join(' ', used)
            : "WRONG PASSWORD";
    }

    private static bool Split(IReadOnlyList<string> passwords, string attempt, int start, bool[] deadEnd, List<string> used)
    {
        if (start == attempt.Length)
        {
            return true;
        }

        if (deadEnd[start])
        {
            return false;
        }

        foreach (var password in passwords)
        {
            if (attempt.AsSpan(start).StartsWith(password, StringComparison.Ordinal))
            {
                used.Add(password);
                if (Split(passwords, attempt, start + password.Length, deadEnd, used))
                {
                    return true;
                }

                used.RemoveAt(used.Count - 1);
            }
        }

        deadEnd[start] = true;
        return false;
    }
}
