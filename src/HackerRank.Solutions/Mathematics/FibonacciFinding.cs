namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Fibonacci Finding (easy) — F(n) for F(0) = a, F(1) = b, F(k) = F(k - 1) + F(k - 2),
/// modulo 1e9+7, for n up to 10^9. Any such sequence is a · fib(n - 1) + b · fib(n) in terms
/// of the standard Fibonacci numbers, which fast doubling gives in O(log n).
/// https://www.hackerrank.com/challenges/fibonacci-finding-easy
/// </summary>
public static class FibonacciFinding
{
    private const long Mod = 1_000_000_007;

    public static long Solve(long a, long b, long n)
    {
        if (n == 0)
        {
            return a % Mod;
        }

        var (fibN, fibNext) = Fib(n);
        long fibPrevious = (fibNext - fibN + Mod) % Mod;
        return (a % Mod * fibPrevious + b % Mod * fibN) % Mod;
    }

    /// <summary>(fib(n), fib(n + 1)) by fast doubling.</summary>
    private static (long, long) Fib(long n)
    {
        if (n == 0)
        {
            return (0, 1);
        }

        var (f, g) = Fib(n / 2);
        long even = f * ((2 * g - f + Mod) % Mod) % Mod; // fib(2k)
        long odd = (f * f + g * g) % Mod;                // fib(2k + 1)

        return n % 2 == 0 ? (even, odd) : (odd, (even + odd) % Mod);
    }
}
