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

    [Fact]
    public void DynamicArray_ReturnsLastAnswers()
    {
        int[][] queries = [[1, 0, 5], [1, 1, 7], [1, 0, 3], [2, 1, 0], [2, 1, 1]];
        Assert.Equal([7, 3], DynamicArray.Solve(2, queries));
    }

    [Fact]
    public void QueueUsingTwoStacks_PrintsFront() =>
        Assert.Equal(
            [14, 14],
            QueueUsingTwoStacks.Solve(["1 42", "2", "1 14", "3", "1 28", "3", "1 60", "1 78", "2", "2"]));

    [Fact]
    public void MaximumElement_TracksMaximum() =>
        Assert.Equal(
            [26, 91],
            MaximumElement.Solve(["1 97", "2", "1 20", "2", "1 26", "1 20", "2", "3", "1 91", "3"]));

    [Fact]
    public void EqualStacks_FindsCommonHeight() =>
        Assert.Equal(5, EqualStacks.Solve([3, 2, 1, 1, 1], [4, 3, 2], [1, 1, 4, 1]));

    [Fact]
    public void EqualStacks_CanEmptyAllStacks() =>
        Assert.Equal(0, EqualStacks.Solve([1], [2], [3]));

    [Theory]
    [InlineData(10L, new[] { 4, 2, 4, 6, 1 }, new[] { 2, 1, 8, 5 }, 4)]
    [InlineData(10L, new[] { 1, 2, 3, 4, 5 }, new[] { 6, 7, 8, 9 }, 4)]
    [InlineData(1L, new[] { 5 }, new[] { 5 }, 0)]
    public void GameOfTwoStacks_Samples(long maxSum, int[] a, int[] b, int expected) =>
        Assert.Equal(expected, GameOfTwoStacks.Solve(maxSum, a, b));

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 9L)]
    [InlineData(new[] { 3, 2, 3 }, 6L)]
    [InlineData(new[] { 1, 3, 5, 9, 11 }, 18L)]
    [InlineData(new[] { 11, 11, 10, 10, 10 }, 50L)]
    public void LargestRectangle_Samples(int[] h, long expected) =>
        Assert.Equal(expected, LargestRectangle.Solve(h));

    [Fact]
    public void SimpleTextEditor_SupportsUndo() =>
        Assert.Equal(
            ["c", "y", "a"],
            SimpleTextEditor.Solve(["1 abc", "3 3", "2 3", "1 xy", "3 2", "4", "4", "3 1"]));

    [Theory]
    [InlineData(7L, new[] { 1, 2, 3, 9, 10, 12 }, 2)]
    [InlineData(9L, new[] { 2, 7, 3, 6, 4, 6 }, 4)]
    [InlineData(10L, new[] { 1, 1 }, -1)]
    [InlineData(1L, new[] { 5, 6 }, 0)]
    public void JesseAndCookies_Samples(long k, int[] a, int expected) =>
        Assert.Equal(expected, JesseAndCookies.Solve(k, a));

    [Fact]
    public void Qheap1_PrintsMinimum() =>
        Assert.Equal([4, 9], Qheap1.Solve(["1 4", "1 9", "3", "2 4", "3"]));

    [Fact]
    public void TruckTour_FindsStartingPump()
    {
        int[][] pumps = [[1, 5], [10, 3], [3, 4]];
        Assert.Equal(1, TruckTour.Solve(pumps));
    }

    [Fact]
    public void Contacts_CountsPrefixMatches() =>
        Assert.Equal([2, 0], Contacts.Solve(["add hack", "add hackerrank", "find hac", "find hak"]));

    [Fact]
    public void ArrayManipulation_Samples()
    {
        int[][] first = [[1, 2, 100], [2, 5, 100], [3, 4, 100]];
        Assert.Equal(200L, ArrayManipulation.Solve(5, first));

        int[][] second = [[1, 5, 3], [4, 8, 7], [6, 9, 1]];
        Assert.Equal(10L, ArrayManipulation.Solve(10, second));

        int[][] third = [[2, 6, 8], [3, 5, 7], [1, 8, 1], [5, 9, 15]];
        Assert.Equal(31L, ArrayManipulation.Solve(10, third));
    }
}
