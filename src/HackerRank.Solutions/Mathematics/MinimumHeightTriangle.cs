namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Minimum Height Triangle — smallest integer height for a triangle with the given base and
/// at least the given area: ⌈2 · area / base⌉, in integer arithmetic.
/// https://www.hackerrank.com/challenges/lowest-triangle
/// </summary>
public static class MinimumHeightTriangle
{
    public static int Solve(int trianglebase, int area) => (2 * area + trianglebase - 1) / trianglebase;
}
