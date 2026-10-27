namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// The Maximum Subarray — the best sum of a non-empty contiguous subarray (Kadane's algorithm)
/// and of a non-empty subsequence (all positives, or the largest element when none are). O(n).
/// https://www.hackerrank.com/challenges/maxsubarray
/// </summary>
public static class MaximumSubarray
{
    public static long[] Solve(IReadOnlyList<int> arr)
    {
        long bestSubarray = arr[0];
        long endingHere = arr[0];
        long positives = 0;
        int largest = arr[0];

        for (int i = 0; i < arr.Count; i++)
        {
            if (i > 0)
            {
                endingHere = Math.Max(arr[i], endingHere + arr[i]);
                bestSubarray = Math.Max(bestSubarray, endingHere);
            }

            if (arr[i] > 0)
            {
                positives += arr[i];
            }

            largest = Math.Max(largest, arr[i]);
        }

        return [bestSubarray, largest > 0 ? positives : largest];
    }
}
