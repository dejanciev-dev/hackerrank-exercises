namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Leonardo's Prime Factors — the most distinct prime factors any number in [1, n] can have.
/// The smallest number with k distinct primes is the product of the first k primes, so keep
/// multiplying primes while the product stays within n (checked by division, so no overflow).
/// https://www.hackerrank.com/challenges/leonardo-and-prime
/// </summary>
public static class LeonardosPrimeFactors
{
    private static readonly long[] Primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53];

    public static int Solve(long n)
    {
        long product = 1;
        int count = 0;

        foreach (var prime in Primes)
        {
            if (product > n / prime)
            {
                break;
            }

            product *= prime;
            count++;
        }

        return count;
    }
}
