namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// K Candy Store — ways to pick <c>k</c> candies from <c>n</c> flavours (repeats allowed), as
/// the last 9 digits. Stars and bars gives C(n + k - 1, k); 10^9 isn't prime, so take
/// Pascal's triangle row n + k - 1 by addition. O((n + k)²).
/// https://www.hackerrank.com/challenges/k-candy-store
/// </summary>
public static class KCandyStore
{
    public static long Solve(int n, int k) => NcrTable.Solve(n + k - 1)[k];
}
