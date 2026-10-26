namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Cavity Map — mark with 'X' every non-border cell that is strictly deeper than its four
/// neighbors.
/// https://www.hackerrank.com/challenges/cavity-map
/// </summary>
public static class CavityMap
{
    public static string[] Solve(IReadOnlyList<string> grid)
    {
        int n = grid.Count;
        var result = grid.Select(row => row.ToCharArray()).ToArray();

        for (int r = 1; r < n - 1; r++)
        {
            for (int c = 1; c < grid[r].Length - 1; c++)
            {
                char depth = grid[r][c];

                if (depth > grid[r - 1][c] && depth > grid[r + 1][c]
                    && depth > grid[r][c - 1] && depth > grid[r][c + 1])
                {
                    result[r][c] = 'X';
                }
            }
        }

        return result.Select(row => new string(row)).ToArray();
    }
}
