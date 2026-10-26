using HackerRank.Solutions.BitManipulation;

namespace HackerRank.Solutions.Tests;

public class BitManipulationTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 3, 2, 1 }, 4)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 0, 0, 1, 2, 1 }, 2)]
    public void LonelyInteger_Samples(int[] a, int expected) =>
        Assert.Equal(expected, LonelyInteger.Solve(a));

    [Theory]
    [InlineData(10, 15, 7)]
    [InlineData(11, 100, 127)]
    [InlineData(5, 5, 0)]
    [InlineData(5, 6, 3)]
    public void MaximizingXor_Samples(int l, int r, int expected) =>
        Assert.Equal(expected, MaximizingXor.Solve(l, r));

    [Theory]
    [InlineData(0L, 1L)]
    [InlineData(4L, 4L)]
    [InlineData(5L, 2L)]
    [InlineData(10L, 4L)]
    public void SumVsXor_Samples(long n, long expected) =>
        Assert.Equal(expected, SumVsXor.Solve(n));

    [Theory]
    [InlineData(2147483647L, 2147483648L)]
    [InlineData(1L, 4294967294L)]
    [InlineData(0L, 4294967295L)]
    public void FlippingBits_Samples(long n, long expected) =>
        Assert.Equal(expected, FlippingBits.Solve(n));

    [Theory]
    [InlineData(6L, "Richard")]
    [InlineData(132L, "Louise")]
    [InlineData(1L, "Richard")]
    public void CounterGame_Samples(long n, string expected) =>
        Assert.Equal(expected, CounterGame.Solve(n));

    [Theory]
    [InlineData(2L, 1L)]
    [InlineData(10L, 5L)]
    [InlineData(1L, 0L)]
    public void TheGreatXor_Samples(long x, long expected) =>
        Assert.Equal(expected, TheGreatXor.Solve(x));

    [Theory]
    [InlineData(new[] { 3, 4, 5 }, 6)]
    [InlineData(new[] { 98, 74, 12 }, 110)]
    [InlineData(new[] { 50, 13, 2 }, 48)]
    [InlineData(new[] { 1, 2, 3, 4 }, 0)]
    public void SansaAndXor_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, SansaAndXor.Solve(arr));

    [Theory]
    [InlineData(12L, 15L, 12L)]
    [InlineData(2L, 3L, 2L)]
    [InlineData(8L, 13L, 8L)]
    [InlineData(17L, 23L, 16L)]
    public void AndProduct_Samples(long a, long b, long expected) =>
        Assert.Equal(expected, AndProduct.Solve(a, b));
}
