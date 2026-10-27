namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Cutting Paper Squares — fewest cuts to split an n x m sheet into 1x1 squares. Every cut
/// turns one piece into two, and we need n · m pieces, so n · m - 1 cuts whatever the order.
/// https://www.hackerrank.com/challenges/p1-paper-cutting
/// </summary>
public static class CuttingPaperSquares
{
    public static long Solve(long n, long m) => n * m - 1;
}
