using HackerRank.Solutions.Greedy;

namespace HackerRank.Solutions.Tests;

public class GreedyTests
{
    [Theory]
    [InlineData(new[] { 3, -7, 0 }, 3)]
    [InlineData(new[] { -59, -36, -13, 1, -53, -92, -2, -96, -62, 88 }, 3)]
    [InlineData(new[] { 1, -3, 71, 68, 17 }, 3)]
    public void MinimumAbsoluteDifference_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, MinimumAbsoluteDifference.Solve(arr));

    [Fact]
    public void LuckBalance_LosesLuckiestImportantContests()
    {
        int[][] contests = [[5, 1], [2, 1], [1, 1], [8, 1], [10, 0], [5, 0]];
        Assert.Equal(29, LuckBalance.Solve(3, contests));
    }

    [Fact]
    public void LuckBalance_WinsAllImportantWhenKIsZero()
    {
        int[][] contests = [[5, 1], [1, 1], [4, 0]];
        Assert.Equal(-2, LuckBalance.Solve(0, contests));
    }

    [Theory]
    [InlineData(new[] { "ebacd", "fghij", "olmkn", "trpqs", "xywuv" }, "YES")]
    [InlineData(new[] { "mpxz", "abcd", "wlmf" }, "NO")]
    [InlineData(new[] { "abc", "hjk", "mpq", "rtv" }, "YES")]
    public void GridChallenge_Samples(string[] grid, string expected) =>
        Assert.Equal(expected, GridChallenge.Solve(grid));

    [Theory]
    [InlineData(3, new[] { 10, 100, 300, 200, 1000, 20, 30 }, 20)]
    [InlineData(4, new[] { 1, 2, 3, 4, 10, 20, 30, 40, 100, 200 }, 3)]
    [InlineData(2, new[] { 1, 2, 1, 2, 1 }, 0)]
    public void MaxMin_Samples(int k, int[] arr, int expected) =>
        Assert.Equal(expected, MaxMin.Solve(k, arr));

    [Theory]
    [InlineData(3, new[] { 2, 5, 6 }, 13L)]
    [InlineData(2, new[] { 2, 5, 6 }, 15L)]
    [InlineData(3, new[] { 1, 3, 5, 7, 9 }, 29L)]
    public void GreedyFlorist_Samples(int k, int[] c, long expected) =>
        Assert.Equal(expected, GreedyFlorist.Solve(k, c));

    [Fact]
    public void JimAndTheOrders_ServesByCompletionTime()
    {
        int[][] orders = [[8, 1], [4, 2], [5, 6], [3, 1], [4, 3]];
        Assert.Equal([4, 2, 5, 1, 3], JimAndTheOrders.Solve(orders));
    }

    [Fact]
    public void JimAndTheOrders_BreaksTiesByCustomerNumber()
    {
        int[][] orders = [[1, 3], [2, 3], [3, 3]];
        Assert.Equal([1, 2, 3], JimAndTheOrders.Solve(orders));
    }
}
