using HackerRank.Solutions.Warmup;

namespace HackerRank.Solutions.Tests;

public class WarmupTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(100, 1000, 1100)]
    public void SolveMeFirst_ReturnsSum(int a, int b, int expected) =>
        Assert.Equal(expected, SolveMeFirst.Solve(a, b));

    [Fact]
    public void SimpleArraySum_SumsElements() =>
        Assert.Equal(31, SimpleArraySum.Solve([1, 2, 3, 4, 10, 11]));

    [Theory]
    [InlineData(new[] { 5, 6, 7 }, new[] { 3, 6, 10 }, new[] { 1, 1 })]
    [InlineData(new[] { 17, 28, 30 }, new[] { 99, 16, 8 }, new[] { 2, 1 })]
    public void CompareTheTriplets_AwardsPoints(int[] a, int[] b, int[] expected) =>
        Assert.Equal(expected, CompareTheTriplets.Solve(a, b));

    [Fact]
    public void AVeryBigSum_DoesNotOverflow() =>
        Assert.Equal(5000000015L, AVeryBigSum.Solve([1000000001, 1000000002, 1000000003, 1000000004, 1000000005]));

    [Fact]
    public void DiagonalDifference_ReturnsAbsoluteDifference()
    {
        int[][] matrix =
        [
            [11, 2, 4],
            [4, 5, 6],
            [10, 8, -12],
        ];

        Assert.Equal(15, DiagonalDifference.Solve(matrix));
    }

    [Fact]
    public void PlusMinus_ReturnsRatiosWithSixDecimals() =>
        Assert.Equal(["0.500000", "0.333333", "0.166667"], PlusMinus.Solve([-4, 3, -9, 0, 4, 1]));

    [Fact]
    public void Staircase_IsRightAligned() =>
        Assert.Equal(["     #", "    ##", "   ###", "  ####", " #####", "######"], Staircase.Solve(6));

    [Fact]
    public void MiniMaxSum_ReturnsMinAndMax() =>
        Assert.Equal((10L, 14L), MiniMaxSum.Solve([1, 2, 3, 4, 5]));

    [Fact]
    public void MiniMaxSum_HandlesLargeValues() =>
        Assert.Equal((2063136757L, 2744467344L), MiniMaxSum.Solve([256741038, 623958417, 467905213, 714532089, 938071625]));

    [Fact]
    public void BirthdayCakeCandles_CountsTallest() =>
        Assert.Equal(2, BirthdayCakeCandles.Solve([3, 2, 1, 3]));

    [Theory]
    [InlineData("07:05:45PM", "19:05:45")]
    [InlineData("12:01:00PM", "12:01:00")]
    [InlineData("12:01:00AM", "00:01:00")]
    [InlineData("01:00:00AM", "01:00:00")]
    public void TimeConversion_ConvertsToMilitaryTime(string input, string expected) =>
        Assert.Equal(expected, TimeConversion.Solve(input));
}
