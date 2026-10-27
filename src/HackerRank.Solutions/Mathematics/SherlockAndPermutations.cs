namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Sherlock and Permutations — distinct arrangements of <c>n</c> zeros and <c>m</c> ones that
/// start with a 1, modulo 1e9+7. Fix the leading 1; the remaining n + m - 1 positions choose
/// where the n zeros go: C(n + m - 1, n).
/// https://www.hackerrank.com/challenges/sherlock-and-permutations
/// </summary>
public static class SherlockAndPermutations
{
    public static long Solve(int n, int m) => ModularMath.Binomial(n + m - 1, n);
}
