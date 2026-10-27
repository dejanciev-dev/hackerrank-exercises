namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Easy GCD — the largest x ≤ <c>k</c> such that adding x to A keeps the gcd above 1. x must
/// share a prime factor with g = gcd(A), and for each prime factor p the best choice is the
/// largest multiple of p up to k.
/// https://www.hackerrank.com/challenges/easy-gcd-1
/// </summary>
public static class EasyGcd
{
    public static long Solve(long k, IReadOnlyList<long> a)
    {
        long g = a.Aggregate(0L, ModularMath.Gcd);
        return ModularMath.PrimeFactors(g).Select(p => k / p * p).DefaultIfEmpty(0).Max();
    }
}
