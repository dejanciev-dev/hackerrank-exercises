namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Forming a Magic Square — minimum total cost (|old - new| per cell) to turn a 3×3 grid into a
/// magic square. There are only 8 magic squares of order 3 (rotations and reflections of one),
/// so compare against each of them.
/// https://www.hackerrank.com/challenges/magic-square-forming
/// </summary>
public static class FormingAMagicSquare
{
    private static readonly int[][] MagicSquares =
    [
        [8, 1, 6, 3, 5, 7, 4, 9, 2],
        [6, 1, 8, 7, 5, 3, 2, 9, 4],
        [4, 9, 2, 3, 5, 7, 8, 1, 6],
        [2, 9, 4, 7, 5, 3, 6, 1, 8],
        [8, 3, 4, 1, 5, 9, 6, 7, 2],
        [4, 3, 8, 9, 5, 1, 2, 7, 6],
        [6, 7, 2, 1, 5, 9, 8, 3, 4],
        [2, 7, 6, 9, 5, 1, 4, 3, 8],
    ];

    public static int Solve(IReadOnlyList<IReadOnlyList<int>> s)
    {
        var flat = s.SelectMany(row => row).ToArray();

        return MagicSquares.Min(magic => magic.Zip(flat, (m, v) => Math.Abs(m - v)).Sum());
    }
}
