namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Stock Maximize — buy at most one share a day and sell any number; maximize profit. Walking
/// backwards, every day priced below the best future price is a buy sold at that future peak. O(n).
/// https://www.hackerrank.com/challenges/stockmax
/// </summary>
public static class StockMaximize
{
    public static long Solve(IReadOnlyList<int> prices)
    {
        long profit = 0;
        int futureMax = 0;

        for (int i = prices.Count - 1; i >= 0; i--)
        {
            futureMax = Math.Max(futureMax, prices[i]);
            profit += futureMax - prices[i];
        }

        return profit;
    }
}
