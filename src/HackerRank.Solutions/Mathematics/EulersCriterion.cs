namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Euler's Criterion — does x² ≡ a (mod M) have a solution, for prime M? Yes when
/// a^((M-1)/2) ≡ 1 (mod M), and trivially when a = 0 or M = 2. O(log M).
/// https://www.hackerrank.com/challenges/eulers-criterion
/// </summary>
public static class EulersCriterion
{
    public static string Solve(long a, long m)
    {
        if (a % m == 0 || m == 2)
        {
            return "YES";
        }

        return ModularMath.Power(a, (m - 1) / 2, m) == 1 ? "YES" : "NO";
    }
}
