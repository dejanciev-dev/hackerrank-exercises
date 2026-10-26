namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// The Coin Change Problem — number of ways to make <c>n</c> from unlimited coins of the given
/// denominations (order doesn't matter). Iterating coins in the outer loop counts each
/// combination once. O(n · coins) time, O(n) memory.
/// https://www.hackerrank.com/challenges/coin-change
/// </summary>
public static class CoinChange
{
    public static long Solve(int n, IReadOnlyList<int> c)
    {
        var ways = new long[n + 1];
        ways[0] = 1;

        foreach (var coin in c)
        {
            for (int amount = coin; amount <= n; amount++)
            {
                ways[amount] += ways[amount - coin];
            }
        }

        return ways[n];
    }
}
