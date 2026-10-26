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

    [Theory]
    [InlineData(new[] { 5L, 10L, 3L }, 2L)]
    [InlineData(new[] { 20L, 7L, 8L, 2L, 5L }, 2L)]
    public void MinimumLoss_Samples(long[] price, long expected) =>
        Assert.Equal(expected, MinimumLoss.Solve(price));

    [Fact]
    public void ConnectedCellsInAGrid_FindsLargestRegion()
    {
        int[][] matrix =
        [
            [1, 1, 0, 0],
            [0, 1, 1, 0],
            [0, 0, 1, 0],
            [1, 0, 0, 0],
        ];

        Assert.Equal(5, ConnectedCellsInAGrid.Solve(matrix));
    }

    [Fact]
    public void ConnectedCellsInAGrid_ConnectsDiagonally()
    {
        int[][] matrix =
        [
            [1, 0, 1],
            [0, 1, 0],
            [1, 0, 1],
        ];

        Assert.Equal(5, ConnectedCellsInAGrid.Solve(matrix));
    }

    [Theory]
    [InlineData(1, new[] { 1, 2, 3, 4, 5 }, 2)]
    [InlineData(2, new[] { 7, 2, 4, 6, 5, 9, 12, 11 }, 3)]
    [InlineData(5, new[] { 1 }, 1)]
    public void HackerlandRadioTransmitters_Samples(int k, int[] x, int expected) =>
        Assert.Equal(expected, HackerlandRadioTransmitters.Solve(k, x));
}
