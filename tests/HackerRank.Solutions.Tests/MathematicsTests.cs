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
}
