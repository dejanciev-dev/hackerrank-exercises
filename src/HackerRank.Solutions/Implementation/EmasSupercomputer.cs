namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Ema's Supercomputer — the largest product of the areas of two non-overlapping pluses drawn
/// on good ('G') cells. The grid is at most 15 x 15, so list every plus (each centre with each
/// possible arm length) and try every pair. Areas are 4 · arm + 1.
/// https://www.hackerrank.com/challenges/two-pluses
/// </summary>
public static class EmasSupercomputer
{
    private readonly record struct Plus(int Row, int Col, int Arm)
    {
        public int Area => 4 * Arm + 1;

        public IEnumerable<(int Row, int Col)> Cells()
        {
            yield return (Row, Col);
            for (int i = 1; i <= Arm; i++)
            {
                yield return (Row - i, Col);
                yield return (Row + i, Col);
                yield return (Row, Col - i);
                yield return (Row, Col + i);
            }
        }
    }

    public static int Solve(IReadOnlyList<string> grid)
    {
        var pluses = new List<Plus>();

        for (int r = 0; r < grid.Count; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                for (int arm = 0; IsGood(grid, r - arm, c) && IsGood(grid, r + arm, c)
                    && IsGood(grid, r, c - arm) && IsGood(grid, r, c + arm); arm++)
                {
                    pluses.Add(new Plus(r, c, arm));
                }
            }
        }

        int best = 0;

        for (int i = 0; i < pluses.Count; i++)
        {
            var occupied = pluses[i].Cells().ToHashSet();

            for (int j = i + 1; j < pluses.Count; j++)
            {
                int product = pluses[i].Area * pluses[j].Area;
                if (product > best && !pluses[j].Cells().Any(occupied.Contains))
                {
                    best = product;
                }
            }
        }

        return best;
    }

    private static bool IsGood(IReadOnlyList<string> grid, int r, int c) =>
        r >= 0 && r < grid.Count && c >= 0 && c < grid[r].Length && grid[r][c] == 'G';
}
