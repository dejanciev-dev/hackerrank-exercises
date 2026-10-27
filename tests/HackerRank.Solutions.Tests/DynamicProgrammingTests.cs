using HackerRank.Solutions.DynamicProgramming;

namespace HackerRank.Solutions.Tests;

public class DynamicProgrammingTests
{
    [Theory]
    [InlineData(4, new[] { 1, 2, 3 }, 4L)]
    [InlineData(10, new[] { 2, 5, 3, 6 }, 5L)]
    [InlineData(3, new[] { 2 }, 0L)]
    public void CoinChange_Samples(int n, int[] c, long expected) =>
        Assert.Equal(expected, CoinChange.Solve(n, c));

    [Theory]
    [InlineData(0, 1, 5, "5")]
    [InlineData(0, 1, 6, "27")]
    [InlineData(0, 1, 10, "84266613096281243382112")]
    public void FibonacciModified_Samples(int t1, int t2, int n, string expected) =>
        Assert.Equal(expected, FibonacciModified.Solve(t1, t2, n));

    [Theory]
    [InlineData(new[] { 2, 2, 3, 7 }, 2L)]
    [InlineData(new[] { 10, 7, 12 }, 3L)]
    [InlineData(new[] { 1, 1, 5 }, 2L)]
    [InlineData(new[] { 1, 5, 5 }, 3L)]
    public void Equal_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, Equal.Solve(arr));

    [Theory]
    [InlineData("16", 23L)]
    [InlineData("123", 164L)]
    public void SamAndSubstrings_Samples(string n, long expected) =>
        Assert.Equal(expected, SamAndSubstrings.Solve(n));

    [Theory]
    [InlineData(new[] { 5, 3, 2 }, 0L)]
    [InlineData(new[] { 1, 2, 100 }, 197L)]
    [InlineData(new[] { 1, 3, 1, 2 }, 3L)]
    public void StockMaximize_Samples(int[] prices, long expected) =>
        Assert.Equal(expected, StockMaximize.Solve(prices));

    [Theory]
    [InlineData(new[] { 3, 7, 4, 6, 5 }, 13L)]
    [InlineData(new[] { 2, 1, 5, 8, 4 }, 11L)]
    [InlineData(new[] { 3, 5, -7, 8, 10 }, 15L)]
    public void MaxArraySum_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, MaxArraySum.Solve(arr));

    [Theory]
    [InlineData(new[] { 1, 2, 2 }, 4L)]
    [InlineData(new[] { 2, 4, 2, 6, 1, 7, 8, 9, 2, 1 }, 19L)]
    [InlineData(new[] { 2, 4, 3, 5, 2, 6, 4, 5 }, 12L)]
    public void Candies_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, Candies.Solve(arr));

    [Theory]
    [InlineData(new[] { 10, 1, 10, 1, 10 }, 36L)]
    [InlineData(new[] { 100, 2, 100, 2, 100 }, 396L)]
    [InlineData(new[] { 1, 2, 3 }, 2L)]
    public void SherlockAndCost_Samples(int[] b, long expected) =>
        Assert.Equal(expected, SherlockAndCost.Solve(b));

    [Theory]
    [InlineData("daBcd", "ABC", "YES")]
    [InlineData("AbcDE", "ABDE", "YES")]
    [InlineData("AbcDE", "AFDE", "NO")]
    [InlineData("beFgH", "EFG", "NO")]
    public void Abbreviation_Samples(string a, string b, string expected) =>
        Assert.Equal(expected, Abbreviation.Solve(a, b));

    [Theory]
    [InlineData(new[] { 2, 7, 4, 3, 8 }, 3)]
    [InlineData(new[] { 2, 4, 3, 7, 4, 5 }, 4)]
    [InlineData(new[] { 5, 2, 8, 6, 3, 6, 9, 7 }, 4)]
    [InlineData(new[] { 3, 3, 3 }, 1)]
    public void LongestIncreasingSubsequence_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, LongestIncreasingSubsequence.Solve(arr));

    [Theory]
    [InlineData(12, new[] { 1, 6, 9 }, 12)]
    [InlineData(9, new[] { 3, 4, 4, 4, 8 }, 9)]
    [InlineData(5, new[] { 6 }, 0)]
    public void Knapsack_Samples(int k, int[] arr, int expected) =>
        Assert.Equal(expected, Knapsack.Solve(k, arr));

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 10L, 10L })]
    [InlineData(new[] { 2, -1, 2, 3, 4, -5 }, new[] { 10L, 11L })]
    [InlineData(new[] { -2, -3, -1, -4, -6 }, new[] { -1L, -1L })]
    [InlineData(new[] { -1, 0, -2 }, new[] { 0L, 0L })]
    public void MaximumSubarray_Samples(int[] arr, long[] expected) =>
        Assert.Equal(expected, MaximumSubarray.Solve(arr));

    [Theory]
    [InlineData(1, 0)]
    [InlineData(4, 1)]
    [InlineData(7, 3)]
    [InlineData(40, 19385)]
    public void RedJohnIsBack_Samples(int n, int expected) =>
        Assert.Equal(expected, RedJohnIsBack.Solve(n));

    [Theory]
    [InlineData(4, 3, 2, 3L)]
    [InlineData(761, 99, 1, 236568308L)]
    [InlineData(3, 2, 1, 1L)]
    [InlineData(3, 2, 2, 0L)]
    public void ConstructTheArray_Samples(int n, int k, int x, long expected) =>
        Assert.Equal(expected, ConstructTheArray.Solve(n, k, x));

    [Theory]
    [InlineData(new[] { 3, 2, 2 }, 10L)]
    [InlineData(new[] { 3, 2, 5 }, 16L)]
    [InlineData(new[] { 100 }, 100L)]
    public void MandragoraForest_Samples(int[] h, long expected) =>
        Assert.Equal(expected, MandragoraForest.Solve(h));

    [Theory]
    [InlineData(2, 2, 3L)]
    [InlineData(3, 2, 7L)]
    [InlineData(2, 3, 9L)]
    [InlineData(4, 4, 3375L)]
    [InlineData(1, 5, 0L)]
    public void LegoBlocks_Samples(int n, int m, long expected) =>
        Assert.Equal(expected, LegoBlocks.Solve(n, m));
}
