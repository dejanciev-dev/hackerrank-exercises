namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Sorting: Bubble Sort — run bubble sort, counting swaps, and report the swap count and the
/// first and last elements of the sorted array.
/// https://www.hackerrank.com/challenges/ctci-bubble-sort
/// </summary>
public static class BubbleSort
{
    public static string[] Solve(IReadOnlyList<int> a)
    {
        var values = a.ToArray();
        int swaps = 0;

        for (int pass = 0; pass < values.Length; pass++)
        {
            for (int j = 0; j < values.Length - 1 - pass; j++)
            {
                if (values[j] > values[j + 1])
                {
                    (values[j], values[j + 1]) = (values[j + 1], values[j]);
                    swaps++;
                }
            }
        }

        return
        [
            $"Array is sorted in {swaps} swaps.",
            $"First Element: {values[0]}",
            $"Last Element: {values[^1]}",
        ];
    }
}
