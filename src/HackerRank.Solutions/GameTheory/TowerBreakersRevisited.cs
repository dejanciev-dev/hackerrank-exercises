namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Tower Breakers, Revisited! — towers of different heights; a move shrinks a tower to one of
/// its proper divisors. A tower's Grundy number is the number of prime factors of its height
/// counted with multiplicity, so player 1 wins when the XOR of those counts is non-zero.
/// Returns the winner, 1 or 2.
/// https://www.hackerrank.com/challenges/tower-breakers-revisited-1
/// </summary>
public static class TowerBreakersRevisited
{
    public static int Solve(IReadOnlyList<int> h)
    {
        int nimSum = 0;
        foreach (var height in h)
        {
            nimSum ^= PrimeFactorCount(height);
        }

        return nimSum != 0 ? 1 : 2;
    }

    private static int PrimeFactorCount(int n)
    {
        int count = 0;
        for (int p = 2; p * p <= n; p++)
        {
            for (; n % p == 0; n /= p)
            {
                count++;
            }
        }

        return n > 1 ? count + 1 : count;
    }
}
