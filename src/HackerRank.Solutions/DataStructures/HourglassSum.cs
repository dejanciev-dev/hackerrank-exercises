namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// 2D Array - DS — the maximum hourglass sum in a 6x6 grid, where an hourglass is
/// three cells on top, one in the middle and three on the bottom.
/// https://www.hackerrank.com/challenges/2d-array
/// </summary>
public static class HourglassSum
{
    public static int Solve(IReadOnlyList<IReadOnlyList<int>> arr)
    {
        int best = int.MinValue;

        for (int row = 0; row + 2 < arr.Count; row++)
        {
            for (int col = 0; col + 2 < arr[row].Count; col++)
            {
                int sum = arr[row][col] + arr[row][col + 1] + arr[row][col + 2]
                        + arr[row + 1][col + 1]
                        + arr[row + 2][col] + arr[row + 2][col + 1] + arr[row + 2][col + 2];

                best = Math.Max(best, sum);
            }
        }

        return best;
    }
}
