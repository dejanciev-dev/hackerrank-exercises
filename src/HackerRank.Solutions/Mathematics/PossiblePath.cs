namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Possible Path — from (a, b) you may move to (a + b, b), (a, a + b), (a - b, b) or
/// (a, b - a). Every move keeps the gcd, and the moves can reach any pair with the same gcd,
/// so (x, y) is reachable exactly when gcd(a, b) = gcd(x, y).
/// https://www.hackerrank.com/challenges/possible-path
/// </summary>
public static class PossiblePath
{
    public static string Solve(long a, long b, long x, long y) => Gcd(a, b) == Gcd(x, y) ? "YES" : "NO";

    private static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);
}
