namespace HackerRank.Solutions.Search;

/// <summary>
/// KnightL on a Chessboard — for every 1 ≤ a, b &lt; n, the fewest moves a knight that jumps
/// (a, b) needs to get from (0, 0) to (n - 1, n - 1), or -1 if it can't. One BFS per (a, b);
/// KnightL(a, b) moves exactly like KnightL(b, a), so each pair is searched once. O(n^4).
/// https://www.hackerrank.com/challenges/knightl-on-chessboard
/// </summary>
public static class KnightLOnAChessboard
{
    public static int[][] Solve(int n)
    {
        var result = new int[n - 1][];
        for (int i = 0; i < n - 1; i++)
        {
            result[i] = new int[n - 1];
        }

        for (int a = 1; a < n; a++)
        {
            for (int b = a; b < n; b++)
            {
                int moves = ShortestPath(n, a, b);
                result[a - 1][b - 1] = moves;
                result[b - 1][a - 1] = moves;
            }
        }

        return result;
    }

    private static int ShortestPath(int n, int a, int b)
    {
        (int, int)[] jumps = [(a, b), (a, -b), (-a, b), (-a, -b), (b, a), (b, -a), (-b, a), (-b, -a)];

        var distance = new int[n, n];
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                distance[r, c] = -1;
            }
        }

        distance[0, 0] = 0;
        var queue = new Queue<(int Row, int Col)>();
        queue.Enqueue((0, 0));

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            if (row == n - 1 && col == n - 1)
            {
                break;
            }

            foreach (var (dr, dc) in jumps)
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

        return distance[n - 1, n - 1];
    }
}
