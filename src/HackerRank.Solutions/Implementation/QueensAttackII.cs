namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Queen's Attack II — squares a queen at (rQ, cQ) can attack on an n×n board with obstacles.
/// For each of the 8 directions, start from the distance to the board edge and shrink it to
/// just before the nearest obstacle on that ray: O(k) instead of walking the board.
/// https://www.hackerrank.com/challenges/queens-attack-2
/// </summary>
public static class QueensAttackII
{
    private static readonly (int Row, int Col)[] Directions =
    [
        (1, 0), (-1, 0), (0, 1), (0, -1),
        (1, 1), (1, -1), (-1, 1), (-1, -1),
    ];

    public static int Solve(int n, int rQ, int cQ, IReadOnlyList<IReadOnlyList<int>> obstacles)
    {
        var reach = Directions.Select(d => StepsToEdge(n, rQ, cQ, d)).ToArray();

        foreach (var obstacle in obstacles)
        {
            int dRow = obstacle[0] - rQ;
            int dCol = obstacle[1] - cQ;

            for (int i = 0; i < Directions.Length; i++)
            {
                if (IsOnRay(dRow, dCol, Directions[i]))
                {
                    int distance = Math.Max(Math.Abs(dRow), Math.Abs(dCol));
                    reach[i] = Math.Min(reach[i], distance - 1);
                }
            }
        }

        return reach.Sum();
    }

    private static int StepsToEdge(int n, int row, int col, (int Row, int Col) d)
    {
        int rowSteps = d.Row switch { 1 => n - row, -1 => row - 1, _ => int.MaxValue };
        int colSteps = d.Col switch { 1 => n - col, -1 => col - 1, _ => int.MaxValue };
        return Math.Min(rowSteps, colSteps);
    }

    private static bool IsOnRay(int dRow, int dCol, (int Row, int Col) d)
    {
        if (Math.Sign(dRow) != d.Row || Math.Sign(dCol) != d.Col)
        {
            return false;
        }

        // Diagonal rays additionally require equal offsets.
        return d.Row == 0 || d.Col == 0 || Math.Abs(dRow) == Math.Abs(dCol);
    }
}
