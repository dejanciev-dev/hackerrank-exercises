namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Quicksort In-Place — sort an array of distinct integers with an in-place quicksort that uses
/// the last element of the current range as the pivot (Lomuto partition scheme: elements smaller
/// than the pivot are swapped to the front of the range, then the pivot is swapped into place).
/// After every partition of a range with at least two elements, print the whole array; the left
/// part is processed before the right one. O(n log n) on average.
/// https://www.hackerrank.com/challenges/quicksort3
/// </summary>
public static class QuicksortInPlace
{
    /// <returns>The whole array, space-separated, after each partition.</returns>
    public static string[] Solve(IReadOnlyList<int> arr)
    {
        var a = arr.ToArray();
        var lines = new List<string>();
        Sort(a, 0, a.Length - 1, lines);
        return [.. lines];
    }

    private static void Sort(int[] a, int lo, int hi, List<string> lines)
    {
        if (lo >= hi)
        {
            return;
        }

        int pivot = a[hi];
        int boundary = lo - 1;

        for (int j = lo; j < hi; j++)
        {
            if (a[j] < pivot)
            {
                boundary++;
                (a[boundary], a[j]) = (a[j], a[boundary]);
            }
        }

        (a[boundary + 1], a[hi]) = (a[hi], a[boundary + 1]);
        lines.Add(string.Join(' ', a));

        Sort(a, lo, boundary, lines);
        Sort(a, boundary + 2, hi, lines);
    }
}
