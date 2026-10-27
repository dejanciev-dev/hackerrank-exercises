namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Alice and Bob's Silly Game — players take turns picking a prime ≤ n and removing it and
/// all its multiples from 1..n; whoever can't move loses. Each move removes exactly one prime,
/// so the game lasts as many turns as there are primes up to n: Alice (who starts) wins when
/// that count is odd. Sieve of Eratosthenes, O(n log log n).
/// https://www.hackerrank.com/challenges/alice-and-bobs-silly-game
/// </summary>
public static class AliceAndBobsSillyGame
{
    public static string Solve(int n)
    {
        var composite = new bool[n + 1];
        int primes = 0;

        for (int i = 2; i <= n; i++)
        {
            if (composite[i])
            {
                continue;
            }

            primes++;
            for (long j = (long)i * i; j <= n; j += i)
            {
                composite[j] = true;
            }
        }

        return primes % 2 == 1 ? "Alice" : "Bob";
    }
}
