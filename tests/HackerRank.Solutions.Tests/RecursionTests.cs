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

    [Theory]
    [InlineData(new[] { "because", "can", "do", "must", "we", "what" }, "wedowhatwemustbecausewecan", "we do what we must because we can")]
    [InlineData(new[] { "hello", "planet" }, "helloworld", "WRONG PASSWORD")]
    [InlineData(new[] { "ab", "abcd", "cd" }, "abcd", "ab cd")]
    [InlineData(new[] { "ozkxyhkcst", "xvglh", "hpdnb", "zfzahm" }, "zfzahm", "zfzahm")]
    public void PasswordCracker_Samples(string[] passwords, string loginAttempt, string expected) =>
        Assert.Equal(expected, PasswordCracker.Solve(passwords, loginAttempt));

    [Fact]
    public void PasswordCracker_BacktracksFromGreedyChoice() =>
        Assert.Equal("ab cd", PasswordCracker.Solve(["abc", "ab", "cd"], "abcd"));

    [Fact]
    public void PasswordCracker_MemoizesDeadEnds() =>
        Assert.Equal("WRONG PASSWORD", PasswordCracker.Solve(["a", "aa", "aaa", "aaaa"], new string('a', 2000) + "b"));

    [Fact]
    public void CrosswordPuzzle_Sample()
    {
        string[] crossword =
        [
            "+-++++++++",
            "+-++++++++",
            "+-++++++++",
            "+-----++++",
            "+-+++-++++",
            "+-+++-++++",
            "+++++-++++",
            "++------++",
            "+++++-++++",
            "+++++-++++",
        ];

        string[] expected =
        [
            "+L++++++++",
            "+O++++++++",
            "+N++++++++",
            "+DELHI++++",
            "+O+++C++++",
            "+N+++E++++",
            "+++++L++++",
            "++ANKARA++",
            "+++++N++++",
            "+++++D++++",
        ];

        Assert.Equal(expected, CrosswordPuzzle.Solve(crossword, "LONDON;DELHI;ICELAND;ANKARA"));
    }

    [Fact]
    public void CrosswordPuzzle_BacktracksOnEqualLengthWords()
    {
        // ENGLAND and GWALIOR are both 7 letters, so the first placement tried can be wrong.
        string[] crossword =
        [
            "+-++++++++",
            "+-++++++++",
            "+-------++",
            "+-++++++++",
            "+-++++++++",
            "+------+++",
            "+-+++-++++",
            "+++++-++++",
            "+++++-++++",
            "++++++++++",
        ];

        string[] expected =
        [
            "+E++++++++",
            "+N++++++++",
            "+GWALIOR++",
            "+L++++++++",
            "+A++++++++",
            "+NORWAY+++",
            "+D+++G++++",
            "+++++R++++",
            "+++++A++++",
            "++++++++++",
        ];

        Assert.Equal(expected, CrosswordPuzzle.Solve(crossword, "AGRA;NORWAY;ENGLAND;GWALIOR"));
    }

    [Theory]
    [InlineData(0, 0L)]
    [InlineData(1, 1L)]
    [InlineData(3, 2L)]
    [InlineData(10, 55L)]
    [InlineData(90, 2880067194370816120L)]
    public void FibonacciNumbers_Samples(int n, long expected) =>
        Assert.Equal(expected, FibonacciNumbers.Solve(n));

    [Theory]
    [InlineData(1, 1L)]
    [InlineData(3, 4L)]
    [InlineData(5, 13L)]
    [InlineData(7, 44L)]
    public void DavisStaircase_Samples(int n, long expected) =>
        Assert.Equal(expected, DavisStaircase.Solve(n));

    [Theory]
    [InlineData(new[] { 3, 3, 3 }, 0)]
    [InlineData(new[] { 2, 2, 2, 2 }, 2)]
    [InlineData(new[] { 4, 1, 0, 1, 1, 0, 1 }, 3)]
    [InlineData(new[] { 0, 0, 0, 0 }, 3)]
    [InlineData(new[] { 5 }, 0)]
    public void NikitaAndTheGame_Samples(int[] arr, int expected) =>
        Assert.Equal(expected, NikitaAndTheGame.Solve(arr));

    [Theory]
    [InlineData(12L, new[] { 2L, 3L, 4L }, new[] { 1L, 3L, 12L })]
    [InlineData(15L, new[] { 2L, 10L, 6L, 9L, 11L }, new[] { -1L })]
    [InlineData(72L, new[] { 2L, 4L, 6L, 9L, 3L, 7L, 16L, 10L, 5L }, new[] { 1L, 2L, 8L, 72L })]
    [InlineData(1L, new[] { 2L }, new[] { 1L })]
    public void KFactorization_Samples(long n, long[] a, long[] expected) =>
        Assert.Equal(expected, KFactorization.Solve(n, a));

    [Theory]
    [InlineData(new[] { 22, 79, 21 })]
    [InlineData(new[] { 55, 3, 45, 33, 25 })]
    [InlineData(new[] { 101 })]
    [InlineData(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
    public void ArithmeticExpressions_ProducesAMultipleOf101(int[] arr)
    {
        string expression = ArithmeticExpressions.Solve(arr);

        var numbers = expression.Split('+', '-', '*').Select(int.Parse).ToArray();
        var ops = expression.Where(c => c is '+' or '-' or '*').ToArray();
        Assert.Equal(arr, numbers);

        long value = numbers[0];
        for (int i = 0; i < ops.Length; i++)
        {
            value = ops[i] switch
            {
                '+' => value + numbers[i + 1],
                '-' => value - numbers[i + 1],
                _ => value * numbers[i + 1],
            } % 101;
        }

        Assert.Equal(0, value % 101);
    }
}
