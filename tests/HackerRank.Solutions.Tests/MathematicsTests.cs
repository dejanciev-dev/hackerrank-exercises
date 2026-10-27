using HackerRank.Solutions.Mathematics;

namespace HackerRank.Solutions.Tests;

public class MathematicsTests
{
    [Theory]
    [InlineData(0, 0, 1, 1, new[] { 2, 2 })]
    [InlineData(1, 1, 2, 2, new[] { 3, 3 })]
    [InlineData(4, -3, 0, 0, new[] { -4, 3 })]
    public void FindThePoint_Samples(int px, int py, int qx, int qy, int[] expected) =>
        Assert.Equal(expected, FindThePoint.Solve(px, py, qx, qy));

    [Theory]
    [InlineData(5L, 6L)]
    [InlineData(6L, 9L)]
    [InlineData(7L, 12L)]
    [InlineData(8L, 16L)]
    [InlineData(10_000_000L, 25_000_000_000_000L)]
    public void HalloweenParty_Samples(long k, long expected) =>
        Assert.Equal(expected, HalloweenParty.Solve(k));

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    public void MaximumDraws_Samples(int n, int expected) =>
        Assert.Equal(expected, MaximumDraws.Solve(n));

    [Theory]
    [InlineData(1L, 0L)]
    [InlineData(2L, 1L)]
    [InlineData(1_000_000L, 499_999_500_000L)]
    public void Handshake_Samples(long n, long expected) =>
        Assert.Equal(expected, Handshake.Solve(n));

    [Theory]
    [InlineData(2, 2, 2)]
    [InlineData(17, 100, 12)]
    [InlineData(4, 6, 3)]
    public void MinimumHeightTriangle_Samples(int trianglebase, int area, int expected) =>
        Assert.Equal(expected, MinimumHeightTriangle.Solve(trianglebase, area));

    [Theory]
    [InlineData(2L, 2L, 1L)]
    [InlineData(1L, 1L, 1L)]
    [InlineData(3L, 3L, 4L)]
    public void ArmyGame_Samples(long n, long m, long expected) =>
        Assert.Equal(expected, ArmyGame.Solve(n, m));

    [Theory]
    [InlineData(new[] { 1, 3 }, 3L)]
    [InlineData(new[] { 2, 2, 2 }, 8L)]
    [InlineData(new[] { 1000, 1000, 1000 }, 1_000_000_000L % 1_234_567)]
    public void ConnectingTowns_Samples(int[] routes, long expected) =>
        Assert.Equal(expected, ConnectingTowns.Solve(routes));

    [Theory]
    [InlineData(1L, 0)]
    [InlineData(2L, 1)]
    [InlineData(3L, 1)]
    [InlineData(500L, 4)]
    [InlineData(5_000_000_000L, 9)]
    [InlineData(10_000_000_000L, 10)]
    [InlineData(1_000_000_000_000_000_000L, 15)]
    [InlineData(long.MaxValue, 15)]
    public void LeonardosPrimeFactors_Samples(long n, int expected) =>
        Assert.Equal(expected, LeonardosPrimeFactors.Solve(n));

    [Theory]
    [InlineData(1L, 1L)]
    [InlineData(2L, 4L)]
    [InlineData(1_000_000_008L, 1L)]
    public void SummingTheNSeries_Samples(long n, long expected) =>
        Assert.Equal(expected, SummingTheNSeries.Solve(n));

    [Theory]
    [InlineData(12, 6)]
    [InlineData(1, 1)]
    [InlineData(10, 5)]
    [InlineData(19, 19)]
    public void BestDivisor_Samples(int n, int expected) =>
        Assert.Equal(expected, BestDivisor.Solve(n));

    [Theory]
    [InlineData(2, 2, 1)]
    [InlineData(6, 9, 6)]
    [InlineData(7, 3, 21)]
    public void Restaurant_Samples(int l, int b, int expected) =>
        Assert.Equal(expected, Restaurant.Solve(l, b));

