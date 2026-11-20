namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Picking Cards — there are n cards and card i has a number c[i]. A card can be picked only
/// when at least c[i] cards have already been picked. In how many orders can all cards be
/// picked, modulo 10^9 + 7?
/// Fill the picks one by one: when i cards have been picked, the cards that may be picked are
/// those with c ≤ i, and i of them are already gone, so there are (count of c ≤ i) − i choices.
/// The answer is the product of these, or 0 as soon as a factor is not positive. O(n + max c).
/// https://www.hackerrank.com/challenges/picking-cards
/// </summary>
public static class PickingCards
{
    private const long Modulus = 1_000_000_007;

    public static long Solve(IReadOnlyList<int> c)
    {
        int n = c.Count;
        var cardsWithNumber = new int[n + 1];
        foreach (var number in c)
        {
            cardsWithNumber[Math.Min(number, n)]++;
        }

        long ways = 1;
        int available = 0;
        for (int picked = 0; picked < n; picked++)
        {
            available += cardsWithNumber[picked];
            if (available <= picked)
            {
                return 0;
            }

            ways = ways * (available - picked) % Modulus;
        }

        return ways;
    }
}
