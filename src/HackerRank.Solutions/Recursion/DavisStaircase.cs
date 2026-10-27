namespace HackerRank.Solutions.Recursion;

/// <summary>
/// Recursion: Davis' Staircase — number of ways to climb <c>n</c> steps taking 1, 2 or 3 at a
/// time. ways(n) = ways(n - 1) + ways(n - 2) + ways(n - 3), memoized.
/// https://www.hackerrank.com/challenges/ctci-recursive-staircase
/// </summary>
public static class DavisStaircase
{
    public static long Solve(int n) => Ways(n, new long?[n + 1]);

    private static long Ways(int n, long?[] memo)
    {
        if (n < 0)
        {
            return 0;
        }

        if (n == 0)
        {
            return 1;
        }

        return memo[n] ??= Ways(n - 1, memo) + Ways(n - 2, memo) + Ways(n - 3, memo);
    }
}
