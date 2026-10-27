namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Summing the N series — sum of the first <c>n</c> terms of T(k) = k² - (k - 1)², modulo
/// 1e9+7. The sum telescopes to n²; reduce n first so the square fits in a long.
/// https://www.hackerrank.com/challenges/summing-the-n-series
/// </summary>
public static class SummingTheNSeries
{
    private const long Mod = 1_000_000_007;

    public static long Solve(long n)
    {
        long reduced = n % Mod;
        return reduced * reduced % Mod;
    }
}
