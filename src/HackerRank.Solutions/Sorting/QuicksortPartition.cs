namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Quicksort 1 - Partition — partition around the first element: smaller values, the pivot
/// (and its equals), then larger values, keeping the original relative order within each part.
/// https://www.hackerrank.com/challenges/quicksort1
/// </summary>
public static class QuicksortPartition
{
    public static int[] Solve(IReadOnlyList<int> arr)
    {
        int pivot = arr[0];

        return arr.Where(v => v < pivot)
            .Concat(arr.Where(v => v == pivot))
            .Concat(arr.Where(v => v > pivot))
            .ToArray();
    }
}
