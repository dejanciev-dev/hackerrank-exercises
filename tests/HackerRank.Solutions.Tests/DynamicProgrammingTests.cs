using HackerRank.Solutions.DynamicProgramming;

namespace HackerRank.Solutions.Tests;

public class DynamicProgrammingTests
{
    [Theory]
    [InlineData(4, new[] { 1, 2, 3 }, 4L)]
    [InlineData(10, new[] { 2, 5, 3, 6 }, 5L)]
    [InlineData(3, new[] { 2 }, 0L)]
    public void CoinChange_Samples(int n, int[] c, long expected) =>
        Assert.Equal(expected, CoinChange.Solve(n, c));

    [Theory]
    [InlineData(0, 1, 5, "5")]
    [InlineData(0, 1, 6, "27")]
    [InlineData(0, 1, 10, "84266613096281243382112")]
    public void FibonacciModified_Samples(int t1, int t2, int n, string expected) =>
        Assert.Equal(expected, FibonacciModified.Solve(t1, t2, n));

    [Theory]
    [InlineData(new[] { 2, 2, 3, 7 }, 2L)]
    [InlineData(new[] { 10, 7, 12 }, 3L)]
    [InlineData(new[] { 1, 1, 5 }, 2L)]
    [InlineData(new[] { 1, 5, 5 }, 3L)]
    public void Equal_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, Equal.Solve(arr));

    [Theory]
    [InlineData("16", 23L)]
    [InlineData("123", 164L)]
    public void SamAndSubstrings_Samples(string n, long expected) =>
        Assert.Equal(expected, SamAndSubstrings.Solve(n));

    [Theory]
    [InlineData(new[] { 5, 3, 2 }, 0L)]
    [InlineData(new[] { 1, 2, 100 }, 197L)]
    [InlineData(new[] { 1, 3, 1, 2 }, 3L)]
    public void StockMaximize_Samples(int[] prices, long expected) =>
        Assert.Equal(expected, StockMaximize.Solve(prices));

    [Theory]
    [InlineData(new[] { 3, 7, 4, 6, 5 }, 13L)]
    [InlineData(new[] { 2, 1, 5, 8, 4 }, 11L)]
    [InlineData(new[] { 3, 5, -7, 8, 10 }, 15L)]
    public void MaxArraySum_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, MaxArraySum.Solve(arr));

    [Theory]
    [InlineData(new[] { 1, 2, 2 }, 4L)]
    [InlineData(new[] { 2, 4, 2, 6, 1, 7, 8, 9, 2, 1 }, 19L)]
    [InlineData(new[] { 2, 4, 3, 5, 2, 6, 4, 5 }, 12L)]
    public void Candies_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, Candies.Solve(arr));

    [Theory]
    [InlineData(new[] { 10, 1, 10, 1, 10 }, 36L)]
    [InlineData(new[] { 100, 2, 100, 2, 100 }, 396L)]
    [InlineData(new[] { 1, 2, 3 }, 2L)]
    public void SherlockAndCost_Samples(int[] b, long expected) =>
        Assert.Equal(expected, SherlockAndCost.Solve(b));

    [Theory]
    [InlineData("daBcd", "ABC", "YES")]
    [InlineData("AbcDE", "ABDE", "YES")]
    [InlineData("AbcDE", "AFDE", "NO")]
    [InlineData("beFgH", "EFG", "NO")]
    public void Abbreviation_Samples(string a, string b, string expected) =>
        Assert.Equal(expected, Abbreviation.Solve(a, b));

    [Theory]
    [InlineData(new[] { 2, 7, 4, 3, 8 }, 3)]
    [InlineData(new[] { 2, 4, 3, 7, 4, 5 }, 4)]
    [InlineData(new[] { 5, 2, 8, 6, 3, 6, 9, 7 }, 4)]
    [InlineData(new[] { 3, 3, 3 }, 1)]
    public void LongestIncreasingSubsequence_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, LongestIncreasingSubsequence.Solve(arr));

    [Theory]
    [InlineData(12, new[] { 1, 6, 9 }, 12)]
    [InlineData(9, new[] { 3, 4, 4, 4, 8 }, 9)]
    [InlineData(5, new[] { 6 }, 0)]
    public void Knapsack_Samples(int k, int[] arr, int expected) =>
        Assert.Equal(expected, Knapsack.Solve(k, arr));

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 10L, 10L })]
    [InlineData(new[] { 2, -1, 2, 3, 4, -5 }, new[] { 10L, 11L })]
    [InlineData(new[] { -2, -3, -1, -4, -6 }, new[] { -1L, -1L })]
    [InlineData(new[] { -1, 0, -2 }, new[] { 0L, 0L })]
    public void MaximumSubarray_Samples(int[] arr, long[] expected) =>
        Assert.Equal(expected, MaximumSubarray.Solve(arr));

    [Theory]
    [InlineData(1, 0)]
    [InlineData(4, 1)]
    [InlineData(7, 3)]
    [InlineData(40, 19385)]
    public void RedJohnIsBack_Samples(int n, int expected) =>
        Assert.Equal(expected, RedJohnIsBack.Solve(n));

    [Theory]
    [InlineData(4, 3, 2, 3L)]
    [InlineData(761, 99, 1, 236568308L)]
    [InlineData(3, 2, 1, 1L)]
    [InlineData(3, 2, 2, 0L)]
    public void ConstructTheArray_Samples(int n, int k, int x, long expected) =>
        Assert.Equal(expected, ConstructTheArray.Solve(n, k, x));

    [Theory]
    [InlineData(new[] { 3, 2, 2 }, 10L)]
    [InlineData(new[] { 3, 2, 5 }, 16L)]
    [InlineData(new[] { 100 }, 100L)]
    public void MandragoraForest_Samples(int[] h, long expected) =>
        Assert.Equal(expected, MandragoraForest.Solve(h));

    [Theory]
    [InlineData(2, 2, 3L)]
    [InlineData(3, 2, 7L)]
    [InlineData(2, 3, 9L)]
    [InlineData(4, 4, 3375L)]
    [InlineData(1, 5, 0L)]
    public void LegoBlocks_Samples(int n, int m, long expected) =>
        Assert.Equal(expected, LegoBlocks.Solve(n, m));

    [Fact]
    public void LongestCommonSubsequence_ReturnsACommonSubsequenceOfMaxLength()
    {
        int[] a = [1, 2, 3, 4, 1];
        int[] b = [3, 4, 1, 2, 1, 3];
        var lcs = LongestCommonSubsequence.Solve(a, b);

        Assert.Equal(3, lcs.Length);
        Assert.True(IsSubsequence(lcs, a));
        Assert.True(IsSubsequence(lcs, b));
    }

    [Fact]
    public void LongestCommonSubsequence_UniqueAnswer()
    {
        Assert.Equal([2, 3], LongestCommonSubsequence.Solve([1, 2, 3], [2, 3, 4]));
        Assert.Empty(LongestCommonSubsequence.Solve([1, 2], [3, 4]));
    }

    private static bool IsSubsequence(int[] sub, int[] sequence)
    {
        int matched = 0;
        foreach (var value in sequence)
        {
            if (matched < sub.Length && sub[matched] == value)
            {
                matched++;
            }
        }

        return matched == sub.Length;
    }

    [Theory]
    [InlineData(new[] { 1, 3, 6 }, 73L)]
    [InlineData(new[] { 4, 2, 9, 10, 1 }, 971L)]
    [InlineData(new[] { 5 }, 5L)]
    public void SummingPieces_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, SummingPieces.Solve(arr));

    [Fact]
    public void SummingPieces_MatchesBruteForce()
    {
        int[] arr = [3, 1, 4, 1, 5, 9, 2, 6];
        long expected = 0;

        // Each mask chooses which of the n - 1 gaps get a cut.
        for (int mask = 0; mask < 1 << (arr.Length - 1); mask++)
        {
            long sum = 0;
            int length = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                length++;
                if (i == arr.Length - 1 || (mask & (1 << i)) != 0)
                {
                    expected += sum * length;
                    sum = 0;
                    length = 0;
                }
            }
        }

        Assert.Equal(expected, SummingPieces.Solve(arr));
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 6L)]
    [InlineData(new[] { 0, 1, 1, 1, 999 }, 999L)]
    [InlineData(new[] { 999, 1, 1, 1, 0 }, 1001L)]
    [InlineData(new[] { 7 }, 7L)]
    public void BricksGame_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, BricksGame.Solve(arr));

    [Theory]
    [InlineData("eeegeeksforskeeggeeks", 50L)]
    [InlineData("ab", 1L)]
    [InlineData("aaaa", 4L)]
    public void PlayWithWords_Samples(string s, long expected) =>
        Assert.Equal(expected, PlayWithWords.Solve(s));

    [Fact]
    public void KingdomDivision_Sample() =>
        Assert.Equal(4L, KingdomDivision.Solve(5, [[1, 2], [1, 3], [3, 4], [3, 5]]));

    [Fact]
    public void KingdomDivision_MatchesBruteForce()
    {
        var random = new Random(9);
        for (int trial = 0; trial < 60; trial++)
        {
            int n = random.Next(2, 11);
            var roads = Enumerable.Range(2, n - 1).Select(v => new[] { random.Next(1, v), v }).ToArray();

            long expected = 0;
            for (int mask = 0; mask < 1 << n; mask++)
            {
                bool Colour(int city) => (mask & (1 << (city - 1))) != 0;
                bool valid = Enumerable.Range(1, n).All(city =>
                    roads.Any(r => (r[0] == city && Colour(r[1]) == Colour(city)) || (r[1] == city && Colour(r[0]) == Colour(city))));

                if (valid)
                {
                    expected++;
                }
            }

            Assert.Equal(expected, KingdomDivision.Solve(n, roads));
        }
    }

    [Theory]
    [InlineData(3, new[] { 10L, 100L, 300L, 200L, 1000L, 20L, 30L }, 40L)]
    [InlineData(4, new[] { 1L, 2L, 3L, 4L, 10L, 20L, 30L, 40L, 100L, 200L }, 10L)]
    [InlineData(2, new[] { 1_000_000_000L, 0L, 999_999_999L }, 1L)]
    public void AngryChildren2_Samples(int k, long[] packets, long expected) =>
        Assert.Equal(expected, AngryChildren2.Solve(k, packets));

    [Fact]
    public void AngryChildren2_MatchesBruteForce()
    {
        var random = new Random(13);
        for (int trial = 0; trial < 100; trial++)
        {
            var packets = Enumerable.Range(0, random.Next(2, 9)).Select(_ => (long)random.Next(0, 100)).ToArray();
            int k = random.Next(2, packets.Length + 1);
            var sorted = packets.Order().ToArray();

            long expected = Enumerable.Range(0, sorted.Length - k + 1).Min(l =>
            {
                var window = sorted.Skip(l).Take(k).ToArray();
                return window.SelectMany((a, i) => window.Skip(i + 1).Select(b => b - a)).Sum();
            });

            Assert.Equal(expected, AngryChildren2.Solve(k, packets));
        }
    }

    [Fact]
    public void MrKMarsh_Samples()
    {
        Assert.Equal("14", MrKMarsh.Solve([".....", ".x.x.", ".....", "....."]));
        Assert.Equal("impossible", MrKMarsh.Solve([".x", "x."]));
        Assert.Equal("4", MrKMarsh.Solve(["..", ".."]));
    }

    [Fact]
    public void MrKMarsh_SidesMayEncloseMarsh() =>
        Assert.Equal("8", MrKMarsh.Solve(["...", ".x.", "..."]));

    [Theory]
    [InlineData(4, new[] { 1, 2, 3 }, "YES")]
    [InlineData(2, new[] { 1, 2, 3 }, "NO")]
    [InlineData(5, new[] { 4, 4, 2 }, "NO")]
    [InlineData(6, new[] { 4, 4, 2 }, "YES")]
    public void TheIndianJob_Samples(int g, int[] a, string expected) =>
        Assert.Equal(expected, TheIndianJob.Solve(g, a));

    [Theory]
    [InlineData(2, "tabriz", "torino", 4)]
    [InlineData(0, "abacba", "abcaba", 3)]
    [InlineData(3, "helloworld", "yellomarin", 8)]
    public void SubstringDiff_Samples(int k, string s1, string s2, int expected) =>
        Assert.Equal(expected, SubstringDiff.Solve(k, s1, s2));

    [Fact]
    public void SubstringDiff_MatchesBruteForce()
    {
        var random = new Random(61);
        for (int trial = 0; trial < 60; trial++)
        {
            int n = random.Next(1, 9);
            string s1 = new(Enumerable.Range(0, n).Select(_ => "ab"[random.Next(2)]).ToArray());
            string s2 = new(Enumerable.Range(0, n).Select(_ => "ab"[random.Next(2)]).ToArray());
            int k = random.Next(0, 3);

            int expected = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int length = 1; i + length <= n && j + length <= n; length++)
                        if (Enumerable.Range(0, length).Count(t => s1[i + t] != s2[j + t]) <= k)
                            expected = Math.Max(expected, length);

            Assert.Equal(expected, SubstringDiff.Solve(k, s1, s2));
        }
    }

    [Fact]
    public void GridWalking_Sample() =>
        Assert.Equal(12L, GridWalking.Solve(3, [1, 1], [2, 3]));

    [Fact]
    public void GridWalking_MatchesFullGridDp()
    {
        int[] x = [2, 1, 3];
        int[] d = [3, 2, 4];
        const int m = 6;

        var ways = new Dictionary<(int, int, int), long> { [(x[0], x[1], x[2])] = 1 };
        for (int step = 0; step < m; step++)
        {
            var next = new Dictionary<(int, int, int), long>();
            foreach (var ((a, b, c), count) in ways)
            {
                foreach (var (na, nb, nc) in new[] { (a + 1, b, c), (a - 1, b, c), (a, b + 1, c), (a, b - 1, c), (a, b, c + 1), (a, b, c - 1) })
                {
                    if (na >= 1 && na <= d[0] && nb >= 1 && nb <= d[1] && nc >= 1 && nc <= d[2])
                    {
                        next[(na, nb, nc)] = next.GetValueOrDefault((na, nb, nc)) + count;
                    }
                }
            }

            ways = next;
        }

        Assert.Equal(ways.Values.Sum(), GridWalking.Solve(m, x, d));
    }

    [Fact]
    public void TwoRobots_Sample() =>
        Assert.Equal(11L, TwoRobots.Solve([[1, 5], [3, 2], [4, 1], [2, 4]]));

    [Fact]
    public void TwoRobots_MatchesBruteForce()
    {
        var random = new Random(67);
        for (int trial = 0; trial < 100; trial++)
        {
            var jobs = Enumerable.Range(0, random.Next(1, 8)).Select(_ => new[] { random.Next(1, 20), random.Next(1, 20) }).ToArray();
            long expected = long.MaxValue;

            for (int mask = 0; mask < 1 << jobs.Length; mask++)
            {
                long total = 0;
                int?[] at = [null, null];
                for (int i = 0; i < jobs.Length; i++)
                {
                    int robot = (mask >> i) & 1;
                    total += (at[robot] is int p ? Math.Abs(p - jobs[i][0]) : 0) + Math.Abs(jobs[i][0] - jobs[i][1]);
                    at[robot] = jobs[i][1];
                }

                expected = Math.Min(expected, total);
            }

            Assert.Equal(expected, TwoRobots.Solve(jobs));
        }
    }

    [Theory]
    [InlineData(new[] { 1, 1, 1, 4 }, 5, 3, 3L)]
    [InlineData(new[] { 1, 2 }, 3, 2, 0L)]
    [InlineData(new[] { 1, 2, 3 }, 4, 0, 1L)]
    public void WetSharkAndTwoSubsequences_Samples(int[] x, int r, int s, long expected) =>
        Assert.Equal(expected, WetSharkAndTwoSubsequences.Solve(x, r, s));

    [Fact]
    public void WetSharkAndTwoSubsequences_MatchesBruteForce()
    {
        int[] x = [1, 2, 2, 3, 1, 4];
        const int r = 8, s = 2;
        var subsets = Enumerable.Range(1, (1 << x.Length) - 1)
            .Select(mask => (Length: System.Numerics.BitOperations.PopCount((uint)mask), Sum: x.Where((_, i) => (mask & (1 << i)) != 0).Sum()))
            .ToArray();

        long expected = subsets.Sum(a => subsets.LongCount(b => a.Length == b.Length && a.Sum + b.Sum == r && a.Sum - b.Sum == s));
        Assert.Equal(expected, WetSharkAndTwoSubsequences.Solve(x, r, s));
    }
}
