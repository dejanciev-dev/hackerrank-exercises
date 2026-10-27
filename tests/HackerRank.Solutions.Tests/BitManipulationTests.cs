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

    [Theory]
    [InlineData(2L, 4L, 7L)]
    [InlineData(2L, 8L, 9L)]
    [InlineData(5L, 9L, 15L)]
    [InlineData(3L, 5L, 5L)]
    [InlineData(0L, 0L, 0L)]
    public void XorSequence_Samples(long l, long r, long expected) =>
        Assert.Equal(expected, XorSequence.Solve(l, r));

    [Fact]
    public void XorSequence_MatchesBruteForce()
    {
        var a = new long[64];
        for (int i = 1; i < a.Length; i++)
        {
            a[i] = a[i - 1] ^ i;
        }

        for (int l = 0; l < a.Length; l++)
        {
            long expected = 0;
            for (int r = l; r < a.Length; r++)
            {
                expected ^= a[r];
                Assert.Equal(expected, XorSequence.Solve(l, r));
            }
        }
    }

    [Theory]
    [InlineData(7, 4, "1110100110", "1001010")]
    [InlineData(6, 2, "1110001", "101111")]
    [InlineData(1, 1, "1", "1")]
    public void Cipher_Samples(int n, int k, string s, string expected) =>
        Assert.Equal(expected, Cipher.Solve(n, k, s));

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, 5)]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    [InlineData(new[] { 7, 7, 7 }, 0)]
    public void YetAnotherMinimax_Samples(int[] a, int expected) =>
        Assert.Equal(expected, YetAnotherMinimax.Solve(a));

    [Fact]
    public void WinningLotteryTicket_Sample() =>
        Assert.Equal(5L, WinningLotteryTicket.Solve(["129300455", "5559948277", "012334556", "56789", "123456879"]));

    [Fact]
    public void WinningLotteryTicket_PairsCompleteTicketsWithEachOther() =>
        Assert.Equal(3L, WinningLotteryTicket.Solve(["0123456789", "9876543210", "1023456789"]));

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 12L)]
    [InlineData(new[] { 1, 2 }, 6L)]
    [InlineData(new[] { 5 }, 5L)]
    public void XoringNinja_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, XoringNinja.Solve(arr));

    [Fact]
    public void XoringNinja_MatchesBruteForce()
    {
        int[] arr = [7, 12, 3, 0, 9, 21, 5];
        long expected = 0;
        for (int mask = 1; mask < 1 << arr.Length; mask++)
        {
            int xor = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    xor ^= arr[i];
                }
            }

            expected += xor;
        }

        Assert.Equal(expected, XoringNinja.Solve(arr));
    }
}
