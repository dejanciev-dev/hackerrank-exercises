namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Twins — count the pairs of twin primes (p, p + 2) with n ≤ p and p + 2 ≤ m, given
/// 1 ≤ n ≤ m ≤ 10^9 and m − n ≤ 10^6.
/// A segmented sieve: the primes up to √m strike out the composites in [n, m], which leaves the
/// primes of the window as a bit per number, and neighbouring primes two apart are then counted.
/// O((m − n) log log m + √m).
/// https://www.hackerrank.com/challenges/twins
/// </summary>
public static class Twins
{
    public static int Solve(long n, long m)
    {
        long start = Math.Max(n, 2);
        if (m - start < 2)
        {
            return 0;
        }

        var isPrime = new bool[m - start + 1];
        Array.Fill(isPrime, true);

        for (long divisor = 2; divisor * divisor <= m; divisor++)
        {
            if (!IsSmallPrime(divisor))
            {
                continue;
            }

            long first = Math.Max(divisor * divisor, (start + divisor - 1) / divisor * divisor);
            for (long multiple = first; multiple <= m; multiple += divisor)
            {
                isPrime[multiple - start] = false;
            }
        }

        int pairs = 0;
        for (long p = start; p + 2 <= m; p++)
        {
            if (isPrime[p - start] && isPrime[p + 2 - start])
            {
                pairs++;
            }
        }

        return pairs;
    }

    private static bool IsSmallPrime(long value)
    {
        for (long d = 2; d * d <= value; d++)
        {
            if (value % d == 0)
            {
                return false;
            }
        }

        return true;
    }
}
