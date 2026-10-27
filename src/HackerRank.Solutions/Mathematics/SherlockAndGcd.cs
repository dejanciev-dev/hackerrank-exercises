namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Sherlock and GCD — does some non-empty subset have gcd 1? Adding elements can only lower a
/// gcd, so such a subset exists exactly when the gcd of the whole array is 1.
/// https://www.hackerrank.com/challenges/sherlock-and-gcd
/// </summary>
public static class SherlockAndGcd
{
    public static string Solve(IReadOnlyList<long> a) =>
        a.Aggregate(0L, ModularMath.Gcd) == 1 ? "YES" : "NO";
}
