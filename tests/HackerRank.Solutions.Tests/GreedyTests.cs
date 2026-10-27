using HackerRank.Solutions.Greedy;

namespace HackerRank.Solutions.Tests;

public class GreedyTests
{
    [Theory]
    [InlineData(new[] { 3, -7, 0 }, 3)]
    [InlineData(new[] { -59, -36, -13, 1, -53, -92, -2, -96, -62, 88 }, 3)]
    [InlineData(new[] { 1, -3, 71, 68, 17 }, 3)]
    public void MinimumAbsoluteDifference_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, MinimumAbsoluteDifference.Solve(arr));

    [Fact]
    public void LuckBalance_LosesLuckiestImportantContests()
    {
        int[][] contests = [[5, 1], [2, 1], [1, 1], [8, 1], [10, 0], [5, 0]];
        Assert.Equal(29, LuckBalance.Solve(3, contests));
    }

    [Fact]
    public void LuckBalance_WinsAllImportantWhenKIsZero()
    {
        int[][] contests = [[5, 1], [1, 1], [4, 0]];
        Assert.Equal(-2, LuckBalance.Solve(0, contests));
    }

    [Theory]
    [InlineData(new[] { "ebacd", "fghij", "olmkn", "trpqs", "xywuv" }, "YES")]
    [InlineData(new[] { "mpxz", "abcd", "wlmf" }, "NO")]
    [InlineData(new[] { "abc", "hjk", "mpq", "rtv" }, "YES")]
    public void GridChallenge_Samples(string[] grid, string expected) =>
        Assert.Equal(expected, GridChallenge.Solve(grid));

    [Theory]
    [InlineData(3, new[] { 10, 100, 300, 200, 1000, 20, 30 }, 20)]
    [InlineData(4, new[] { 1, 2, 3, 4, 10, 20, 30, 40, 100, 200 }, 3)]
    [InlineData(2, new[] { 1, 2, 1, 2, 1 }, 0)]
    public void MaxMin_Samples(int k, int[] arr, int expected) =>
        Assert.Equal(expected, MaxMin.Solve(k, arr));

    [Theory]
    [InlineData(3, new[] { 2, 5, 6 }, 13L)]
    [InlineData(2, new[] { 2, 5, 6 }, 15L)]
    [InlineData(3, new[] { 1, 3, 5, 7, 9 }, 29L)]
    public void GreedyFlorist_Samples(int k, int[] c, long expected) =>
        Assert.Equal(expected, GreedyFlorist.Solve(k, c));

    [Fact]
    public void JimAndTheOrders_ServesByCompletionTime()
    {
        int[][] orders = [[8, 1], [4, 2], [5, 6], [3, 1], [4, 3]];
        Assert.Equal([4, 2, 5, 1, 3], JimAndTheOrders.Solve(orders));
    }

    [Fact]
    public void JimAndTheOrders_BreaksTiesByCustomerNumber()
    {
        int[][] orders = [[1, 3], [2, 3], [3, 3]];
        Assert.Equal([1, 2, 3], JimAndTheOrders.Solve(orders));
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 3 }, 4)]
    [InlineData(new[] { 3, 5, 7, 11, 5, 8 }, new[] { 5, 7, 11, 10, 5, 8 }, 6)]
    [InlineData(new[] { 1, 2 }, new[] { 1, 2 }, 1)]
    public void BeautifulPairs_Samples(int[] a, int[] b, int expected) =>
        Assert.Equal(expected, BeautifulPairs.Solve(a, b));

    [Theory]
    [InlineData(1, "-1")]
    [InlineData(3, "555")]
    [InlineData(5, "33333")]
    [InlineData(11, "55555533333")]
    public void SherlockAndTheBeast_Samples(int n, string expected) =>
        Assert.Equal(expected, SherlockAndTheBeast.Solve(n));

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, 10, 11, 12, 13 }, 2)]
    [InlineData(new[] { 1, 2, 3, 21, 7, 12, 14, 21 }, 4)]
    public void PriyankaAndToys_Samples(int[] w, int expected) =>
        Assert.Equal(expected, PriyankaAndToys.Solve(w));

    [Theory]
    [InlineData(10, new[] { 2, 1, 3 }, new[] { 7, 8, 9 }, "YES")]
    [InlineData(5, new[] { 1, 2, 2, 1 }, new[] { 3, 3, 3, 4 }, "NO")]
    public void PermutingTwoArrays_Samples(int k, int[] a, int[] b, string expected) =>
        Assert.Equal(expected, PermutingTwoArrays.Solve(k, a, b));

    [Theory]
    [InlineData(new[] { 1, 3, 2 }, 11L)]
    [InlineData(new[] { 7, 4, 9, 6 }, 79L)]
    public void MarcsCakewalk_Samples(int[] calorie, long expected) =>
        Assert.Equal(expected, MarcsCakewalk.Solve(calorie));

    [Theory]
    [InlineData(1, new[] { 4, 2, 3, 5, 1 }, new[] { 5, 2, 3, 4, 1 })]
    [InlineData(1, new[] { 2, 1, 3 }, new[] { 3, 1, 2 })]
    [InlineData(1, new[] { 2, 1 }, new[] { 2, 1 })]
    [InlineData(5, new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1 })]
    public void LargestPermutation_Samples(int k, int[] arr, int[] expected) =>
        Assert.Equal(expected, LargestPermutation.Solve(k, arr));

    [Theory]
    [InlineData(new[] { 3, 4, 3, 2, 4 }, 4L)]
    [InlineData(new[] { 4, 4, 4 }, 4L)]
    [InlineData(new[] { 1, 6, 4 }, 3L)]
    public void ChiefHopper_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, ChiefHopper.Solve(arr));

    [Theory]
    [InlineData(2, new[] { 0, 1, 1, 1, 1, 0 }, 2)]
    [InlineData(3, new[] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 }, 3)]
    [InlineData(1, new[] { 0, 1 }, -1)]
    [InlineData(2, new[] { 1, 0, 0, 0, 1 }, -1)]
    public void GoodlandElectricity_Samples(int k, int[] arr, int expected) =>
        Assert.Equal(expected, GoodlandElectricity.Solve(k, arr));

    [Theory]
    [InlineData(new[] { 2L }, new[] { 1L }, 4L)]
    [InlineData(new[] { 2L, 1L, 3L, 1L, 4L }, new[] { 4L, 1L, 2L }, 42L)]
    public void CuttingBoards_Samples(long[] costY, long[] costX, long expected) =>
        Assert.Equal(expected, CuttingBoards.Solve(costY, costX));

    [Fact]
    public void CuttingBoards_ReducesModulo() =>
        Assert.Equal(999_999_972L, CuttingBoards.Solve([1_000_000_000L, 1_000_000_000L], [1_000_000_000L]));

    [Theory]
    [InlineData("eggegg", "egg")]
    [InlineData("abcdefgabcdefg", "agfedcb")]
    [InlineData("aeiouuoiea", "aeiou")]
    public void ReverseShuffleMerge_Samples(string s, string expected) =>
        Assert.Equal(expected, ReverseShuffleMerge.Solve(s));

    [Fact]
    public void FlippingTheMatrix_Samples()
    {
        Assert.Equal(414, FlippingTheMatrix.Solve([[112, 42, 83, 119], [56, 125, 56, 49], [15, 78, 101, 43], [62, 98, 114, 108]]));
        Assert.Equal(4, FlippingTheMatrix.Solve([[1, 2], [3, 4]]));
    }

    [Theory]
    [InlineData(new[] { 1, 1, 1, 3, 3 }, new[] { 1, 3, 3 })]
    [InlineData(new[] { 1, 2, 3 }, new[] { -1 })]
    [InlineData(new[] { 1, 1, 1, 2, 3, 5 }, new[] { 1, 1, 1 })]
    public void MaximumPerimeterTriangle_Samples(int[] sticks, int[] expected) =>
        Assert.Equal(expected, MaximumPerimeterTriangle.Solve(sticks));

    [Theory]
    [InlineData(new[] { 5, 8, 14 }, 4, 9, 4)]
    [InlineData(new[] { 3, 5, 7, 9 }, 6, 8, 6)]
    [InlineData(new[] { 1, 10 }, 1, 10, 5)]
    [InlineData(new[] { 100 }, 1, 200, 200)]
    public void SherlockAndMinimax_Samples(int[] arr, int p, int q, int expected) =>
        Assert.Equal(expected, SherlockAndMinimax.Solve(arr, p, q));

    [Fact]
    public void SherlockAndMinimax_MatchesBruteForce()
    {
        var random = new Random(7);
        for (int trial = 0; trial < 300; trial++)
        {
            var arr = Enumerable.Range(0, random.Next(1, 6)).Select(_ => random.Next(1, 60)).ToArray();
            int p = random.Next(1, 60);
            int q = random.Next(p, 70);

            int expected = Enumerable.Range(p, q - p + 1)
                .OrderByDescending(m => arr.Min(a => Math.Abs(a - m)))
                .ThenBy(m => m)
                .First();

            Assert.Equal(expected, SherlockAndMinimax.Solve(arr, p, q));
        }
    }

    [Theory]
    [InlineData(3L, 1L, 2L, 12L, 3L)]
    [InlineData(1L, 1L, 6L, 45L, 16L)]
    [InlineData(5_184_889_632L, 5_184_889_632L, 20L, 10_000L, 1L)]
    [InlineData(1L, 1L, 100L, 10L, 10L)]
    [InlineData(1L, 1L, 1_000_000_000_000L, 1_000_000_000_000L, 1_000_000_000_000L)]
    public void MakingCandies_Samples(long m, long w, long p, long n, long expected) =>
        Assert.Equal(expected, MakingCandies.Solve(m, w, p, n));

    [Theory]
    [InlineData(new[] { 4, 5, 2, 3, -4, -3, -5 }, 3)]
    [InlineData(new[] { -4 }, 1)]
    [InlineData(new[] { 3, 2, 3, 1 }, 1)]
    [InlineData(new[] { 1, -2, -3, -4, 2, 0, -1 }, 7)]
    [InlineData(new[] { 1, 2, 2, 3 }, 2)]
    [InlineData(new int[0], 0)]
    public void TeamFormation_Samples(int[] skills, int expected) =>
        Assert.Equal(expected, TeamFormation.Solve(skills));

    [Fact]
    public void IntervalSelection_Samples()
    {
        Assert.Equal(2, IntervalSelection.Solve([[1, 2], [2, 3], [2, 4]]));
        Assert.Equal(2, IntervalSelection.Solve([[1, 5], [1, 5], [1, 5]]));
        Assert.Equal(4, IntervalSelection.Solve([[1, 10], [1, 3], [4, 6], [7, 10]]));
        Assert.Equal(3, IntervalSelection.Solve([[1, 10], [1, 3], [3, 6], [7, 10]]));
    }

    [Fact]
    public void IntervalSelection_MatchesBruteForce()
    {
        var random = new Random(59);
        for (int trial = 0; trial < 150; trial++)
        {
            var intervals = Enumerable.Range(0, random.Next(1, 9)).Select(_ =>
            {
                int a = random.Next(0, 15), b = random.Next(0, 15);
                return new[] { Math.Min(a, b), Math.Max(a, b) };
            }).ToArray();

            int expected = 0;
            for (int mask = 0; mask < 1 << intervals.Length; mask++)
            {
                var chosen = intervals.Where((_, i) => (mask & (1 << i)) != 0).ToArray();
                bool valid = Enumerable.Range(0, 15).All(point => chosen.Count(c => c[0] <= point && point <= c[1]) <= 2);
                if (valid)
                {
                    expected = Math.Max(expected, chosen.Length);
                }
            }

            Assert.Equal(expected, IntervalSelection.Solve(intervals));
        }
    }

    [Fact]
    public void CloudyDay_Sample() =>
        Assert.Equal(110L, CloudyDay.Solve([10, 100], [5, 100], [4], [1]));

    [Fact]
    public void CloudyDay_MatchesBruteForce()
    {
        var random = new Random(17);
        for (int trial = 0; trial < 200; trial++)
        {
            int towns = random.Next(1, 7);
            int clouds = random.Next(1, 5);
            var p = Enumerable.Range(0, towns).Select(_ => (long)random.Next(1, 50)).ToArray();
            var x = Enumerable.Range(0, towns).Select(_ => (long)random.Next(1, 30)).ToArray();
            var y = Enumerable.Range(0, clouds).Select(_ => (long)random.Next(1, 30)).ToArray();
            var r = Enumerable.Range(0, clouds).Select(_ => (long)random.Next(0, 6)).ToArray();

            long expected = Enumerable.Range(0, clouds).Max(removed =>
                Enumerable.Range(0, towns)
                    .Where(t => Enumerable.Range(0, clouds).All(c => c == removed || Math.Abs(x[t] - y[c]) > r[c]))
                    .Sum(t => p[t]));

            Assert.Equal(expected, CloudyDay.Solve(p, x, y, r));
        }
    }
}
