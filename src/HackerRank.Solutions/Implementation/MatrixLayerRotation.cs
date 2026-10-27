namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Matrix Layer Rotation — rotate every concentric layer of the matrix anticlockwise by
/// <c>r</c> positions. Read each layer as a ring, shift it by r mod (ring length) and write it
/// back, so huge r costs nothing extra. O(rows · columns).
/// https://www.hackerrank.com/challenges/matrix-rotation-algo
/// </summary>
public static class MatrixLayerRotation
{
    public static int[][] Solve(IReadOnlyList<IReadOnlyList<int>> matrix, int r)
    {
        int rows = matrix.Count;
        int cols = matrix[0].Count;
        var result = matrix.Select(row => row.ToArray()).ToArray();

        for (int layer = 0; layer < Math.Min(rows, cols) / 2; layer++)
        {
            var ring = RingPositions(layer, rows, cols);
            int shift = r % ring.Count;

            // Positions run clockwise, so an anticlockwise rotation pulls each value from
            // the position `shift` steps further along the ring.
            for (int i = 0; i < ring.Count; i++)
            {
                var (toRow, toCol) = ring[i];
                var (fromRow, fromCol) = ring[(i + shift) % ring.Count];
                result[toRow][toCol] = matrix[fromRow][fromCol];
            }
        }

        return result;
    }

    private static List<(int Row, int Col)> RingPositions(int layer, int rows, int cols)
    {
        int top = layer;
        int left = layer;
        int bottom = rows - 1 - layer;
        int right = cols - 1 - layer;
        var ring = new List<(int Row, int Col)>();

        for (int c = left; c < right; c++) ring.Add((top, c));
        for (int r = top; r < bottom; r++) ring.Add((r, right));
        for (int c = right; c > left; c--) ring.Add((bottom, c));
        for (int r = bottom; r > top; r--) ring.Add((r, left));

        return ring;
    }
}
