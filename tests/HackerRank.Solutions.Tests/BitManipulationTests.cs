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

    [Theory]
    [InlineData(-2L, 0L, 63L)]
    [InlineData(-3L, 4L, 99L)]
    [InlineData(-1L, 4L, 37L)]
    [InlineData(-2_147_483_648L, -2_147_483_648L, 1L)]
    [InlineData(-2_147_483_648L, 2_147_483_647L, 68_719_476_736L)]
    public void TwosComplement_Samples(long a, long b, long expected) =>
        Assert.Equal(expected, TwosComplement.Solve(a, b));

    [Fact]
    public void XorAndSum_Sample() =>
        Assert.Equal(489_429_555L, XorAndSum.Solve("10", "1010"));

    [Fact]
    public void XorAndSum_MatchesBigInteger()
    {
        var random = new Random(139);
        for (int trial = 0; trial < 30; trial++)
        {
            string a = "1" + new string(Enumerable.Range(0, random.Next(0, 12)).Select(_ => "01"[random.Next(2)]).ToArray());
            string b = "1" + new string(Enumerable.Range(0, random.Next(0, 12)).Select(_ => "01"[random.Next(2)]).ToArray());
            int shifts = random.Next(0, 40);

            var valueA = a.Aggregate(System.Numerics.BigInteger.Zero, (v, c) => v * 2 + (c - '0'));
            var valueB = b.Aggregate(System.Numerics.BigInteger.Zero, (v, c) => v * 2 + (c - '0'));

            var expected = System.Numerics.BigInteger.Zero;
            for (int i = 0; i <= shifts; i++)
            {
                expected += valueA ^ (valueB << i);
            }

            Assert.Equal((long)(expected % 1_000_000_007), XorAndSum.Solve(a, b, shifts));
        }
    }

    [Fact]
    public void XorMatrix_Sample() =>
        Assert.Equal([1L, 6L, 2L, 5L], XorMatrix.Solve(2, [6, 7, 1, 3]));

    [Fact]
    public void XorMatrix_MatchesRowByRow()
    {
        long[] first = [3, 9, 27, 1, 8, 15, 0];
        var row = (long[])first.Clone();

        for (long m = 1; m <= 60; m++)
        {
            Assert.Equal(row, XorMatrix.Solve(m, first));
            row = row.Select((v, j) => v ^ row[(j + 1) % row.Length]).ToArray();
        }
    }

    [Fact]
    public void AOrB_Samples()
    {
        Assert.Equal(["8", "58"], AOrB.Solve(8, "2B", "9F", "58"));
        Assert.Equal(["18", "42"], AOrB.Solve(5, "B9", "40", "5A"));
        Assert.Equal(["-1"], AOrB.Solve(2, "91", "BE", "A8"));
    }

    [Fact]
    public void AOrB_MatchesBruteForce()
    {
        var random = new Random(149);
        for (int trial = 0; trial < 200; trial++)
        {
            int a = random.Next(16), b = random.Next(16), c = random.Next(16), k = random.Next(0, 6);
            string[] expected = ["-1"];

            for (int newA = 0; newA < 16 && expected[0] == "-1"; newA++)
            {
                for (int newB = 0; newB < 16; newB++)
                {
                    int changes = System.Numerics.BitOperations.PopCount((uint)(a ^ newA)) + System.Numerics.BitOperations.PopCount((uint)(b ^ newB));
                    if ((newA | newB) == c && changes <= k)
                    {
                        expected = [newA.ToString("X"), newB.ToString("X")];
                        break;
                    }
                }
            }

            Assert.Equal(expected, AOrB.Solve(k, a.ToString("X"), b.ToString("X"), c.ToString("X")));
        }
    }

    [Fact]
    public void ChangingBits_Sample() =>
        Assert.Equal("100", ChangingBits.Solve("00000", "11111", ["set_a 0 1", "get_c 5", "get_c 1", "set_b 2 0", "get_c 5"]));

    [Fact]
    public void ChangingBits_MatchesBigIntegerSum()
    {
        var random = new Random(197);
        const int n = 12;
        var a = Enumerable.Range(0, n).Select(_ => random.Next(2)).ToArray(); // index = bit position
        var b = Enumerable.Range(0, n).Select(_ => random.Next(2)).ToArray();
        string ToBinary(int[] bits) => string.Concat(bits.Reverse());

        string startA = ToBinary(a), startB = ToBinary(b);
        var queries = new List<string>();
        var expected = new System.Text.StringBuilder();

        for (int q = 0; q < 300; q++)
        {
            int kind = random.Next(3), index = random.Next(n);
            if (kind == 0) { int x = random.Next(2); queries.Add($"set_a {index} {x}"); a[index] = x; }
            else if (kind == 1) { int x = random.Next(2); queries.Add($"set_b {index} {x}"); b[index] = x; }
            else
            {
                int bit = random.Next(n + 1);
                queries.Add($"get_c {bit}");
                long sum = Convert.ToInt64(ToBinary(a), 2) + Convert.ToInt64(ToBinary(b), 2);
                expected.Append((sum >> bit) & 1);
            }
        }

        Assert.Equal(expected.ToString(), ChangingBits.Solve(startA, startB, queries));
    }

    [Fact]
    public void TwosComplement_MatchesPopCount()
    {
        for (long a = -40; a <= 40; a += 3)
        {
            for (long b = a; b <= 40; b += 5)
            {
                long expected = 0;
                for (long v = a; v <= b; v++)
                {
                    expected += System.Numerics.BitOperations.PopCount((uint)(int)v);
                }

                Assert.Equal(expected, TwosComplement.Solve(a, b));
            }
        }
    }
}