    [Fact]
    public void ReverseGame_MatchesSimulation()
    {
        for (int n = 1; n <= 30; n++)
        {
            var balls = Enumerable.Range(0, n).ToArray();
            for (int start = 0; start < n; start++)
            {
                Array.Reverse(balls, start, n - start);
            }

            for (int k = 0; k < n; k++)
            {
                Assert.Equal(Array.IndexOf(balls, k), ReverseGame.Solve(n, k));
            }
        }
    }

    [Theory]
    [InlineData(1, "9")]
    [InlineData(2, "90")]
    [InlineData(5, "90")]
    [InlineData(7, "9009")]
    [InlineData(11, "99")]
    public void SpecialMultiple_Samples(int n, string expected) =>
        Assert.Equal(expected, SpecialMultiple.Solve(n));

    [Fact]
    public void SpecialMultiple_IsAMultipleOfOnlyNinesAndZeros()
    {
        for (int n = 1; n <= 500; n++)
        {
            string multiple = SpecialMultiple.Solve(n);
            Assert.All(multiple, digit => Assert.Contains(digit, "09"));
            Assert.Equal(0, System.Numerics.BigInteger.Parse(multiple) % n);
        }
    }

    [Theory]
    [InlineData(5L, "IsFibo")]
    [InlineData(7L, "IsNotFibo")]
    [InlineData(8L, "IsFibo")]
    [InlineData(1L, "IsFibo")]
    [InlineData(7_778_742_049L, "IsFibo")]
    [InlineData(10_000_000_000L, "IsNotFibo")]
    public void IsFibo_Samples(long n, string expected) =>
        Assert.Equal(expected, IsFibo.Solve(n));

    [Theory]
    [InlineData(1L, 1L)]
    [InlineData(2L, 3L)]
    [InlineData(20L, 48_575L)]
    public void DiwaliLights_Samples(long n, long expected) =>
        Assert.Equal(expected, DiwaliLights.Solve(n));

    [Theory]
    [InlineData(1L, 1L, 2L, 3L, "YES")]
    [InlineData(1L, 2L, 3L, 4L, "YES")]
    [InlineData(2L, 2L, 3L, 3L, "NO")]
    public void PossiblePath_Samples(long a, long b, long x, long y, string expected) =>
        Assert.Equal(expected, PossiblePath.Solve(a, b, x, y));

