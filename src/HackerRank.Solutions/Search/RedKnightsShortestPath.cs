namespace HackerRank.Solutions.Search;

/// <summary>
/// Red Knight's Shortest Path — fewest moves (UL, UR, R, LR, LL, L) between two squares, plus
/// the move sequence that prefers moves in that order, or "Impossible". Every move's reverse
/// is also a move, so a BFS from the target gives each square's distance to it. Then walk
/// from the start, always taking the first move (in priority order) that gets one step closer.
/// https://www.hackerrank.com/challenges/red-knights-shortest-path
/// </summary>
public static class RedKnightsShortestPath
{
    private static readonly (string Name, int Row, int Col)[] Moves =
        [("UL", -2, -1), ("UR", -2, 1), ("R", 0, 2), ("LR", 2, 1), ("LL", 2, -1), ("L", 0, -2)];

    public static string[] Solve(int n, int iStart, int jStart, int iEnd, int jEnd)
    {
        var distance = new int[n, n];
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                distance[r, c] = -1;
            }
        }

        distance[iEnd, jEnd] = 0;
        var queue = new Queue<(int Row, int Col)>();
        queue.Enqueue((iEnd, jEnd));

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            foreach (var (_, dr, dc) in Moves)
            {
                int r = row + dr;
                int c = col + dc;
                if (r >= 0 && r < n && c >= 0 && c < n && distance[r, c] == -1)
                {
                    distance[r, c] = distance[row, col] + 1;
                    queue.Enqueue((r, c));
                }
            }
        }

        if (distance[iStart, jStart] == -1)
        {
            return ["Impossible"];
        }

        var path = new List<string>();
        for (int row = iStart, col = jStart; distance[row, col] > 0;)
        {
            foreach (var (name, dr, dc) in Moves)
            {
                int r = row + dr;
                int c = col + dc;
                if (r >= 0 && r < n && c >= 0 && c < n && distance[r, c] == distance[row, col] - 1)
                {
                    path.Add(name);
                    (row, col) = (r, c);
                    break;
                }
            }
        }

        return [path.Count.ToString(), string.Join(' ', path)];
    }
}
