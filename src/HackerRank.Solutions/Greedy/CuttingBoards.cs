namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Cutting Boards — cut a board into 1x1 squares at minimum cost, where each cut costs its
/// line cost times the number of pieces it crosses; modulo 1e9+7. Expensive cuts should cross
/// as few pieces as possible, so always make the most expensive remaining cut next.
/// O(m log m + n log n).
/// https://www.hackerrank.com/challenges/board-cutting
/// </summary>
public static class CuttingBoards
{
    private const long Mod = 1_000_000_007;

    public static long Solve(IReadOnlyList<long> costY, IReadOnlyList<long> costX)
    {
        var rows = costY.OrderDescending().ToArray();
        var columns = costX.OrderDescending().ToArray();

        // A row cut crosses every column piece, and a column cut crosses every row piece.
        long rowPieces = 1;
        long columnPieces = 1;
        long total = 0;
        int r = 0;
        int c = 0;

        while (r < rows.Length || c < columns.Length)
        {
            if (c == columns.Length || (r < rows.Length && rows[r] >= columns[c]))
            {
                total = (total + rows[r++] % Mod * columnPieces) % Mod;
                rowPieces++;
            }
            else
            {
                total = (total + columns[c++] % Mod * rowPieces) % Mod;
                columnPieces++;
            }
        }

        return total;
    }
}
