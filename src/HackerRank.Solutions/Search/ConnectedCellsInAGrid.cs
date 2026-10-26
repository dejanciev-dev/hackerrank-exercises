namespace HackerRank.Solutions.Search;

/// <summary>
/// Connected Cells in a Grid — size of the largest region of 1s, where cells connect in all
/// 8 directions. Iterative depth-first flood fill, so large regions can't overflow the call stack.
/// https://www.hackerrank.com/challenges/connected-cell-in-a-grid
/// </summary>
public static class ConnectedCellsInAGrid
{
    public static int Solve(IReadOnlyList<IReadOnlyList<int>> matrix)
    {
        int rows = matrix.Count;
        int cols = matrix[0].Count;
        var visited = new bool[rows, cols];
        int largest = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (matrix[r][c] == 1 && !visited[r, c])
                {
                    largest = Math.Max(largest, FloodFill(matrix, visited, r, c));
                }
            }
        }

        return largest;
    }

    private static int FloodFill(IReadOnlyList<IReadOnlyList<int>> matrix, bool[,] visited, int startRow, int startCol)
    {
        var stack = new Stack<(int Row, int Col)>();
        stack.Push((startRow, startCol));
        visited[startRow, startCol] = true;
        int size = 0;

        while (stack.Count > 0)
        {
            var (row, col) = stack.Pop();
            size++;

            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    int r = row + dr;
                    int c = col + dc;

                    if (r >= 0 && r < matrix.Count && c >= 0 && c < matrix[r].Count
                        && matrix[r][c] == 1 && !visited[r, c])
                    {
                        visited[r, c] = true;
                        stack.Push((r, c));
                    }
                }
            }
        }

        return size;
    }
}
