namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Insertion Sort - Part 1 — the array is sorted except for its last element; insert it,
/// printing the array after every shift and once more after the final placement.
/// https://www.hackerrank.com/challenges/insertionsort1
/// </summary>
public static class InsertionSort1
{
    public static string[] Solve(IReadOnlyList<int> arr)
    {
        var values = arr.ToArray();
        var lines = new List<string>();
        int pending = values[^1];
        int i = values.Length - 2;

        for (; i >= 0 && values[i] > pending; i--)
        {
            values[i + 1] = values[i];
            lines.Add(string.Join(' ', values));
        }

        values[i + 1] = pending;
        lines.Add(string.Join(' ', values));
        return lines.ToArray();
    }
}
