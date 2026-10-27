namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Fibonacci GCD — gcd(F(a_1), ..., F(a_n)) modulo 1e9+7. Fibonacci numbers satisfy
/// gcd(F(a), F(b)) = F(gcd(a, b)), so the answer is F(gcd of the indices), computed by fast
/// doubling.
/// https://www.hackerrank.com/challenges/fibonacci-gcd
/// </summary>
public static class FibonacciGcd
{
    public static long Solve(IReadOnlyList<long> a) =>
        FibonacciFinding.Solve(0, 1, a.Aggregate(0L, ModularMath.Gcd));
}
