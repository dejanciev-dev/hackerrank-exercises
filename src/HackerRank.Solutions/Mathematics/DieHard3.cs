namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Die Hard 3 — with an unlimited water supply and two jugs of capacity a and b liters, can
/// exactly c liters be left in one of the jugs? Every amount that is a multiple of gcd(a, b) can
/// be produced (Bézout), but a jug never holds more than its capacity, so the answer is "YES"
/// exactly when c ≤ max(a, b) and gcd(a, b) divides c. O(log n).
/// https://www.hackerrank.com/challenges/die-hard-3
/// </summary>
public static class DieHard3
{
    public static string Solve(int a, int b, int c) =>
        c <= Math.Max(a, b) && c % (int)ModularMath.Gcd(a, b) == 0 ? "YES" : "NO";
}
