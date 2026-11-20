namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Running Time of Quicksort — compare insertion sort with the in-place quicksort of the previous
/// challenge on the same array of distinct integers, and report the number of insertion-sort
/// shifts minus the number of quicksort swaps. Quicksort uses the last element of the range as
/// the pivot and counts every swap it performs, including a swap of an element with itself and
/// the final swap that puts the pivot in place.
/// The shifts equal the number of inversions; both counts are produced by simulating the sorts,
/// which is O(n²) in the worst case and fine for the intended n ≤ 1000.
/// https://www.hackerrank.com/challenges/quicksort4
/// </summary>
public static class RunningTimeOfQuicksort
{
    public static int Solve(IReadOnlyList<int> arr) =>
        CountShifts(arr.ToArray()) - CountSwaps(arr.ToArray(), 0, arr.Count - 1);

    private static int CountShifts(int[] a)
    {
        int shifts = 0;
        for (int i = 1; i < a.Length; i++)
        {
            int value = a[i];
            int j = i - 1;
            while (j >= 0 && a[j] > value)
            {
                a[j + 1] = a[j];
                j--;
                shifts++;
            }

            a[j + 1] = value;
        }

        return shifts;
    }

    private static int CountSwaps(int[] a, int lo, int hi)
    {
        if (lo >= hi)
        {
            return 0;
        }

        int pivot = a[hi];
        int boundary = lo - 1;
        int swaps = 0;

        for (int j = lo; j < hi; j++)
        {
            if (a[j] < pivot)
            {
                boundary++;
                (a[boundary], a[j]) = (a[j], a[boundary]);
                swaps++;
            }
        }

        (a[boundary + 1], a[hi]) = (a[hi], a[boundary + 1]);
        swaps++;

        return swaps + CountSwaps(a, lo, boundary) + CountSwaps(a, boundary + 2, hi);
    }
}
