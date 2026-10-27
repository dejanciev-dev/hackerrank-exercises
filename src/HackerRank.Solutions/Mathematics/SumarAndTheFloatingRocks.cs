namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Sumar and the Floating Rocks — lattice points strictly between two lattice points on a
/// segment: gcd(|dx|, |dy|) - 1.
/// https://www.hackerrank.com/challenges/harry-potter-and-the-floating-rocks
/// </summary>
public static class SumarAndTheFloatingRocks
{
    public static long Solve(long x1, long y1, long x2, long y2) =>
        ModularMath.Gcd(x2 - x1, y2 - y1) - 1;
}
