namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Flipping the Matrix — reverse rows and columns of a 2n x 2n matrix to maximise the sum of
/// its top-left n x n quadrant. Each top-left cell can receive any of its four mirror images,
/// and they can be chosen independently, so take the largest of each four. O(n²).
/// https://www.hackerrank.com/challenges/flipping-the-matrix
/// </summary>
public static class FlippingTheMatrix
{
    public static int Solve(IReadOnlyList<IReadOnlyList<int>> matrix)
    {
        int size = matrix.Count;
        int n = size / 2;
        int sum = 0;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int mirrorR = size - 1 - r;
                int mirrorC = size - 1 - c;

                sum += Math.Max(
                    Math.Max(matrix[r][c], matrix[r][mirrorC]),
                    Math.Max(matrix[mirrorR][c], matrix[mirrorR][mirrorC]));
            }
        }

        return sum;
    }
}
