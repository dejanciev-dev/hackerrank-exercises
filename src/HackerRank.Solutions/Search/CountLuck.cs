namespace HackerRank.Solutions.Search;

/// <summary>
/// Count Luck — Hermione waves her wand at every cell on the unique path from 'M' to '*' where
/// more than one way forward is open. "Impressed" if Ron's guess <c>k</c> matches the number of
/// waves, otherwise "Oops!". BFS records each cell's parent; then walk the path back from '*'.
/// https://www.hackerrank.com/challenges/count-luck
/// </summary>
public static class CountLuck
{
    private static readonly (int Row, int Col)[] Directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    public static string Solve(IReadOnlyList<string> matrix, int k)
    {
        var start = Find(matrix, 'M');
        var goal = Find(matrix, '*');

        var parent = new Dictionary<(int Row, int Col), (int Row, int Col)> { [start] = start };
        var queue = new Queue<(int Row, int Col)>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();
            foreach (var next in OpenNeighbours(matrix, cell))
            {
                if (parent.TryAdd(next, cell))
                {
                    queue.Enqueue(next);
                }
            }
        }

        int waves = 0;
        for (var cell = parent[goal]; ; cell = parent[cell])
        {
            // Every path cell except the start was entered from its parent, which isn't a choice.
            int choices = OpenNeighbours(matrix, cell).Count() - (cell == start ? 0 : 1);
            if (choices > 1)
            {
                waves++;
            }

            if (cell == start)
            {
                break;
            }
        }

        return waves == k ? "Impressed" : "Oops!";
    }

    private static (int Row, int Col) Find(IReadOnlyList<string> matrix, char target)
    {
        for (int r = 0; r < matrix.Count; r++)
        {
            int c = matrix[r].IndexOf(target);
            if (c >= 0)
            {
                return (r, c);
            }
        }

        throw new ArgumentException($"The forest has no '{target}'.", nameof(matrix));
    }

    private static IEnumerable<(int Row, int Col)> OpenNeighbours(IReadOnlyList<string> matrix, (int Row, int Col) cell)
    {
        foreach (var (dr, dc) in Directions)
        {
            int r = cell.Row + dr;
            int c = cell.Col + dc;

            if (r >= 0 && r < matrix.Count && c >= 0 && c < matrix[r].Length && matrix[r][c] != 'X')
            {
                yield return (r, c);
            }
        }
    }
}
