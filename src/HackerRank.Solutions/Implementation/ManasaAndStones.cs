namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Manasa and Stones — consecutive stones differ by <c>a</c> or <c>b</c>, starting at 0.
/// List every possible value of the last of <c>n</c> stones in ascending order.
/// Only the count of b-steps matters, so there are at most n candidates.
/// https://www.hackerrank.com/challenges/manasa-and-stones
/// </summary>
public static class ManasaAndStones
{
    public static int[] Solve(int n, int a, int b)
    {
        var values = new SortedSet<int>();

        for (int bSteps = 0; bSteps < n; bSteps++)
        {
            values.Add((n - 1 - bSteps) * a + bSteps * b);
        }

        return values.ToArray();
    }
}
