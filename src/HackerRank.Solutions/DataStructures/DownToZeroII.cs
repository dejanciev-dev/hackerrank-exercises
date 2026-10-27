namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Down to Zero II — fewest moves to bring <c>n</c> to 0, where a move either subtracts 1 or
/// replaces n = a · b (a, b &gt; 1) with max(a, b). Forward DP: once steps[i] is final, relax
/// i + 1 and every i · j with j ≤ i (whose larger factor is i). O(n log n).
/// https://www.hackerrank.com/challenges/down-to-zero-ii
/// </summary>
public static class DownToZeroII
{
    public static int Solve(int n)
    {
        var steps = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            steps[i] = i;
        }

        for (int i = 1; i < n; i++)
        {
            steps[i + 1] = Math.Min(steps[i + 1], steps[i] + 1);

            for (long j = 2; j <= i && i * j <= n; j++)
            {
                steps[i * j] = Math.Min(steps[i * j], steps[i] + 1);
            }
        }

        return steps[n];
    }
}
