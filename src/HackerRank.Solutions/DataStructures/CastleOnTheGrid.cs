namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Castle on the Grid — fewest moves from start to goal, where one move slides any distance
/// in a straight line until a wall ('X') or the edge. BFS where each move enqueues every cell
/// along the slide; a cell already reached can't improve, so it's skipped.
/// https://www.hackerrank.com/challenges/castle-on-the-grid
/// </summary>
public static class CastleOnTheGrid
{
    private static readonly (int Row, int Col)[] Directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    public static int Solve(IReadOnlyList<string> grid, int startX, int startY, int goalX, int goalY)
    {
        int n = grid.Count;
        var moves = new int[n, grid[0].Length];
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                moves[r, c] = -1;
            }
        }

        moves[startX, startY] = 0;
        var queue = new Queue<(int Row, int Col)>();
        queue.Enqueue((startX, startY));

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            if (row == goalX && col == goalY)
            {
                break;
            }

            foreach (var (dr, dc) in Directions)
            {
                for (int r = row + dr, c = col + dc;
                    r >= 0 && r < n && c >= 0 && c < grid[r].Length && grid[r][c] != 'X';
                    r += dr, c += dc)
                {
                    if (moves[r, c] == -1)
                    {
                        moves[r, c] = moves[row, col] + 1;
                        queue.Enqueue((r, c));
                    }
                }
            }
        }

        return moves[goalX, goalY];
    }
}
