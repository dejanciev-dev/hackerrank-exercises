namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Grid Challenge — sort each row alphabetically, then check whether every column is also in
/// ascending order.
/// https://www.hackerrank.com/challenges/grid-challenge
/// </summary>
public static class GridChallenge
{
    public static string Solve(IReadOnlyList<string> grid)
    {
        var rows = grid.Select(row => row.Order().ToArray()).ToArray();

        for (int r = 1; r < rows.Length; r++)
        {
            for (int c = 0; c < rows[r].Length; c++)
            {
                if (rows[r][c] < rows[r - 1][c])
                {
                    return "NO";
                }
            }
        }

        return "YES";
    }
}
