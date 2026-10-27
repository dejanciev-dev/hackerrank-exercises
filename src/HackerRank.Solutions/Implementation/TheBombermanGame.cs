namespace HackerRank.Solutions.Implementation;

/// <summary>
/// The Bomberman Game — the grid after <c>n</c> seconds of planting and detonations. The
/// states repeat: after second 1 the grid is full on even seconds, and the odd seconds
/// alternate between one and two detonations of the initial grid (n % 4 == 3 and n % 4 == 1).
/// So at most two simulated detonations, O(rows · columns), whatever n is.
/// https://www.hackerrank.com/challenges/bomber-man
/// </summary>
public static class TheBombermanGame
{
    private const char Bomb = 'O';
    private const char Empty = '.';

    public static string[] Solve(int n, IReadOnlyList<string> grid)
    {
        if (n == 1)
        {
            return grid.ToArray();
        }

        if (n % 2 == 0)
        {
            return grid.Select(row => new string(Bomb, row.Length)).ToArray();
        }

        var once = Detonate(grid);
        return n % 4 == 3 ? once : Detonate(once);
    }

    /// <summary>The grid left when the bombs of <paramref name="grid"/> go off in a full grid.</summary>
    private static string[] Detonate(IReadOnlyList<string> grid)
    {
        var result = grid.Select(row => new string(Bomb, row.Length).ToCharArray()).ToArray();

        for (int r = 0; r < grid.Count; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                if (grid[r][c] != Bomb)
                {
                    continue;
                }

                result[r][c] = Empty;
                if (r > 0) result[r - 1][c] = Empty;
                if (r < grid.Count - 1) result[r + 1][c] = Empty;
                if (c > 0) result[r][c - 1] = Empty;
                if (c < grid[r].Length - 1) result[r][c + 1] = Empty;
            }
        }

        return result.Select(row => new string(row)).ToArray();
    }
}
