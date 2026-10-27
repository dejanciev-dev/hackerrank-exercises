namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Equations — count positive integer solutions of 1/x + 1/y = 1/n!, modulo 1000007.
/// Rearranged, (x - n!)(y - n!) = (n!)², so the solutions match the divisors of (n!)².
/// Legendre's formula gives each prime's exponent e in n!, and the divisor count is
/// Π (2e + 1).
/// https://www.hackerrank.com/challenges/equations
/// </summary>
public static class Equations
{
    private const long Mod = 1_000_007;

    public static long Solve(int n)
    {
        var composite = new bool[n + 1];
        long divisors = 1;

        for (int p = 2; p <= n; p++)
        {
            if (composite[p])
            {
                continue;
            }

            for (long multiple = (long)p * p; multiple <= n; multiple += p)
            {
                composite[multiple] = true;
            }

            long exponent = 0;
            for (long power = p; power <= n; power *= p)
            {
                exponent += n / power;
            }

            divisors = divisors * ((2 * exponent + 1) % Mod) % Mod;
        }

        return divisors;
    }
}
