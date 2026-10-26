using HackerRank.Solutions.Recursion;

namespace HackerRank.Solutions.Tests;

public class RecursionTests
{
    [Theory]
    [InlineData("148", 3, 3)]
    [InlineData("9875", 4, 8)]
    [InlineData("123", 3, 9)]
    public void RecursiveDigitSum_Samples(string n, int k, int expected) =>
        Assert.Equal(expected, RecursiveDigitSum.Solve(n, k));

    [Theory]
    [InlineData(10, 2, 1)]
    [InlineData(100, 2, 3)]
    [InlineData(100, 3, 1)]
    public void ThePowerSum_Samples(int x, int n, int expected) =>
        Assert.Equal(expected, ThePowerSum.Solve(x, n));
}
