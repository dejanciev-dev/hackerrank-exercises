namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Mr K marsh — the largest perimeter of a rectangular fence whose four sides avoid marsh
/// ('x') cells, or "impossible". For each pair of top and bottom rows, scan the columns. A
/// column can be a side if it's clear between the two rows (column prefix counts), and a
/// marsh on either row breaks the run. The widest rectangle pairs each side column with the
/// first side column of its run. O(m² · n).
/// https://www.hackerrank.com/challenges/mr-k-marsh
/// </summary>
public static class MrKMarsh
{
    public static string Solve(IReadOnlyList<string> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Length;

        // marshAbove[r, c]: marsh cells in column c among rows 0..r-1.
        var marshAbove = new int[rows + 1, cols];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                marshAbove[r + 1, c] = marshAbove[r, c] + (grid[r][c] == 'x' ? 1 : 0);
            }
        }

        int best = 0;

        for (int top = 0; top < rows; top++)
        {
            for (int bottom = top + 1; bottom < rows; bottom++)
            {
                int left = -1;

                for (int c = 0; c < cols; c++)
                {
                    if (grid[top][c] == 'x' || grid[bottom][c] == 'x')
                    {
                        left = -1;
                        continue;
                    }

                    bool sideClear = marshAbove[bottom + 1, c] - marshAbove[top, c] == 0;
                    if (!sideClear)
                    {
                        continue;
                    }

                    if (left == -1)
                    {
                        left = c;
                    }
                    else
                    {
                        best = Math.Max(best, 2 * (bottom - top) + 2 * (c - left));
                    }
                }
            }
        }

        return best > 0 ? best.ToString() : "impossible";
    }
}
