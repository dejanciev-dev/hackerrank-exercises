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

    [Theory]
    [InlineData(new[] { 6, 5, 8, 4, 7, 10, 9 }, 2)]
    [InlineData(new[] { 3, 6, 2, 7, 5 }, 2)]
    [InlineData(new[] { 4, 3, 7, 5, 6, 4, 2 }, 3)]
    [InlineData(new[] { 5, 4, 3 }, 0)]
    public void PoisonousPlants_Samples(int[] p, int expected) =>
        Assert.Equal(expected, PoisonousPlants.Solve(p));

    [Theory]
    [InlineData(new[] { 3, 4, 7, 6, 5 }, 1, new[] { 4, 6, 3, 7, 5 })]
    [InlineData(new[] { 3, 3, 4, 4, 9 }, 2, new[] { 4, 4, 9, 3, 3 })]
    [InlineData(new[] { 2, 3, 4, 5, 6, 7 }, 3, new[] { 2, 4, 6, 3, 5, 7 })]
    public void Waiter_Samples(int[] number, int q, int[] expected) =>
        Assert.Equal(expected, Waiter.Solve(number, q));

    [Theory]
    [InlineData(new[] { 9, 6, 3, 5, 2 }, 15)]
    [InlineData(new[] { 1, 2 }, 3)]
    public void AndXorOr_Samples(int[] a, int expected) =>
        Assert.Equal(expected, AndXorOr.Solve(a));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 3)]
    public void DownToZeroII_Samples(int n, int expected) =>
        Assert.Equal(expected, DownToZeroII.Solve(n));

    [Fact]
    public void CastleOnTheGrid_Samples()
    {
        Assert.Equal(3, CastleOnTheGrid.Solve([".X.", ".X.", "..."], 0, 0, 0, 2));
        Assert.Equal(2, CastleOnTheGrid.Solve(["...", ".X.", "..."], 0, 0, 1, 2));
        Assert.Equal(0, CastleOnTheGrid.Solve(["."], 0, 0, 0, 0));
    }

    [Fact]
    public void SwapNodes_Samples()
    {
        Assert.Equal([[3, 1, 2], [2, 1, 3]], SwapNodes.Solve([[2, 3], [-1, -1], [-1, -1]], [1, 1]));
        Assert.Equal([[4, 2, 1, 5, 3]], SwapNodes.Solve([[2, 3], [-1, 4], [-1, 5], [-1, -1], [-1, -1]], [2]));
    }

    [Fact]
    public void FindTheRunningMedian_Sample() =>
        Assert.Equal([12.0, 8.0, 5.0, 4.5, 5.0, 6.0], FindTheRunningMedian.Solve([12, 4, 5, 3, 8, 7]));

    [Fact]
    public void MinimumAverageWaitingTime_Samples()
    {
        Assert.Equal(9L, MinimumAverageWaitingTime.Solve([[0, 3], [1, 9], [2, 6]]));
        Assert.Equal(8L, MinimumAverageWaitingTime.Solve([[0, 3], [1, 9], [2, 5]]));
    }

    [Fact]
    public void MinimumAverageWaitingTime_WaitsForLateArrival() =>
        Assert.Equal(2L, MinimumAverageWaitingTime.Solve([[10, 2], [0, 2]]));

    [Fact]
    public void NoPrefixSet_Samples()
    {
        Assert.Equal(["BAD SET", "aabcde"], NoPrefixSet.Solve(["aab", "defgab", "abcde", "aabcde", "bbbbbbbbbb", "jabjjjad"]));
        Assert.Equal(["BAD SET", "aacghgh"], NoPrefixSet.Solve(["aab", "aac", "aacghgh", "aabghgh"]));
        Assert.Equal(["GOOD SET"], NoPrefixSet.Solve(["aab", "aac", "b"]));
    }

    [Fact]
    public void NoPrefixSet_FlagsWordThatIsPrefixOfEarlierOne() =>
        Assert.Equal(["BAD SET", "ab"], NoPrefixSet.Solve(["abc", "ab"]));

    [Theory]
    [InlineData(new[] { 3, 2, 1, 2, 3, 3 }, 8L)]
    [InlineData(new[] { 1, 1000, 1 }, 0L)]
    [InlineData(new[] { 5, 5, 5 }, 6L)]
    public void JimAndTheSkyscrapers_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, JimAndTheSkyscrapers.Solve(arr));

    [Fact]
    public void QueriesWithFixedLength_Sample() =>
        Assert.Equal([11, 33, 44, 44, 55], QueriesWithFixedLength.Solve([33, 11, 44, 11, 55], [1, 2, 3, 4, 5]));

    [Fact]
    public void QueriesWithFixedLength_MatchesBruteForce()
    {
        int[] arr = [5, 1, 9, 3, 3, 8, 2, 7, 6, 4, 10, 0];
        var queries = Enumerable.Range(1, arr.Length).ToArray();
        var expected = queries
            .Select(d => Enumerable.Range(0, arr.Length - d + 1).Min(start => arr.Skip(start).Take(d).Max()))
            .ToArray();

        Assert.Equal(expected, QueriesWithFixedLength.Solve(arr, queries));
    }

    [Fact]
    public void MergingCommunities_Sample() =>
        Assert.Equal([1, 2, 3, 3], MergingCommunities.Solve(3, ["Q 1", "M 1 2", "Q 2", "M 2 3", "Q 3", "Q 2"]));
}
