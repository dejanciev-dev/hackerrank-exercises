namespace HackerRank.Solutions.Recursion;

/// <summary>
/// Crossword Puzzle — fill the '-' cells of a 10x10 grid with the ';'-separated words.
/// Collect every horizontal and vertical slot, then backtrack: place each word in a free slot
/// of the same length whose crossing letters agree, undoing only the cells it wrote.
/// https://www.hackerrank.com/challenges/crossword-puzzle
/// </summary>
public static class CrosswordPuzzle
{
    private const char Open = '-';

    private readonly record struct Slot(int Row, int Col, int DRow, int DCol, int Length);

    public static string[] Solve(IReadOnlyList<string> crossword, string words)
    {
        var grid = crossword.Select(row => row.ToCharArray()).ToArray();
        var slots = FindSlots(grid);
        var used = new bool[slots.Count];

        if (!Place(grid, slots, used, words.Split(';'), 0))
        {
            throw new InvalidOperationException("The words don't fit the grid.");
        }

        return grid.Select(row => new string(row)).ToArray();
    }

    private static List<Slot> FindSlots(char[][] grid)
    {
        var slots = new List<Slot>();

        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                if (grid[r][c] != Open)
                {
                    continue;
                }

                // A slot starts where the previous cell in its direction isn't open.
                if (c == 0 || grid[r][c - 1] != Open)
                {
                    int length = RunLength(grid, r, c, 0, 1);
                    if (length > 1)
                    {
                        slots.Add(new Slot(r, c, 0, 1, length));
                    }
                }

                if (r == 0 || grid[r - 1][c] != Open)
                {
                    int length = RunLength(grid, r, c, 1, 0);
                    if (length > 1)
                    {
                        slots.Add(new Slot(r, c, 1, 0, length));
                    }
                }
            }
        }

        return slots;
    }

    private static int RunLength(char[][] grid, int r, int c, int dr, int dc)
    {
        int length = 0;
        while (r < grid.Length && c < grid[r].Length && grid[r][c] == Open)
        {
            length++;
            r += dr;
            c += dc;
        }

        return length;
    }

    private static bool Place(char[][] grid, List<Slot> slots, bool[] used, string[] words, int index)
    {
        if (index == words.Length)
        {
            return true;
        }

        string word = words[index];

        for (int s = 0; s < slots.Count; s++)
        {
            var slot = slots[s];
            if (used[s] || slot.Length != word.Length || !Fits(grid, slot, word))
            {
                continue;
            }

            var written = new List<(int Row, int Col)>();
            for (int i = 0; i < word.Length; i++)
            {
                int r = slot.Row + i * slot.DRow;
                int c = slot.Col + i * slot.DCol;
                if (grid[r][c] == Open)
                {
                    grid[r][c] = word[i];
                    written.Add((r, c));
                }
            }

            used[s] = true;
            if (Place(grid, slots, used, words, index + 1))
            {
                return true;
            }

            used[s] = false;
            foreach (var (r, c) in written)
            {
                grid[r][c] = Open;
            }
        }

        return false;
    }

    private static bool Fits(char[][] grid, Slot slot, string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            char cell = grid[slot.Row + i * slot.DRow][slot.Col + i * slot.DCol];
            if (cell != Open && cell != word[i])
            {
                return false;
            }
        }

        return true;
    }
}
