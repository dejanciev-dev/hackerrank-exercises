namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Maximum Draws — socks to draw from a drawer with <c>n</c> colours to be sure of a matching
/// pair. Pigeonhole principle: after n socks they could all differ, so n + 1.
/// https://www.hackerrank.com/challenges/maximum-draws
/// </summary>
public static class MaximumDraws
{
    public static int Solve(int n) => n + 1;
}
