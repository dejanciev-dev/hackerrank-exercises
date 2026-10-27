namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Counting Sort 2 — sort values in 0..99 by counting occurrences and writing each value out
/// as many times as it was seen. O(n + 100).
/// https://www.hackerrank.com/challenges/countingsort2
/// </summary>
public static class CountingSort2
{
    private const int Range = 100;

    public static int[] Solve(IReadOnlyList<int> arr)
    {
        var counts = new int[Range];
        foreach (var value in arr)
        {
            counts[value]++;
        }

        var sorted = new int[arr.Count];
        int index = 0;

        for (int value = 0; value < Range; value++)
        {
            for (int c = 0; c < counts[value]; c++)
            {
                sorted[index++] = value;
            }
        }

        return sorted;
    }
}
