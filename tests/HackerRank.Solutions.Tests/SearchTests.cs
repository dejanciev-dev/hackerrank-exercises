using HackerRank.Solutions.Search;

namespace HackerRank.Solutions.Tests;

public class SearchTests
{
    [Theory]
    [InlineData(4, new[] { 1, 4, 5, 3, 2 }, new[] { 1, 4 })]
    [InlineData(4, new[] { 2, 2, 4, 3 }, new[] { 1, 2 })]
    [InlineData(6, new[] { 1, 3, 4, 5, 6 }, new[] { 1, 4 })]
    public void IceCreamParlor_Samples(int m, int[] cost, int[] expected) =>
        Assert.Equal(expected, IceCreamParlor.Solve(m, cost));

    [Theory]
    [InlineData(2, new[] { 1, 5, 3, 4, 2 }, 3)]
    [InlineData(1, new[] { 1, 2, 3, 4 }, 3)]
    public void Pairs_Samples(int k, int[] arr, int expected) =>
        Assert.Equal(expected, Pairs.Solve(k, arr));

    [Fact]
    public void MissingNumbers_ReportsEachMissingValueOnce() =>
        Assert.Equal(
            [204, 205, 206],
            MissingNumbers.Solve(
                [203, 204, 205, 206, 207, 208, 203, 204, 205, 206],
                [203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204]));

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, "NO")]
    [InlineData(new[] { 1, 2, 3, 3 }, "YES")]
    [InlineData(new[] { 1 }, "YES")]
    [InlineData(new[] { 2, 0, 0, 0 }, "YES")]
    public void SherlockAndArray_Samples(int[] arr, string expected) =>
        Assert.Equal(expected, SherlockAndArray.Solve(arr));
}
