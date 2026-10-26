namespace HackerRank.Solutions.Warmup;

/// <summary>
/// Staircase — build a right-aligned staircase of '#' symbols of height <c>n</c>.
/// https://www.hackerrank.com/challenges/staircase
/// </summary>
public static class Staircase
{
    public static string[] Solve(int n)
    {
        var rows = new string[n];
        for (int i = 0; i < n; i++)
        {
            int steps = i + 1;
            rows[i] = new string(' ', n - steps) + new string('#', steps);
        }

        return rows;
    }
}
