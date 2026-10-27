namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Modular arithmetic helpers shared by the number theory and combinatorics problems.
/// </summary>
internal static class ModularMath
{
    public const long Prime = 1_000_000_007;

    /// <summary>value^exponent mod modulus; modulus must be below ~3·10^9 so products fit in a long.</summary>
    public static long Power(long value, long exponent, long modulus)
    {
        long result = 1 % modulus;
        value %= modulus;
        if (value < 0)
        {
            value += modulus;
        }

        for (; exponent > 0; exponent >>= 1)
        {
            if ((exponent & 1) == 1)
            {
                result = result * value % modulus;
            }

            value = value * value % modulus;
        }

        return result;
    }

    /// <summary>n choose k mod <see cref="Prime"/>, via Fermat inverses. O(k log p).</summary>
    public static long Binomial(long n, long k)
    {
        if (k < 0 || k > n)
        {
            return 0;
        }

        k = Math.Min(k, n - k);
        long numerator = 1;
        long denominator = 1;

        for (long i = 0; i < k; i++)
        {
            numerator = numerator * ((n - i) % Prime) % Prime;
            denominator = denominator * ((i + 1) % Prime) % Prime;
        }

        return numerator * Power(denominator, Prime - 2, Prime) % Prime;
    }

    public static long Gcd(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }

    /// <summary>The distinct prime factors of n, by trial division. O(√n).</summary>
    public static List<long> PrimeFactors(long n)
    {
        var factors = new List<long>();
        for (long p = 2; p * p <= n; p++)
        {
            if (n % p == 0)
            {
                factors.Add(p);
                while (n % p == 0)
                {
                    n /= p;
                }
            }
        }

        if (n > 1)
        {
            factors.Add(n);
        }

        return factors;
    }
}
