namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Red John is Back — count the ways to tile a 4 x n wall with 4x1 and 1x4 bricks, then count
/// the primes up to that number. The last column is either one vertical brick or four stacked
/// horizontal ones: ways(n) = ways(n - 1) + ways(n - 4). Primes by the sieve of Eratosthenes.
/// https://www.hackerrank.com/challenges/red-john-is-back
/// </summary>
public static class RedJohnIsBack
{
    public static int Solve(int n)
    {
        var ways = new int[Math.Max(n + 1, 4)];
        for (int i = 0; i < 4; i++)
        {
            ways[i] = 1;
        }

        for (int i = 4; i <= n; i++)
        {
            ways[i] = ways[i - 1] + ways[i - 4];
        }

        return CountPrimes(ways[n]);
    }

    private static int CountPrimes(int limit)
    {
        if (limit < 2)
        {
            return 0;
        }

        var composite = new bool[limit + 1];
        int count = 0;

        for (int i = 2; i <= limit; i++)
        {
            if (composite[i])
            {
                continue;
            }

            count++;
            for (long j = (long)i * i; j <= limit; j += i)
            {
                composite[j] = true;
            }
        }

        return count;
    }
}
