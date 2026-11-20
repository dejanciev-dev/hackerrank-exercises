namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Zig Zag Sequence — given an array of distinct integers of odd length n, rearrange it so
/// that the first (n + 1) / 2 elements are in increasing order and the rest in decreasing order,
/// with the smallest possible values in the increasing part (the lexicographically smallest
/// such arrangement). Sort, put the maximum in the middle, and lay the remaining upper half
/// out in descending order. O(n log n).
/// https://www.hackerrank.com/challenges/zig-zag-sequence
/// </summary>
public static class ZigZagSequence
{
    public static int[] Solve(IReadOnlyList<int> a)
    {
        var sorted = a.Order().ToArray();
        int mid = sorted.Length / 2;

        // Swap the middle element with the maximum, then reverse what follows it (the maximum is
        // already in place, so the last position is left alone).
        (sorted[mid], sorted[^1]) = (sorted[^1], sorted[mid]);
        Array.Reverse(sorted, mid + 1, Math.Max(0, sorted.Length - mid - 2));

        return sorted;
    }
}
