namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Greedy Florist — a customer's i-th flower costs (i + 1) × its price. Spread the most
/// expensive flowers across the <c>k</c> friends first so they get the smallest multipliers.
/// https://www.hackerrank.com/challenges/greedy-florist
/// </summary>
public static class GreedyFlorist
{
    public static long Solve(int k, IReadOnlyList<int> c)
    {
        var prices = c.OrderDescending().ToArray();
        long total = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            int previousPurchases = i / k;
            total += (long)(previousPurchases + 1) * prices[i];
        }

        return total;
    }
}
