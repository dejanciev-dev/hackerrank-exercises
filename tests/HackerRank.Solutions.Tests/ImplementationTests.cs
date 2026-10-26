using HackerRank.Solutions.Implementation;

namespace HackerRank.Solutions.Tests;

public class ImplementationTests
{
    [Theory]
    [InlineData("hackerhappy", "hackerrank", 9, "Yes")]
    [InlineData("aba", "aba", 7, "Yes")]
    [InlineData("ashley", "ash", 2, "No")]
    [InlineData("y", "yu", 2, "No")]
    public void AppendAndDelete_Samples(string s, string t, int k, string expected) =>
        Assert.Equal(expected, AppendAndDelete.Solve(s, t, k));

    [Fact]
    public void AppleAndOrange_CountsFruitOnHouse() =>
        Assert.Equal((1, 1), AppleAndOrange.Solve(7, 11, 5, 15, [-2, 2, 1], [5, -6]));

    [Fact]
    public void BeautifulDaysAtTheMovies_CountsBeautifulDays() =>
        Assert.Equal(2, BeautifulDaysAtTheMovies.Solve(20, 23, 6));

    [Theory]
    [InlineData(new[] { 1, 2, 1, 3, 2 }, 3, 2, 2)]
    [InlineData(new[] { 1, 1, 1, 1, 1, 1 }, 3, 2, 0)]
    [InlineData(new[] { 4 }, 4, 1, 1)]
    [InlineData(new[] { 2, 1, 2 }, 2, 2, 0)] // a trailing short segment must not count
    public void SubarrayDivision_Samples(int[] s, int d, int m, int expected) =>
        Assert.Equal(expected, SubarrayDivision.Solve(s, d, m));

    [Theory]
    [InlineData(new[] { 3, 10, 2, 9 }, 1, 12, "5")]
    [InlineData(new[] { 3, 10, 2, 9 }, 1, 7, "Bon Appetit")]
    public void BillDivision_Samples(int[] bill, int k, int b, string expected) =>
        Assert.Equal(expected, BillDivision.Solve(bill, k, b));

    [Theory]
    [InlineData(new[] { 10, 5, 20, 20, 4, 5, 2, 25, 1 }, new[] { 2, 4 })]
    [InlineData(new[] { 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 }, new[] { 4, 0 })]
    public void BreakingTheRecords_Samples(int[] scores, int[] expected) =>
        Assert.Equal(expected, BreakingTheRecords.Solve(scores));

    [Theory]
    [InlineData(2017, "13.09.2017")]
    [InlineData(2016, "12.09.2016")]
    [InlineData(1800, "12.09.1800")]
    [InlineData(1918, "26.09.1918")]
    [InlineData(2100, "13.09.2100")]
    public void DayOfTheProgrammer_Samples(int year, string expected) =>
        Assert.Equal(expected, DayOfTheProgrammer.Solve(year));

    [Fact]
    public void DivisibleSumPairs_CountsPairs() =>
        Assert.Equal(5, DivisibleSumPairs.Solve(3, [1, 3, 2, 6, 1, 2]));

    [Theory]
    [InlineData(12, 2)]
    [InlineData(1012, 3)]
    public void FindDigits_Samples(int n, int expected) =>
        Assert.Equal(expected, FindDigits.Solve(n));

    [Theory]
    [InlineData(0, 3, 4, 2, "YES")]
    [InlineData(0, 2, 5, 3, "NO")]
    [InlineData(21, 6, 47, 3, "NO")]
    [InlineData(43, 2, 70, 2, "NO")]
    public void NumberLineJumps_Samples(int x1, int v1, int x2, int v2, string expected) =>
        Assert.Equal(expected, NumberLineJumps.Solve(x1, v1, x2, v2));

