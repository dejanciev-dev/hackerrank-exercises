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

    [Theory]
    [InlineData(new[] { 3L, 3L, 9L, 9L, 5L }, 7L, 6L)]
    [InlineData(new[] { 1L, 2L, 3L }, 2L, 1L)]
    [InlineData(new[] { 1L, 5L, 9L }, 5L, 4L)]
    public void MaximumSubarraySum_Samples(long[] a, long m, long expected) =>
        Assert.Equal(expected, MaximumSubarraySum.Solve(a, m));

    [Fact]
    public void CountLuck_Samples()
    {
        Assert.Equal("Impressed", CountLuck.Solve(["*.M", ".X."], 1));

        string[] forest = [".X.X......X", ".X*.X.XXX.X", ".XX.X.XM...", "......XXXX."];
        Assert.Equal("Impressed", CountLuck.Solve(forest, 3));
        Assert.Equal("Oops!", CountLuck.Solve(forest, 4));
    }

    [Fact]
    public void GridlandMetro_MergesOverlappingTracks()
    {
        Assert.Equal(9L, GridlandMetro.Solve(4, 4, [[2, 2, 3], [3, 1, 4], [4, 4, 4]]));
        Assert.Equal(5L, GridlandMetro.Solve(2, 4, [[1, 1, 2], [1, 2, 3], [1, 2, 2]]));
    }

    [Fact]
    public void GridlandMetro_HandlesHugeGrid() =>
        Assert.Equal(999_999_999_000_000_000L, GridlandMetro.Solve(1_000_000_000, 1_000_000_000, [[1, 1, 1_000_000_000]]));

    [Fact]
    public void KnightLOnAChessboard_Sample()
    {
        int[][] expected =
        [
            [4, 4, 2, 8],
            [4, 2, 4, 4],
            [2, 4, -1, -1],
            [8, 4, -1, 1],
        ];

        Assert.Equal(expected, KnightLOnAChessboard.Solve(5));
    }

    [Fact]
    public void CutTheTree_Sample() =>
        Assert.Equal(400, CutTheTree.Solve([100, 200, 100, 500, 100, 600], [[1, 2], [2, 3], [2, 5], [4, 5], [5, 6]]));

    [Theory]
    [InlineData(new[] { 1L, 2L, 2L, 4L }, 2L, 2L)]
    [InlineData(new[] { 1L, 3L, 9L, 9L, 27L, 81L }, 3L, 6L)]
    [InlineData(new[] { 1L, 5L, 5L, 25L, 125L }, 5L, 4L)]
    [InlineData(new[] { 1L, 1L, 1L, 1L }, 1L, 4L)]
    public void CountTriplets_Samples(long[] arr, long r, long expected) =>
        Assert.Equal(expected, CountTriplets.Solve(arr, r));

    [Fact]
    public void RedKnightsShortestPath_Samples()
    {
        Assert.Equal(["4", "UL UL UL L"], RedKnightsShortestPath.Solve(7, 6, 6, 0, 1));
        Assert.Equal(["Impossible"], RedKnightsShortestPath.Solve(6, 5, 1, 0, 5));
        Assert.Equal(["2", "LR LL"], RedKnightsShortestPath.Solve(7, 0, 3, 4, 3));
    }
}
