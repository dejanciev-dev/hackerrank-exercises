namespace HackerRank.Solutions.Search;

/// <summary>
/// Minimum Loss — buy a house in one year and sell it later at a strictly lower price; minimize
/// the loss. After sorting prices, the best pair is always adjacent in sorted order, as long as
/// the higher price comes earlier in time. O(n log n).
/// https://www.hackerrank.com/challenges/minimum-loss
/// </summary>
public static class MinimumLoss
{
    public static long Solve(IReadOnlyList<long> price)
    {
        var byPrice = Enumerable.Range(0, price.Count).OrderBy(year => price[year]).ToArray();
        long best = long.MaxValue;

        for (int i = 1; i < byPrice.Length; i++)
        {
            int sellYear = byPrice[i - 1];
            int buyYear = byPrice[i];

            if (buyYear < sellYear)
            {
                best = Math.Min(best, price[buyYear] - price[sellYear]);
            }
        }

        return best;
    }
}
