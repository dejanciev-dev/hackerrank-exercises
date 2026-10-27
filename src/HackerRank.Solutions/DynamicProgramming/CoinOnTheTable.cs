namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Coin on the Table — a coin starts at the top-left and follows the arrows (U, D, L, R) one
/// cell per second; change as few arrows as possible so it lands on '*' within <c>k</c>
/// seconds. Search over (cell, time) states: following the arrow is free, and taking any
/// other direction costs one change. A 0-1 BFS gives the cheapest way to reach each state.
/// O(n · m · k).
/// https://www.hackerrank.com/challenges/coin-on-the-table
/// </summary>
public static class CoinOnTheTable
{
    private static readonly (char Arrow, int Dr, int Dc)[] Moves = [('U', -1, 0), ('D', 1, 0), ('L', 0, -1), ('R', 0, 1)];

    public static int Solve(int k, IReadOnlyList<string> board)
    {
        int rows = board.Count;
        int cols = board[0].Length;
        var cost = new int[rows, cols, k + 1];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                for (int t = 0; t <= k; t++)
                    cost[r, c, t] = int.MaxValue;

        var deque = new LinkedList<(int R, int C, int T)>();
        cost[0, 0, 0] = 0;
        deque.AddFirst((0, 0, 0));
        int best = int.MaxValue;

        while (deque.Count > 0)
        {
            var (r, c, t) = deque.First!.Value;
            deque.RemoveFirst();
            int here = cost[r, c, t];

            if (board[r][c] == '*')
            {
                best = Math.Min(best, here);
                continue;
            }

            if (t == k)
            {
                continue;
            }

            foreach (var (arrow, dr, dc) in Moves)
            {
                int nr = r + dr, nc = c + dc;
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                {
                    continue;
                }

                int step = board[r][c] == arrow ? 0 : 1;
                if (here + step < cost[nr, nc, t + 1])
                {
                    cost[nr, nc, t + 1] = here + step;
                    if (step == 0)
                    {
                        deque.AddFirst((nr, nc, t + 1));
                    }
                    else
                    {
                        deque.AddLast((nr, nc, t + 1));
                    }
                }
            }
        }

        return best == int.MaxValue ? -1 : best;
    }
}