    [Theory]
    [InlineData(9, 0)]
    [InlineData(8, 3)]
    [InlineData(2, 1)]
    [InlineData(36, 6)]
    public void SherlockAndDivisors_Samples(int n, int expected) =>
        Assert.Equal(expected, SherlockAndDivisors.Solve(n));

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, "Yes")]
    [InlineData(new[] { 100, 1 }, "No")]
    [InlineData(new[] { 9 }, "Yes")]
    public void ConstructingANumber_Samples(int[] a, string expected) =>
        Assert.Equal(expected, ConstructingANumber.Solve(a));

    [Theory]
    [InlineData(2L, 3L, 1L, 3L)]
    [InlineData(9L, 1L, 7L, 85L)]
    [InlineData(9L, 8L, 3L, 25L)]
    [InlineData(4L, 5L, 0L, 4L)]
    public void FibonacciFinding_Samples(long a, long b, long n, long expected) =>
        Assert.Equal(expected, FibonacciFinding.Solve(a, b, n));

    [Fact]
    public void FibonacciFinding_MatchesIteration()
    {
        const long mod = 1_000_000_007;
        long previous = 7;
        long current = 11;

        for (long n = 1; n <= 300; n++)
        {
            Assert.Equal(current, FibonacciFinding.Solve(7, 11, n));
            (previous, current) = (current, (previous + current) % mod);
        }
    }

    [Theory]
    [InlineData(3L, 1L, 2L)]
    [InlineData(1L, 1L, 0L)]
    [InlineData(1_000_000_000L, 1_000_000_000L, 999_999_999_999_999_999L)]
    public void CuttingPaperSquares_Samples(long n, long m, long expected) =>
        Assert.Equal(expected, CuttingPaperSquares.Solve(n, m));

    [Fact]
    public void FillingJars_Sample() =>
        Assert.Equal(160L, FillingJars.Solve(5, [[1, 2, 100], [2, 5, 100], [3, 4, 100]]));

    [Fact]
    public void FillingJars_DoesNotOverflow() =>
        Assert.Equal(1_000_000L, FillingJars.Solve(10_000_000, [[1, 10_000_000, 1_000_000]]));

    [Theory]
    [InlineData(6L, 3L, 25L)]
    [InlineData(1L, 1L, 0L)]
    [InlineData(2L, 1L, 1L)]
    [InlineData(3L, 5L, 18L)]
    [InlineData(2_000_000_000L, 5L, 9_999_999_999L)]
    public void StrangeGrid_Samples(long r, long c, long expected) =>
        Assert.Equal(expected, StrangeGrid.Solve(r, c));

    [Fact]
    public void MostDistant_Samples()
    {
        Assert.Equal(2.0, MostDistant.Solve([[-1, 0], [1, 0], [0, 1], [0, -1]]), 9);
        Assert.Equal(5.0, MostDistant.Solve([[0, 3], [4, 0]]), 9);
    }

    [Fact]
    public void MostDistant_MatchesBruteForce()
    {
        var random = new Random(3);
        for (int trial = 0; trial < 200; trial++)
        {
            var points = Enumerable.Range(0, random.Next(2, 8))
                .Select(_ => random.Next(2) == 0 ? new[] { random.Next(-50, 51), 0 } : new[] { 0, random.Next(-50, 51) })
                .ToArray();

            double expected = points.SelectMany(p => points.Select(q => Math.Sqrt(Math.Pow(p[0] - q[0], 2) + Math.Pow(p[1] - q[1], 2)))).Max();
            Assert.Equal(expected, MostDistant.Solve(points), 9);
        }
    }

    [Fact]
    public void BusStation_Sample() =>
        Assert.Equal([3L, 4L, 6L, 12L], BusStation.Solve([1, 2, 1, 1, 1, 2, 1, 3]));

    [Fact]
    public void BusStation_MatchesBruteForce()
    {
        int[] groups = [2, 2, 1, 3, 1, 1, 2, 4];
        long total = groups.Sum();
        var expected = new List<long>();

        for (long x = 1; x <= total; x++)
        {
            long load = 0;
            bool ok = true;
            foreach (var g in groups)
            {
                load += g;
                if (load == x) load = 0;
                else if (load > x) ok = false;
            }

            if (ok && load == 0)
            {
                expected.Add(x);
            }
        }

        Assert.Equal(expected, BusStation.Solve(groups));
    }

    [Theory]
    [InlineData(1, 1, 1L)]
    [InlineData(2, 3, 6L)]
    [InlineData(0, 4, 1L)]
    public void SherlockAndPermutations_Samples(int n, int m, long expected) =>
        Assert.Equal(expected, SherlockAndPermutations.Solve(n, m));

    [Theory]
    [InlineData(2, 2, 2L)]
    [InlineData(3, 3, 6L)]
    [InlineData(1, 5, 1L)]
    [InlineData(4, 5, 35L)]
    public void MatrixTracing_Samples(int m, int n, long expected) =>
        Assert.Equal(expected, MatrixTracing.Solve(m, n));

    [Fact]
    public void NcrTable_SmallRows()
    {
        Assert.Equal([1L, 2L, 1L], NcrTable.Solve(2));
        Assert.Equal([1L, 4L, 6L, 4L, 1L], NcrTable.Solve(4));
    }

    [Fact]
    public void NcrTable_MatchesBigInteger()
    {
        var row = NcrTable.Solve(1000);
        var exact = System.Numerics.BigInteger.One;

        for (int k = 0; k <= 1000; k++)
        {
            Assert.Equal((long)(exact % 1_000_000_000), row[k]);
            exact = exact * (1000 - k) / (k + 1);
        }
    }

    [Theory]
    [InlineData(4, 1, 4L)]
    [InlineData(2, 3, 4L)]
    [InlineData(10, 3, 220L)]
    public void KCandyStore_Samples(int n, int k, long expected) =>
        Assert.Equal(expected, KCandyStore.Solve(n, k));

    [Theory]
    [InlineData(new[] { 1, 2 }, 1L)]
    [InlineData(new[] { 1, 2, 3 }, 3L)]
    [InlineData(new[] { 2, 4 }, 3L)]
    [InlineData(new[] { 1 }, 0L)]
    public void ChocolateFiesta_Samples(int[] a, long expected) =>
        Assert.Equal(expected, ChocolateFiesta.Solve(a));

    [Theory]
    [InlineData(1L, 2L, 3L, 1L)]
    [InlineData(3L, 4L, 2L, 1L)]
    [InlineData(4L, -1L, 5L, 4L)]
    [InlineData(2L, 10L, 1000L, 24L)]
    public void LittlePandaPower_Samples(long a, long b, long x, long expected) =>
        Assert.Equal(expected, LittlePandaPower.Solve(a, b, x));

    [Fact]
    public void LittlePandaPower_NegativeExponentInvertsPositive()
    {
        for (long x = 2; x < 60; x++)
        {
            for (long a = 1; a < x; a++)
            {
                if (System.Numerics.BigInteger.GreatestCommonDivisor(a, x) != 1)
                {
                    continue;
                }

                long inverse = LittlePandaPower.Solve(a, -3, x);
                Assert.Equal(1 % x, inverse * LittlePandaPower.Solve(a, 3, x) % x);
            }
        }
    }

    [Theory]
    [InlineData(5L, 7L, "NO")]
    [InlineData(4L, 7L, "YES")]
    [InlineData(0L, 7L, "YES")]
    [InlineData(1L, 2L, "YES")]
    public void EulersCriterion_Samples(long a, long m, string expected) =>
        Assert.Equal(expected, EulersCriterion.Solve(a, m));

    [Fact]
    public void EulersCriterion_MatchesSquaresModP()
    {
        foreach (long p in new long[] { 3, 5, 7, 11, 13, 101 })
        {
            var squares = Enumerable.Range(0, (int)p).Select(x => (long)x * x % p).ToHashSet();
            for (long a = 0; a < p; a++)
            {
                Assert.Equal(squares.Contains(a) ? "YES" : "NO", EulersCriterion.Solve(a, p));
            }
        }
    }

    [Theory]
    [InlineData(7L, new[] { 3L, 2L })]
    [InlineData(13L, new[] { 2L, 4L })]
    [InlineData(23L, new[] { 5L, 10L })]
    public void PrimitiveProblem_Samples(long p, long[] expected) =>
        Assert.Equal(expected, PrimitiveProblem.Solve(p));

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1L, 2L, 6L, 3L })]
    [InlineData(new[] { 5, 10 }, new[] { 5L, 10L, 10L })]
    public void JohnAndGcdList_Samples(int[] a, long[] expected) =>
        Assert.Equal(expected, JohnAndGcdList.Solve(a));

    [Theory]
    [InlineData(5L, new[] { 2L, 6L, 4L }, 4L)]
    [InlineData(10L, new[] { 15L, 45L }, 10L)]
    [InlineData(20L, new[] { 7L, 14L }, 14L)]
    public void EasyGcd_Samples(long k, long[] a, long expected) =>
        Assert.Equal(expected, EasyGcd.Solve(k, a));

    [Fact]
    public void PointsOnALine_Samples()
    {
        Assert.Equal("YES", PointsOnALine.Solve([[1, 1], [2, 1], [3, 1]]));
        Assert.Equal("YES", PointsOnALine.Solve([[4, 1], [4, -2], [4, 9]]));
        Assert.Equal("NO", PointsOnALine.Solve([[1, 1], [2, 2]]));
    }

    [Fact]
    public void PolarAngles_SortsByAngleThenDistance()
    {
        int[][] expected = [[1, 0], [1, 1], [2, 2], [0, 1], [-1, 0], [0, -1], [3, -1]];
        Assert.Equal(expected, PolarAngles.Solve([[0, -1], [2, 2], [-1, 0], [3, -1], [0, 1], [1, 1], [1, 0]]));
    }

    [Fact]
    public void TriangleNumbers_MatchesBuiltTriangle()
    {
        var row = new[] { 1 };
        for (int n = 1; n <= 80; n++)
        {
            int index = Array.FindIndex(row, v => v % 2 == 0);
            Assert.Equal(index < 0 ? -1 : index + 1, TriangleNumbers.Solve(n));

            var next = new int[row.Length + 2];
            for (int j = 0; j < next.Length; j++)
            {
                int Above(int i) => i >= 0 && i < row.Length ? row[i] : 0;
                next[j] = (Above(j - 2) + Above(j - 1) + Above(j)) % 2;
            }

            row = next;
        }
    }

    [Theory]
    [InlineData(2L, 0L, 9L, 1000L, new[] { 512L, 0L })]
    [InlineData(0L, 1L, 5L, 10L, new[] { 0L, 1L })]
    [InlineData(8L, 2L, 10L, 1_000_000_000L, new[] { 880_332_800L, 927_506_432L })]
    public void RussianPeasantExponentiation_Samples(long a, long b, long k, long m, long[] expected) =>
        Assert.Equal(expected, RussianPeasantExponentiation.Solve(a, b, k, m));

    [Fact]
    public void RussianPeasantExponentiation_MatchesRepeatedMultiplication()
    {
        const long m = 999_999_937;
        long re = 1, im = 0;

        for (long k = 1; k <= 200; k++)
        {
            (re, im) = ((re * 12345 - im * 6789 % m + m) % m, (re * 6789 + im * 12345) % m);
            Assert.Equal([re, im], RussianPeasantExponentiation.Solve(12345, 6789, k, m));
        }
    }

    [Theory]
    [InlineData(378, 1)]
    [InlineData(4, 1)]
    [InlineData(22, 1)]
    [InlineData(4_937_775, 1)]
    [InlineData(10, 0)]
    [InlineData(7, 0)]
    public void SmithNumbers_Samples(int n, int expected) =>
        Assert.Equal(expected, SmithNumbers.Solve(n));

    [Theory]
    [InlineData(12L, "Not prime")]
    [InlineData(5L, "Prime")]
    [InlineData(7L, "Prime")]
    [InlineData(1L, "Not prime")]
    [InlineData(2L, "Prime")]
    [InlineData(1_000_000_007L, "Prime")]
    [InlineData(999_999_999_989L, "Prime")]
    [InlineData(1_000_000_007L * 3, "Not prime")]
    public void Primality_Samples(long n, string expected) =>
        Assert.Equal(expected, Primality.Solve(n));

    [Theory]
    [InlineData(new[] { 1L, 2L, 3L }, "YES")]
    [InlineData(new[] { 2L, 4L }, "NO")]
    [InlineData(new[] { 6L, 10L, 15L }, "YES")]
    public void SherlockAndGcd_Samples(long[] a, string expected) =>
        Assert.Equal(expected, SherlockAndGcd.Solve(a));

    [Fact]
    public void LuckyNumberEight_Sample() =>
        Assert.Equal(3L, LuckyNumberEight.Solve("968"));

    [Fact]
    public void LuckyNumberEight_MatchesBruteForce()
    {
        var random = new Random(79);
        for (int trial = 0; trial < 40; trial++)
        {
            string number = new(Enumerable.Range(0, random.Next(1, 12)).Select(_ => (char)('0' + random.Next(10))).ToArray());
            long expected = 0;
            for (int mask = 1; mask < 1 << number.Length; mask++)
            {
                var digits = number.Where((_, i) => (mask & (1 << i)) != 0);
                if (System.Numerics.BigInteger.Parse(string.Concat(digits)) % 8 == 0)
                {
                    expected++;
                }
            }

            Assert.Equal(expected, LuckyNumberEight.Solve(number));
        }
    }

    [Theory]
    [InlineData("61", "YES")]
    [InlineData("75", "NO")]
    [InlineData("8", "YES")]
    [InlineData("123", "YES")]
    [InlineData("1111", "NO")]
    public void ManasaLovesMaths_Samples(string n, string expected) =>
        Assert.Equal(expected, ManasaLovesMaths.Solve(n));

    [Fact]
    public void ManasaLovesMaths_MatchesPermutationSearch()
    {
        for (int value = 1; value < 20_000; value += 7)
        {
            string digits = value.ToString();
            bool expected = Permute(digits).Any(p => long.Parse(p) % 8 == 0);
            Assert.Equal(expected ? "YES" : "NO", ManasaLovesMaths.Solve(digits));
        }

        static IEnumerable<string> Permute(string s) => s.Length <= 1
            ? [s]
            : Enumerable.Range(0, s.Length).SelectMany(i => Permute(s.Remove(i, 1)).Select(rest => s[i] + rest));
    }

    [Fact]
    public void TheChosenOne_DividesAllButExactlyOne()
    {
        long[][] cases = [[2, 3], [6, 6, 4], [7], [12, 18, 24, 5], [4, 8, 16, 32, 33]];
        foreach (var a in cases)
        {
            long x = TheChosenOne.Solve(a);
            Assert.Equal(1, a.Count(v => v % x != 0));
        }
    }

    [Theory]
    [InlineData(0L, 2L, 4L, 0L, 1L)]
    [InlineData(2L, 2L, 5L, 5L, 2L)]
    [InlineData(1L, 9L, 8L, 16L, 6L)]
    [InlineData(0L, 0L, 0L, 7L, 6L)]
    public void SumarAndTheFloatingRocks_Samples(long x1, long y1, long x2, long y2, long expected) =>
        Assert.Equal(expected, SumarAndTheFloatingRocks.Solve(x1, y1, x2, y2));

    [Theory]
    [InlineData(2, 2, 2L)]
    [InlineData(3, 2, 4L)]
    [InlineData(3, 3, 24L)]
    [InlineData(1, 5, 1L)]
    public void SuperHumbleMatrix_Samples(int n, int m, long expected) =>
        Assert.Equal(expected, SuperHumbleMatrix.Solve(n, m));

    [Theory]
    [InlineData(2L, 1L, 2, 1L)]
    [InlineData(2L, 1L, 5, 3L)]
    [InlineData(5L, 2L, 3, 2L)]
    public void AjobSubsequence_Samples(long n, long k, int p, long expected) =>
        Assert.Equal(expected, AjobSubsequence.Solve(n, k, p));

    [Fact]
    public void AjobSubsequence_MatchesBigInteger()
    {
        var random = new Random(131);
        foreach (int p in new[] { 2, 3, 5, 7, 13, 101 })
        {
            for (int trial = 0; trial < 30; trial++)
            {
                long n = random.Next(0, 400);
                long k = random.Next(0, (int)n + 1);
                var binomial = System.Numerics.BigInteger.One;
                for (long i = 0; i < k + 1; i++)
                {
                    binomial = binomial * (n + 1 - i) / (i + 1);
                }

                Assert.Equal((long)(binomial % p), AjobSubsequence.Solve(n, k, p));
            }
        }
    }

    [Theory]
    [InlineData(1L, 100L, 8L)]
    [InlineData(1L, 1L, 0L)]
    [InlineData(2L, 7L, 4L)]
    public void MegaprimeNumbers_Samples(long first, long last, long expected) =>
        Assert.Equal(expected, MegaprimeNumbers.Solve(first, last));

    [Fact]
    public void MegaprimeNumbers_MatchesTrialDivision()
    {
        static bool IsPrime(long v) => v >= 2 && Enumerable.Range(2, (int)Math.Sqrt(v) - 1).All(d => v % d != 0);
        long expected = Enumerable.Range(1, 50_000)
            .Count(v => v.ToString().All(c => c is '2' or '3' or '5' or '7') && IsPrime(v));

        Assert.Equal(expected, MegaprimeNumbers.Solve(1, 50_000));
        Assert.Equal(expected - 4, MegaprimeNumbers.Solve(8, 50_000));
    }

    [Fact]
    public void JimAndTheJokes_Samples()
    {
        Assert.Equal(1L, JimAndTheJokes.Solve([[10, 25], [8, 31]]));
        Assert.Equal(0L, JimAndTheJokes.Solve([[2, 25], [2, 25]]));
        Assert.Equal(1L, JimAndTheJokes.Solve([[11, 10], [10, 11]]));
        Assert.Equal(3L, JimAndTheJokes.Solve([[10, 7], [8, 7], [12, 7]]));
    }

    [Theory]
    [InlineData(1, 1L)]
    [InlineData(2, 3L)]
    [InlineData(3, 9L)]
    [InlineData(32327, 656502L)]
    public void Equations_Samples(int n, long expected) =>
        Assert.Equal(expected, Equations.Solve(n));

    [Fact]
    public void SalaryBlues_MatchesBruteForce()
    {
        var random = new Random(137);
        var a = Enumerable.Range(0, 6).Select(_ => (long)random.Next(1, 1000) * 6).ToArray();
        var queries = Enumerable.Range(0, 20).Select(_ => (long)random.Next(0, 100)).ToArray();
        var expected = queries.Select(k => a.Aggregate(0L, (g, v) => (long)System.Numerics.BigInteger.GreatestCommonDivisor(g, v + k))).ToArray();

        Assert.Equal(expected, SalaryBlues.Solve(a, queries));
    }

    [Theory]
    [InlineData(1L, 1L)]
    [InlineData(2L, 8L)]
    [InlineData(3L, 27L)]
    public void NumberGroups_Samples(long k, long expected) =>
        Assert.Equal(expected, NumberGroups.Solve(k));

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 4.333333)]
    [InlineData(new[] { 3, 3, 3 }, 3.0)]
    [InlineData(new[] { 2, 2, 3 }, 4.0)]
    [InlineData(new[] { 10, 2, 4, 4 }, 6.0)]
    [InlineData(new[] { 10, 10, 10, 5, 10 }, 5.8)]
    public void VerticalSticks_Samples(int[] y, double expected) =>
        Assert.Equal(expected, VerticalSticks.Solve(y), 5);

    [Fact]
    public void VerticalSticks_MatchesAllOrderings()
    {
        int[] y = [1, 1, 2, 3];
        var orders = Permutations(Enumerable.Range(0, y.Length).ToArray()).ToArray();
        double total = 0;

        foreach (var order in orders)
        {
            for (int i = 0; i < order.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && y[order[j]] < y[order[i]]) j--;
                total += i - j;
            }
        }

        Assert.Equal(total / orders.Length, VerticalSticks.Solve(y), 9);

        static IEnumerable<int[]> Permutations(int[] items) => items.Length <= 1
            ? [items]
            : items.SelectMany((x, i) => Permutations(items.Where((_, j) => j != i).ToArray()).Select(rest => new[] { x }.Concat(rest).ToArray()));
    }

    [Theory]
    [InlineData(new[] { 2L, 3L, 5L }, 1L)]
    [InlineData(new[] { 3L, 6L, 9L }, 2L)]
    [InlineData(new[] { 12L, 24L }, 144L)]
    public void FibonacciGcd_Samples(long[] a, long expected) =>
        Assert.Equal(expected, FibonacciGcd.Solve(a));

    [Theory]
    [InlineData(new[] { 1, 1, 2 }, 1L)]
    [InlineData(new[] { 1, 2 }, 2L)]
    [InlineData(new[] { 1, 2, 2, 1 }, 2L)]
    public void TarasBeautifulPermutations_Samples(int[] a, long expected) =>
        Assert.Equal(expected, TarasBeautifulPermutations.Solve(a));

    [Fact]
    public void TarasBeautifulPermutations_MatchesEnumeration()
    {
        int[][] cases = [[1, 1, 2, 2, 3, 3], [1, 2, 3, 1, 4], [5, 5, 6, 6, 7, 8, 9]];
        foreach (var a in cases)
        {
            var arrangements = new HashSet<string>();
            void Permute(List<int> prefix, List<int> rest)
            {
                if (rest.Count == 0)
                {
                    arrangements.Add(string.Join(',', prefix));
                    return;
                }

                for (int i = 0; i < rest.Count; i++)
                {
                    if (prefix.Count > 0 && prefix[^1] == rest[i]) continue;
                    var next = new List<int>(rest);
                    next.RemoveAt(i);
                    Permute([.. prefix, rest[i]], next);
                }
            }

            Permute([], a.ToList());
            Assert.Equal(arrangements.Count, TarasBeautifulPermutations.Solve(a));
        }
    }

    [Fact]
    public void SherlockAndMovingTiles_Sample()
    {
        var times = SherlockAndMovingTiles.Solve(10, 1, 2, [50, 100]);
        Assert.Equal(4.1421, times[0], 4);
        Assert.Equal(0.0, times[1], 4);
    }

    [Theory]
    [InlineData(2L, 3L, 1L, 2L)]
    [InlineData(1L, 2L, 0L, 0L)]
    [InlineData(3L, 4L, 11L, 3L)]
    [InlineData(1L, 5L, 5L, 1L)]
    [InlineData(1L, 5L, 10L, 2L)]
    public void BabyStepGiantStep_Samples(long a, long b, long d, long expected) =>
        Assert.Equal(expected, BabyStepGiantStep.Solve(a, b, d));

    [Fact]
    public void LittleAshish_MatchesRunningSum()
    {
        foreach (long x in new long[] { 1, 6, 7, 14, 1_000, 123_456_789, 10_000_000_000_000_000 })
        {
            long days = 0, total = 0;
            while (total + (days + 1) * (days + 1) <= x)
            {
                days++;
                total += days * days;
            }

            Assert.Equal(days, LittleAshish.Solve(x));
        }
    }

    [Fact]
    public void CountSolutions_MatchesBruteForce()
    {
        Assert.Equal(1L, CountSolutions.Solve(1, 1, 1, 1));

        var random = new Random(191);
        for (int trial = 0; trial < 40; trial++)
        {
            long a = random.Next(1, 40), b = random.Next(1, 40), c = random.Next(1, 40), d = random.Next(1, 40);
            long expected = 0;
            for (long x = 1; x <= c; x++)
                for (long y = 1; y <= d; y++)
                    if (x * x + y * y == x * a + y * b)
                        expected++;

            Assert.Equal(expected, CountSolutions.Solve(a, b, c, d));
        }
    }

    [Fact]
    public void ManasaAndSubSequences_Samples()
    {
        Assert.Equal(147L, ManasaAndSubSequences.Solve("111"));

        const string number = "90210473";
        long expected = 0;
        for (int mask = 1; mask < 1 << number.Length; mask++)
        {
            expected += long.Parse(string.Concat(number.Where((_, i) => (mask & (1 << i)) != 0)));
        }

        Assert.Equal(expected % 1_000_000_007, ManasaAndSubSequences.Solve(number));
    }

    [Fact]
    public void WetSharkAnd42_MatchesWalk()
    {
        Assert.Equal(6L, WetSharkAnd42.Solve(3));
        Assert.Equal(8L, WetSharkAnd42.Solve(4));

        for (long s = 1; s <= 200; s++)
        {
            long strength = s, square = 0;
            while (strength > 0)
            {
                square++;
                if (square % 2 == 0 && square % 42 != 0)
                {
                    strength--;
                }
            }

            Assert.Equal(square, WetSharkAnd42.Solve(s));
        }
    }

    [Fact]
    public void EvenOddQuery_Samples()
    {
        Assert.Equal(["Odd", "Even"], EvenOddQuery.Solve([3, 2, 7], [[1, 2], [2, 3]]));
        Assert.Equal(["Odd", "Even", "Odd"], EvenOddQuery.Solve([2, 0, 5], [[1, 2], [1, 1], [3, 2]]));
    }
}
