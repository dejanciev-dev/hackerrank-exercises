namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Drawing Book — minimum page turns to reach page <c>p</c> in an <c>n</c>-page book, turning
/// from either the front or the back. Each turn reveals one more pair of pages.
/// https://www.hackerrank.com/challenges/drawing-book
/// </summary>
public static class DrawingBook
{
    public static int Solve(int n, int p)
    {
        int fromFront = p / 2;
        int fromBack = n / 2 - p / 2;

        return Math.Min(fromFront, fromBack);
    }
}
