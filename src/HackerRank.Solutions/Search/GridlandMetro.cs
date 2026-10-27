namespace HackerRank.Solutions.Search;

/// <summary>
/// Gridland Metro — count the cells of an n x m grid not covered by any horizontal train
/// track. The grid can be 10^9 x 10^9, so only rows with tracks are visited: sort each row's
/// intervals and merge overlaps. O(k log k) for k tracks.
/// https://www.hackerrank.com/challenges/gridland-metro
/// </summary>
public static class GridlandMetro
{
    /// <param name="n">Number of rows.</param>
    /// <param name="m">Number of columns.</param>
    /// <param name="track">Each track as <c>[row, startColumn, endColumn]</c>.</param>
    public static long Solve(int n, int m, IReadOnlyList<IReadOnlyList<int>> track)
    {
        long covered = 0;

        foreach (var row in track.GroupBy(t => t[0]))
        {
            long end = 0;

            foreach (var t in row.OrderBy(t => t[1]))
            {
                long start = Math.Max(t[1], end + 1);
                if (t[2] >= start)
                {
                    covered += t[2] - start + 1;
                }

                end = Math.Max(end, t[2]);
            }
        }

        return (long)n * m - covered;
    }
}
