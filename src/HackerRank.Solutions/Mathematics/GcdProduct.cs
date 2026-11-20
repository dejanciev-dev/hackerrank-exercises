namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// GCD Product — find the product of gcd(i, j) over all 1 ≤ i ≤ n and 1 ≤ j ≤ m, modulo
/// 10^9 + 7. Only primes p ≤ min(n, m) appear, and p divides gcd(i, j) once for every power
/// p^k that divides both i and j, so its exponent in the product is
/// Σ over k ≥ 1 of ⌊n / p^k⌋ · ⌊m / p^k⌋. A sieve over min(n, m) and a modular power per prime
/// finish the job. O(min(n, m) log log min(n, m)).
/// https://www.hackerrank.com/challenges/gcd-product
/// </summary>
public static class GcdProduct
{
    private const long Modulus = 1_000_000_007;

    public static long Solve(long n, long m)
    {
        int limit = (int)Math.Min(n, m);
        var composite = new bool[limit + 1];
        long product = 1;

        for (int p = 2; p <= limit; p++)
        {
            if (composite[p])
            {
                continue;
            }

            for (long multiple = (long)p * p; multiple <= limit; multiple += p)
            {
                composite[multiple] = true;
            }

            long exponent = 0;
            for (long power = p; power <= limit; power *= p)
            {
                exponent += n / power * (m / power);
            }

            product = product * ModularMath.Power(p, exponent, Modulus) % Modulus;
        }

        return product;
    }
}
