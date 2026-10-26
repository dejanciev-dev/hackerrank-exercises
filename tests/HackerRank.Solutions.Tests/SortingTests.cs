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
}
