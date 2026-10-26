namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Number Line Jumps (Kangaroo) — will two kangaroos starting at x1 and x2 with jump
/// distances v1 and v2 ever land on the same spot after the same number of jumps?
/// https://www.hackerrank.com/challenges/kangaroo
/// </summary>
public static class NumberLineJumps
{
    public static string Solve(int x1, int v1, int x2, int v2)
    {
        if (v1 == v2)
        {
            return x1 == x2 ? "YES" : "NO";
        }

        int distance = x2 - x1;
        int closingSpeed = v1 - v2;

        // They meet after distance / closingSpeed jumps, which must be a non-negative integer.
        bool meets = distance % closingSpeed == 0 && distance / closingSpeed >= 0;
        return meets ? "YES" : "NO";
    }
}
