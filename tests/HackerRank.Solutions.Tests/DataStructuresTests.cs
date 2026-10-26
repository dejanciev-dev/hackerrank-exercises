using HackerRank.Solutions.DataStructures;

namespace HackerRank.Solutions.Tests;

public class DataStructuresTests
{
    [Fact]
    public void ArraysDS_ReversesArray() =>
        Assert.Equal([2, 3, 4, 1], ArraysDS.Solve([1, 4, 3, 2]));

    [Fact]
    public void HourglassSum_FindsMaximum()
    {
        int[][] grid =
        [
            [1, 1, 1, 0, 0, 0],
            [0, 1, 0, 0, 0, 0],
            [1, 1, 1, 0, 0, 0],
            [0, 0, 2, 4, 4, 0],
            [0, 0, 0, 2, 0, 0],
            [0, 0, 1, 2, 4, 0],
        ];

        Assert.Equal(19, HourglassSum.Solve(grid));
    }

    [Fact]
    public void HourglassSum_HandlesAllNegativeValues()
    {
        int[][] grid =
        [
            [-1, -1, 0, -9, -2, -2],
            [-2, -1, -6, -8, -2, -5],
            [-1, -1, -1, -2, -3, -4],
            [-1, -9, -2, -4, -4, -5],
            [-7, -3, -3, -2, -9, -9],
            [-1, -3, -1, -2, -4, -5],
        ];

        Assert.Equal(-6, HourglassSum.Solve(grid));
    }

    [Theory]
    [InlineData(4, new[] { 1, 2, 3, 4, 5 }, new[] { 5, 1, 2, 3, 4 })]
    [InlineData(2, new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5, 1, 2 })]
    public void LeftRotation_Samples(int d, int[] arr, int[] expected) =>
        Assert.Equal(expected, LeftRotation.Solve(d, arr));

    [Fact]
    public void SparseArrays_CountsQueries() =>
        Assert.Equal([2, 1, 0], SparseArrays.Solve(["ab", "ab", "abc"], ["ab", "abc", "bc"]));

    [Theory]
    [InlineData("{[()]}", "YES")]
    [InlineData("{[(])}", "NO")]
    [InlineData("{{[[(())]]}}", "YES")]
    [InlineData("((", "NO")]
    [InlineData("}", "NO")]
    public void BalancedBrackets_Samples(string s, string expected) =>
        Assert.Equal(expected, BalancedBrackets.Solve(s));
}
