namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Chessboard Game, Again! — several coins on a 15x15 board (they may share squares); a move
/// takes one coin (-2, ±1) or (±1, -2). Each coin is its own game, so XOR the Grundy numbers
/// of the coins' squares, computed once by memoised search over the board.
/// https://www.hackerrank.com/challenges/chessboard-game-again-1
/// </summary>
public static class ChessboardGameAgain
{
    private const int Size = 15;
    private static readonly (int Dx, int Dy)[] Moves = [(-2, 1), (-2, -1), (1, -2), (-1, -2)];
    private static readonly int[,] Grundy = BuildGrundy();

    /// <param name="coins">Each coin as 1-based <c>[x, y]</c>.</param>
    public static string Solve(IReadOnlyList<IReadOnlyList<int>> coins)
    {
        int nimSum = 0;
        foreach (var coin in coins)
        {
            nimSum ^= Grundy[coin[0] - 1, coin[1] - 1];
        }

        return nimSum != 0 ? "First" : "Second";
    }

    private static int[,] BuildGrundy()
    {
        var grundy = new int[Size, Size];
        var done = new bool[Size, Size];

        int Compute(int x, int y)
        {
            if (done[x, y])
            {
                return grundy[x, y];
            }

            var reachable = new HashSet<int>();
            foreach (var (dx, dy) in Moves)
            {
                int nx = x + dx;
                int ny = y + dy;
                if (nx >= 0 && nx < Size && ny >= 0 && ny < Size)
                {
                    reachable.Add(Compute(nx, ny));
                }
            }

            int mex = 0;
            while (reachable.Contains(mex))
            {
                mex++;
            }

            done[x, y] = true;
            return grundy[x, y] = mex;
        }

        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                Compute(x, y);
            }
        }

        return grundy;
    }
}
