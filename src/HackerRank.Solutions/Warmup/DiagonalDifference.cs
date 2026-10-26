namespace HackerRank.Solutions.Warmup;

/// <summary>
/// Diagonal Difference — absolute difference between the sums of a square matrix's diagonals.
/// https://www.hackerrank.com/challenges/diagonal-difference
/// </summary>
public static class DiagonalDifference
{
    public static int Solve(IReadOnlyList<IReadOnlyList<int>> arr)
    {
        int primary = 0;
        int secondary = 0;
        int n = arr.Count;

        for (int i = 0; i < n; i++)
        {
            primary += arr[i][i];
            secondary += arr[i][n - 1 - i];
        }

        return Math.Abs(primary - secondary);
    }
}
