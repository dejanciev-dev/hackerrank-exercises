namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Insertion Sort Advanced Analysis — number of shifts insertion sort would make, which is the
/// number of inversions. Counted during a merge sort: whenever an element of the right half is
/// merged first, it jumps every element still waiting in the left half. O(n log n).
/// https://www.hackerrank.com/challenges/insertion-sort
/// </summary>
public static class InsertionSortAdvancedAnalysis
{
    public static long Solve(IReadOnlyList<int> arr)
    {
        var values = arr.ToArray();
        return SortAndCount(values, new int[values.Length], 0, values.Length);
    }

    private static long SortAndCount(int[] values, int[] buffer, int start, int end)
    {
        if (end - start < 2)
        {
            return 0;
        }

        int mid = (start + end) / 2;
        long inversions = SortAndCount(values, buffer, start, mid) + SortAndCount(values, buffer, mid, end);

        int left = start;
        int right = mid;
        int write = start;

        while (left < mid || right < end)
        {
            // "<=" keeps equal elements in order, so they don't count as inversions.
            if (right == end || (left < mid && values[left] <= values[right]))
            {
                buffer[write++] = values[left++];
            }
            else
            {
                inversions += mid - left;
                buffer[write++] = values[right++];
            }
        }

        Array.Copy(buffer, start, values, start, end - start);
        return inversions;
    }
}
