namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Insertion Sort - Part 2 — run a full insertion sort, printing the array after each element
/// from the second onwards has been inserted into the sorted prefix.
/// https://www.hackerrank.com/challenges/insertionsort2
/// </summary>
public static class InsertionSort2
{
    public static string[] Solve(IReadOnlyList<int> arr)
    {
        var values = arr.ToArray();
        var lines = new List<string>();

        for (int i = 1; i < values.Length; i++)
        {
            int pending = values[i];
            int j = i - 1;

            for (; j >= 0 && values[j] > pending; j--)
            {
                values[j + 1] = values[j];
            }

            values[j + 1] = pending;
            lines.Add(string.Join(' ', values));
        }

        return lines.ToArray();
    }
}
