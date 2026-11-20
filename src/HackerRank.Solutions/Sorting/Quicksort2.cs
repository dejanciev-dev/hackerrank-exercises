namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Quicksort 2 - Sorting — sort an array of distinct integers with quicksort using the first
/// element as the pivot, partitioning stably into smaller and larger elements. After every
/// partition that has been recursively sorted, print the resulting sub-array (left part, pivot,
/// right part); sub-arrays of fewer than two elements are not printed, and the left part is
/// finished before the right one. O(n log n) on average.
/// https://www.hackerrank.com/challenges/quicksort2
/// </summary>
public static class Quicksort2
{
    /// <returns>The space-separated sub-arrays in the order they are printed.</returns>
    public static string[] Solve(IReadOnlyList<int> arr)
    {
        var lines = new List<string>();
        Sort(arr.ToArray(), lines);
        return [.. lines];
    }

    private static int[] Sort(int[] part, List<string> lines)
    {
        if (part.Length <= 1)
        {
            return part;
        }

        int pivot = part[0];
        var left = Sort(part.Skip(1).Where(x => x < pivot).ToArray(), lines);
        var right = Sort(part.Skip(1).Where(x => x > pivot).ToArray(), lines);

        int[] merged = [.. left, pivot, .. right];
        lines.Add(string.Join(' ', merged));
        return merged;
    }
}
