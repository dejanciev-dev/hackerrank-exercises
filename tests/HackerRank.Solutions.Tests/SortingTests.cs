using HackerRank.Solutions.Sorting;

namespace HackerRank.Solutions.Tests;

public class SortingTests
{
    [Fact]
    public void BigSorting_SortsByNumericValue() =>
        Assert.Equal(
            ["1", "3", "3", "5", "10", "31415926535897932384626433832795"],
            BigSorting.Solve(["31415926535897932384626433832795", "1", "3", "10", "3", "5"]));

    [Theory]
    [InlineData(new[] { 1, 12, 5, 111, 200, 1000, 10 }, 50L, 4)]
    [InlineData(new[] { 1, 2, 3, 4 }, 7L, 3)]
    [InlineData(new[] { 10 }, 5L, 0)]
    public void MarkAndToys_Samples(int[] prices, long k, int expected) =>
        Assert.Equal(expected, MarkAndToys.Solve(prices, k));

    [Fact]
    public void FindTheMedian_ReturnsMiddleElement() =>
        Assert.Equal(3, FindTheMedian.Solve([0, 1, 2, 4, 6, 5, 3]));

    [Fact]
    public void ClosestNumbers_FindsSinglePair() =>
        Assert.Equal(
            [-20, 30],
            ClosestNumbers.Solve([-20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854]));

    [Fact]
    public void ClosestNumbers_FindsAllTiedPairs() =>
        Assert.Equal([2, 3, 3, 4, 4, 5], ClosestNumbers.Solve([5, 4, 3, 2]));

    [Theory]
    [InlineData(new[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 }, 5, 2)]
    [InlineData(new[] { 1, 2, 3, 4, 4 }, 4, 0)]
    [InlineData(new[] { 10, 20, 30, 40, 50 }, 3, 1)]
    public void FraudulentActivityNotifications_Samples(int[] expenditure, int d, int expected) =>
        Assert.Equal(expected, FraudulentActivityNotifications.Solve(expenditure, d));

    [Fact]
    public void CountingSort1_CountsFrequencies()
    {
        var counts = CountingSort1.Solve([1, 1, 3, 2, 1]);

        Assert.Equal(100, counts.Length);
        Assert.Equal([0, 3, 1, 1, 0], counts[..5]);
    }

    [Theory]
    [InlineData(new[] { 7, 15, 12, 3 }, 2)]
    [InlineData(new[] { 2, 5, 3, 1 }, 2)]
    [InlineData(new[] { 3, 4, 2, 5, 1 }, 2)]
    [InlineData(new[] { 1, 2, 3 }, 0)]
    public void LilysHomework_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, LilysHomework.Solve(arr));

    [Theory]
    [InlineData(new[] { 2, 1, 3, 1, 2 }, 4)]
    [InlineData(new[] { 1, 2, 3 }, 0)]
    [InlineData(new[] { 3, 2, 1 }, 3)]
    public void RunningTimeOfAlgorithms_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, RunningTimeOfAlgorithms.Solve(arr));

    [Fact]
    public void QuicksortPartition_KeepsRelativeOrder() =>
        Assert.Equal([3, 2, 4, 5, 7], QuicksortPartition.Solve([4, 5, 3, 7, 2]));

    [Theory]
    [InlineData(4, new[] { 1, 4, 5, 7, 9, 12 }, 1)]
    [InlineData(12, new[] { 1, 4, 5, 7, 9, 12 }, 5)]
    [InlineData(6, new[] { 1, 4, 5, 7, 9, 12 }, -1)]
    public void IntroToTutorialChallenges_Samples(int v, int[] arr, int expected) =>
        Assert.Equal(expected, IntroToTutorialChallenges.Solve(v, arr));

    [Fact]
    public void InsertionSort1_PrintsEachShift() =>
        Assert.Equal(
            ["2 4 6 8 8", "2 4 6 6 8", "2 4 4 6 8", "2 3 4 6 8"],
            InsertionSort1.Solve([2, 4, 6, 8, 3]));

    [Fact]
    public void InsertionSort1_InsertsAtFront() =>
        Assert.Equal(["2 2", "1 2"], InsertionSort1.Solve([2, 1]));

    [Fact]
    public void InsertionSort2_PrintsEachPass() =>
        Assert.Equal(
            ["1 4 3 5 6 2", "1 3 4 5 6 2", "1 3 4 5 6 2", "1 3 4 5 6 2", "1 2 3 4 5 6"],
            InsertionSort2.Solve([1, 4, 3, 5, 6, 2]));

    [Fact]
    public void CountingSort2_Sorts()
    {
        int[] arr = [63, 25, 73, 1, 98, 73, 56, 84, 86, 57, 16, 83, 8, 25, 81, 56, 9, 53, 98, 67, 99, 12, 0, 99];
        Assert.Equal(arr.Order(), CountingSort2.Solve(arr));
    }

    [Fact]
    public void TheFullCountingSort_Sample()
    {
        string[][] arr =
        [
            ["0", "ab"], ["6", "cd"], ["0", "ef"], ["6", "gh"], ["4", "ij"],
            ["0", "ab"], ["6", "cd"], ["0", "ef"], ["6", "gh"], ["0", "ij"],
            ["4", "that"], ["3", "be"], ["0", "to"], ["1", "be"], ["5", "question"],
            ["1", "or"], ["2", "not"], ["4", "is"], ["2", "to"], ["4", "the"],
        ];

        Assert.Equal("- - - - - to be or not to be - that is the question - - - -", TheFullCountingSort.Solve(arr));
    }

    [Theory]
    [InlineData(new[] { 1, 1, 1, 2, 2 }, 0L)]
    [InlineData(new[] { 2, 1, 3, 1, 2 }, 4L)]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, 10L)]
    [InlineData(new[] { 7 }, 0L)]
    public void InsertionSortAdvancedAnalysis_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, InsertionSortAdvancedAnalysis.Solve(arr));

    [Fact]
    public void BubbleSort_Samples()
    {
        Assert.Equal(["Array is sorted in 3 swaps.", "First Element: 1", "Last Element: 3"], BubbleSort.Solve([3, 2, 1]));
        Assert.Equal(["Array is sorted in 0 swaps.", "First Element: 1", "Last Element: 3"], BubbleSort.Solve([1, 2, 3]));
    }

    [Fact]
    public void Comparator_SortsByScoreThenName() =>
        Assert.Equal(
            [("aleksa", 150), ("amy", 100), ("david", 100), ("aakansha", 75), ("heraldo", 50)],
            Comparator.Solve([("amy", 100), ("david", 100), ("heraldo", 50), ("aakansha", 75), ("aleksa", 150)]));
}