    [Theory]
    [InlineData(new[] { 1, 4, 4, 4, 5, 3 }, 4)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4 }, 3)]
    public void MigratoryBirds_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, MigratoryBirds.Solve(arr));

    [Theory]
    [InlineData(24, 49, 3)]
    [InlineData(3, 9, 2)]
    [InlineData(17, 24, 0)]
    [InlineData(1, 1000000000, 31622)]
    public void SherlockAndSquares_Samples(int a, int b, int expected) =>
        Assert.Equal(expected, SherlockAndSquares.Solve(a, b));

    [Fact]
    public void SalesByMatch_CountsPairs() =>
        Assert.Equal(3, SalesByMatch.Solve([10, 20, 20, 10, 10, 30, 50, 10, 20]));

    [Fact]
    public void GradingStudents_RoundsGrades() =>
        Assert.Equal([75, 67, 40, 33], GradingStudents.Solve([73, 67, 38, 33]));

    [Fact]
    public void BetweenTwoSets_CountsIntegers() =>
        Assert.Equal(3, BetweenTwoSets.Solve([2, 4], [16, 32, 96]));

    [Theory]
    [InlineData("UDDDUDUU", 1)]
    [InlineData("DDUUDDUDUUUD", 2)]
    public void CountingValleys_Samples(string path, int expected) =>
        Assert.Equal(expected, CountingValleys.Solve(path));

    [Theory]
    [InlineData(new[] { 3, 1 }, new[] { 5, 2, 8 }, 10, 9)]
    [InlineData(new[] { 4 }, new[] { 5 }, 5, -1)]
    public void ElectronicsShop_Samples(int[] keyboards, int[] drives, int b, int expected) =>
        Assert.Equal(expected, ElectronicsShop.Solve(keyboards, drives, b));

    [Theory]
    [InlineData(1, 2, 3, "Cat B")]
    [InlineData(1, 3, 2, "Mouse C")]
    [InlineData(2, 5, 4, "Cat B")]
    public void CatsAndAMouse_Samples(int x, int y, int z, string expected) =>
        Assert.Equal(expected, CatsAndAMouse.Solve(x, y, z));

    [Theory]
    [InlineData(new[] { 4, 6, 5, 3, 3, 1 }, 3)]
    [InlineData(new[] { 1, 2, 2, 3, 1, 2 }, 5)]
    public void PickingNumbers_Samples(int[] a, int expected) =>
        Assert.Equal(expected, PickingNumbers.Solve(a));

    [Fact]
    public void ClimbingTheLeaderboard_ReturnsRanks() =>
        Assert.Equal([6, 4, 2, 1], ClimbingTheLeaderboard.Solve([100, 100, 50, 40, 40, 20, 10], [5, 25, 50, 120]));

    [Fact]
    public void ClimbingTheLeaderboard_SecondSample() =>
        Assert.Equal([6, 5, 4, 2, 1], ClimbingTheLeaderboard.Solve([100, 90, 90, 80, 75, 60], [50, 65, 77, 90, 102]));

    [Theory]
    [InlineData(4, new[] { 1, 6, 3, 5, 2 }, 2)]
    [InlineData(7, new[] { 2, 5, 4, 5, 2 }, 0)]
    public void TheHurdleRace_Samples(int k, int[] height, int expected) =>
        Assert.Equal(expected, TheHurdleRace.Solve(k, height));

    [Theory]
    [InlineData(new[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, "abc", 9)]
    [InlineData(new[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 }, "zaba", 28)]
    public void DesignerPdfViewer_Samples(int[] h, string word, int expected) =>
        Assert.Equal(expected, DesignerPdfViewer.Solve(h, word));

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 2)]
    [InlineData(4, 7)]
    public void UtopianTree_Samples(int n, int expected) =>
        Assert.Equal(expected, UtopianTree.Solve(n));

    [Theory]
    [InlineData(3, new[] { -1, -3, 4, 2 }, "YES")]
    [InlineData(2, new[] { 0, -1, 2, 1 }, "NO")]
    public void AngryProfessor_Samples(int k, int[] a, string expected) =>
        Assert.Equal(expected, AngryProfessor.Solve(k, a));

    [Theory]
    [InlineData(3, 9)]
    [InlineData(5, 24)]
    public void ViralAdvertising_Samples(int n, int expected) =>
        Assert.Equal(expected, ViralAdvertising.Solve(n));

    [Theory]
    [InlineData(5, 2, 1, 2)]
    [InlineData(5, 2, 2, 3)]
    [InlineData(7, 19, 2, 6)]
    [InlineData(3, 7, 3, 3)]
    [InlineData(999999999, 999999999, 999999999, 999999998)]
    public void SaveThePrisoner_Samples(int n, int m, int s, int expected) =>
        Assert.Equal(expected, SaveThePrisoner.Solve(n, m, s));

    [Theory]
    [InlineData(new[] { 0, 0, 1, 0, 0, 1, 0 }, 4)]
    [InlineData(new[] { 0, 0, 0, 0, 1, 0 }, 3)]
    public void JumpingOnTheClouds_Samples(int[] c, int expected) =>
        Assert.Equal(expected, JumpingOnTheClouds.Solve(c));

    [Theory]
    [InlineData("aba", 10L, 7L)]
    [InlineData("a", 1000000000000L, 1000000000000L)]
    public void RepeatedString_Samples(string s, long n, long expected) =>
        Assert.Equal(expected, RepeatedString.Solve(s, n));

    [Fact]
    public void EqualizeTheArray_CountsDeletions() =>
        Assert.Equal(2, EqualizeTheArray.Solve([3, 3, 2, 1, 3]));
}
