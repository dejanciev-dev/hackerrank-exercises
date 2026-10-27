namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Matrix Tracing — ways to spell the word written across an m x n grid, moving only right or
/// down from the top-left to the bottom-right: C(m + n - 2, m - 1) monotone paths,
/// modulo 1e9+7.
/// https://www.hackerrank.com/challenges/matrix-tracing
/// </summary>
public static class MatrixTracing
{
    public static long Solve(int m, int n) => ModularMath.Binomial(m + n - 2, m - 1);
}
