namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Handshake — handshakes when each of <c>n</c> people shakes hands with every other person
/// once: n choose 2.
/// https://www.hackerrank.com/challenges/handshake
/// </summary>
public static class Handshake
{
    public static long Solve(long n) => n * (n - 1) / 2;
}
