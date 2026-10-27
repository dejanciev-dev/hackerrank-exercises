namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// A Chocolate Fiesta — non-empty subsets with an even sum, modulo 1e9+7. Any choice of the
/// e even numbers works, and exactly half of the 2^o choices of odd numbers have even
/// parity, so 2^e · 2^(o-1) - 1 (or 2^e - 1 with no odd numbers).
/// https://www.hackerrank.com/challenges/a-chocolate-fiesta
/// </summary>
public static class ChocolateFiesta
{
    public static long Solve(IReadOnlyList<int> a)
    {
        int odd = a.Count(v => v % 2 != 0);
        int even = a.Count - odd;
        long subsets = ModularMath.Power(2, even + Math.Max(odd - 1, 0), ModularMath.Prime);

        return (subsets - 1 + ModularMath.Prime) % ModularMath.Prime;
    }
}
