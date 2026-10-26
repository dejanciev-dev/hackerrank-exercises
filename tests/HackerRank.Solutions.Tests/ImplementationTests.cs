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

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 2, new[] { 0, 1, 2 }, new[] { 2, 3, 1 })]
    [InlineData(new[] { 3, 4, 5 }, 2, new[] { 1, 2 }, new[] { 5, 3 })]
    [InlineData(new[] { 1, 2, 3 }, 7, new[] { 0 }, new[] { 3 })] // k larger than n
    public void CircularArrayRotation_Samples(int[] a, int k, int[] queries, int[] expected) =>
        Assert.Equal(expected, CircularArrayRotation.Solve(a, k, queries));

    [Theory]
    [InlineData(new[] { 5, 2, 1, 3, 4 }, new[] { 4, 2, 5, 1, 3 })]
    [InlineData(new[] { 2, 3, 1 }, new[] { 2, 3, 1 })]
    [InlineData(new[] { 4, 3, 5, 1, 2 }, new[] { 1, 3, 5, 4, 2 })]
    public void SequenceEquation_Samples(int[] p, int[] expected) =>
        Assert.Equal(expected, SequenceEquation.Solve(p));

    [Fact]
    public void JumpingOnTheCloudsRevisited_ReturnsRemainingEnergy() =>
        Assert.Equal(92, JumpingOnTheCloudsRevisited.Solve([0, 0, 1, 0, 0, 1, 1, 0], 2));

    [Theory]
    [InlineData(new[] { 5, 4, 4, 2, 2, 8 }, new[] { 6, 4, 2, 1 })]
    [InlineData(new[] { 1, 2, 3, 4, 3, 3, 2, 1 }, new[] { 8, 6, 4, 1 })]
    public void CutTheSticks_Samples(int[] arr, int[] expected) =>
        Assert.Equal(expected, CutTheSticks.Solve(arr));

    [Theory]
    [InlineData(3, new[] { 1, 7, 2, 4 }, 3)]
    [InlineData(4, new[] { 19, 10, 12, 10, 24, 25, 22 }, 3)]
    [InlineData(1, new[] { 1, 2, 3 }, 1)]
    public void NonDivisibleSubset_Samples(int k, int[] s, int expected) =>
        Assert.Equal(expected, NonDivisibleSubset.Solve(k, s));

    [Fact]
    public void AcmIcpcTeam_FindsBestTeams() =>
        Assert.Equal([5, 2], AcmIcpcTeam.Solve(["10101", "11100", "11010", "00101"]));

    [Theory]
    [InlineData(10, 10, 1, 1, 1, 20)]
    [InlineData(5, 9, 2, 3, 4, 37)]
    [InlineData(3, 6, 9, 1, 1, 12)]
    [InlineData(7, 7, 4, 2, 1, 35)]
    [InlineData(3, 3, 1, 9, 2, 12)]
    public void TaumAndBday_Samples(long b, long w, long bc, long wc, long z, long expected) =>
        Assert.Equal(expected, TaumAndBday.Solve(b, w, bc, wc, z));

    [Fact]
    public void ModifiedKaprekarNumbers_FindsNumbersInRange() =>
        Assert.Equal([1, 9, 45, 55, 99], ModifiedKaprekarNumbers.Solve(1, 100));

    [Fact]
    public void ModifiedKaprekarNumbers_ReturnsEmptyForInvalidRange() =>
        Assert.Empty(ModifiedKaprekarNumbers.Solve(400, 700));

    [Theory]
    [InlineData(3, new[] { 1, 2, 4, 5, 7, 8, 10 }, 3)]
    [InlineData(1, new[] { 2, 2, 3, 4, 5 }, 3)]
    public void BeautifulTriplets_Samples(int d, int[] arr, long expected) =>
        Assert.Equal(expected, BeautifulTriplets.Solve(d, arr));

    [Theory]
    [InlineData(new[] { 7, 1, 3, 4, 1, 7 }, 3)]
    [InlineData(new[] { 1, 2, 3, 4, 10 }, -1)]
    public void MinimumDistances_Samples(int[] a, int expected) =>
        Assert.Equal(expected, MinimumDistances.Solve(a));

    [Theory]
    [InlineData(20, 3, 6, 80, 6)]
    [InlineData(20, 3, 6, 85, 7)]
    [InlineData(20, 3, 6, 19, 0)]
    public void HalloweenSale_Samples(int p, int d, int m, int s, int expected) =>
        Assert.Equal(expected, HalloweenSale.Solve(p, d, m, s));

    [Theory]
    [InlineData(10, 2, 5, 6)]
    [InlineData(12, 4, 4, 3)]
    [InlineData(6, 2, 2, 5)]
    public void ChocolateFeast_Samples(int n, int c, int m, int expected) =>
        Assert.Equal(expected, ChocolateFeast.Solve(n, c, m));

    [Fact]
    public void ServiceLane_FindsNarrowestWidth()
    {
        int[][] cases = [[0, 3], [4, 6], [6, 7], [3, 5], [0, 7]];
        Assert.Equal([1, 2, 3, 2, 1], ServiceLane.Solve([2, 3, 1, 2, 3, 2, 3, 3], cases));
    }

    [Fact]
    public void LisasWorkbook_CountsSpecialProblems() =>
        Assert.Equal(4, LisasWorkbook.Solve(3, [4, 2, 6, 1, 10]));

    [Theory]
    [InlineData(5, new[] { 0, 4 }, 2)]
    [InlineData(6, new[] { 0, 1, 2, 4, 3, 5 }, 0)]
    [InlineData(20, new[] { 13, 1, 11, 10, 6 }, 6)]
    public void FlatlandSpaceStations_Samples(int n, int[] c, int expected) =>
        Assert.Equal(expected, FlatlandSpaceStations.Solve(n, c));

    [Theory]
    [InlineData(new[] { 2, 3, 4, 5, 6 }, "4")]
    [InlineData(new[] { 1, 2 }, "NO")]
    [InlineData(new[] { 4, 5, 6, 7 }, "4")]
    public void FairRations_Samples(int[] b, string expected) =>
        Assert.Equal(expected, FairRations.Solve(b));

    [Fact]
    public void CavityMap_MarksCavities() =>
        Assert.Equal(
            ["1112", "1X12", "18X2", "1234"],
            CavityMap.Solve(["1112", "1912", "1892", "1234"]));

    [Theory]
    [InlineData(3, 1, 2, new[] { 2, 3, 4 })]
    [InlineData(4, 10, 100, new[] { 30, 120, 210, 300 })]
    [InlineData(3, 5, 5, new[] { 10 })]
    public void ManasaAndStones_Samples(int n, int a, int b, int[] expected) =>
        Assert.Equal(expected, ManasaAndStones.Solve(n, a, b));

    [Theory]
    [InlineData("RBY_YBR", "YES")]
    [InlineData("X_Y__X", "NO")]
    [InlineData("__", "YES")]
    [InlineData("B_RRBR", "YES")]
    [InlineData("AABBC", "NO")]
    [InlineData("AABBC_C", "YES")]
    [InlineData("_", "YES")]
    [InlineData("DD__FQ_QQF", "YES")]
    [InlineData("AABCBC", "NO")]
    public void HappyLadybugs_Samples(string b, string expected) =>
        Assert.Equal(expected, HappyLadybugs.Solve(b));

    [Theory]
    [InlineData(1L, 3L)]
    [InlineData(3L, 1L)]
    [InlineData(4L, 6L)]
    [InlineData(10L, 12L)]
    [InlineData(21L, 1L)]
    public void StrangeCounter_Samples(long t, long expected) =>
        Assert.Equal(expected, StrangeCounter.Solve(t));

    [Theory]
    [InlineData(1, "1")]
    [InlineData(5, "120")]
    [InlineData(25, "15511210043330985984000000")]
    public void ExtraLongFactorials_Samples(int n, string expected) =>
        Assert.Equal(expected, ExtraLongFactorials.Solve(n));

    [Theory]
    [InlineData(9, 6, 2015, 6, 6, 2015, 45)]
    [InlineData(14, 7, 2018, 5, 7, 2018, 135)]
    [InlineData(1, 8, 2018, 31, 6, 2018, 1000)]
    [InlineData(1, 1, 2019, 31, 12, 2018, 10000)]
    [InlineData(2, 7, 1014, 1, 1, 1015, 0)]
    public void LibraryFine_Samples(int d1, int m1, int y1, int d2, int m2, int y2, int expected) =>
        Assert.Equal(expected, LibraryFine.Solve(d1, m1, y1, d2, m2, y2));

    [Theory]
    [InlineData("ab", "ba")]
    [InlineData("bb", "no answer")]
    [InlineData("hefg", "hegf")]
    [InlineData("dhck", "dhkc")]
    [InlineData("dkhc", "hcdk")]
    [InlineData("lmno", "lmon")]
    [InlineData("dcba", "no answer")]
    [InlineData("dcbb", "no answer")]
    [InlineData("abdc", "acbd")]
    [InlineData("abcd", "abdc")]
    [InlineData("fedcbabcd", "fedcbabdc")]
    public void BiggerIsGreater_Samples(string w, string expected) =>
        Assert.Equal(expected, BiggerIsGreater.Solve(w));

    [Fact]
    public void OrganizingContainers_Possible()
    {
        int[][] container = [[1, 1], [1, 1]];
        Assert.Equal("Possible", OrganizingContainers.Solve(container));

        int[][] second = [[0, 2, 1], [1, 1, 1], [2, 0, 0]];
        Assert.Equal("Possible", OrganizingContainers.Solve(second));
    }

    [Fact]
    public void OrganizingContainers_Impossible()
    {
        int[][] container = [[0, 2], [1, 1]];
        Assert.Equal("Impossible", OrganizingContainers.Solve(container));

        int[][] second = [[1, 3, 1], [2, 1, 2], [3, 3, 3]];
        Assert.Equal("Impossible", OrganizingContainers.Solve(second));
    }

    [Theory]
    [InlineData("haveaniceday", "hae and via ecy")]
    [InlineData("feedthedog", "fto ehg ee dd")]
    [InlineData("chillout", "clu hlt io")]
    [InlineData("if man was meant to stay on the ground god would have given us roots",
        "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau")]
    public void Encryption_Samples(string s, string expected) =>
        Assert.Equal(expected, Encryption.Solve(s));

    [Fact]
    public void QueensAttackII_EmptyBoard() =>
        Assert.Equal(9, QueensAttackII.Solve(4, 4, 4, []));

    [Fact]
    public void QueensAttackII_WithObstacles()
    {
        int[][] obstacles = [[5, 5], [4, 2], [2, 3]];
        Assert.Equal(10, QueensAttackII.Solve(5, 4, 3, obstacles));
    }

    [Fact]
    public void QueensAttackII_SingleSquareBoard() =>
        Assert.Equal(0, QueensAttackII.Solve(1, 1, 1, []));

    [Fact]
    public void FormingAMagicSquare_Samples()
    {
        int[][] first = [[4, 9, 2], [3, 5, 7], [8, 1, 5]];
        Assert.Equal(1, FormingAMagicSquare.Solve(first));

        int[][] second = [[4, 8, 2], [4, 5, 7], [6, 1, 6]];
        Assert.Equal(4, FormingAMagicSquare.Solve(second));

        int[][] third = [[5, 3, 4], [1, 5, 8], [6, 4, 2]];
        Assert.Equal(7, FormingAMagicSquare.Solve(third));
    }

    [Theory]
    [InlineData(6, 2, 1)]
    [InlineData(5, 4, 0)]
    [InlineData(6, 5, 1)]
    [InlineData(1, 1, 0)]
    public void DrawingBook_Samples(int n, int p, int expected) =>
        Assert.Equal(expected, DrawingBook.Solve(n, p));

    [Fact]
    public void SurfaceArea3D_Samples()
    {
        int[][] single = [[1]];
        Assert.Equal(6, SurfaceArea3D.Solve(single));

        int[][] grid = [[1, 3, 4], [2, 2, 3], [1, 2, 4]];
        Assert.Equal(60, SurfaceArea3D.Solve(grid));
    }

    [Theory]
    [InlineData(new[] { 4, 2 }, new[] { "yes", "swap 1 2" })]
    [InlineData(new[] { 3, 1, 2 }, new[] { "no" })]
    [InlineData(new[] { 1, 5, 4, 3, 2, 6 }, new[] { "yes", "reverse 2 5" })]
    [InlineData(new[] { 1, 2, 3 }, new[] { "yes" })]
    [InlineData(new[] { 1, 6, 3, 4, 5, 2 }, new[] { "yes", "swap 2 6" })]
    public void AlmostSorted_Samples(int[] arr, string[] expected) =>
        Assert.Equal(expected, AlmostSorted.Solve(arr));

    [Theory]
    [InlineData(2, 1, new[] { 2, 1 })]
    [InlineData(3, 0, new[] { 1, 2, 3 })]
    [InlineData(3, 2, new[] { -1 })]
    [InlineData(4, 2, new[] { 3, 4, 1, 2 })]
    public void AbsolutePermutation_Samples(int n, int k, int[] expected) =>
        Assert.Equal(expected, AbsolutePermutation.Solve(n, k));

    [Fact]
    public void TheGridSearch_FindsPattern() =>
        Assert.Equal("YES", TheGridSearch.Solve(
            ["7283455864", "6731158619", "8988242643", "3830589324", "2229505813",
             "5633845374", "6473530293", "7053106601", "0834282956", "4607924137"],
            ["9505", "3845", "3530"]));

    [Theory]
    [InlineData(new[] { "23", "68" }, "NO")]
    [InlineData(new[] { "34", "78" }, "YES")]
    [InlineData(new[] { "1234", "5678" }, "YES")]
    public void TheGridSearch_SmallGrid(string[] pattern, string expected) =>
        Assert.Equal(expected, TheGridSearch.Solve(["1234", "5678"], pattern));

    [Theory]
    [InlineData(new[] { 3, 1, 2 }, "YES")]
    [InlineData(new[] { 1, 3, 4, 2 }, "YES")]
    [InlineData(new[] { 1, 2, 3, 5, 4 }, "NO")]
    public void LarrysArray_Samples(int[] a, string expected) =>
        Assert.Equal(expected, LarrysArray.Solve(a));

    [Theory]
    [InlineData(5, 47, "thirteen minutes to six")]
    [InlineData(3, 0, "three o' clock")]
    [InlineData(7, 15, "quarter past seven")]
    [InlineData(5, 30, "half past five")]
    [InlineData(5, 45, "quarter to six")]
    [InlineData(5, 1, "one minute past five")]
    [InlineData(5, 10, "ten minutes past five")]
    [InlineData(5, 28, "twenty eight minutes past five")]
    [InlineData(5, 40, "twenty minutes to six")]
    [InlineData(12, 59, "one minute to one")]
    public void TheTimeInWords_Samples(int h, int m, string expected) =>
        Assert.Equal(expected, TheTimeInWords.Solve(h, m));
}
