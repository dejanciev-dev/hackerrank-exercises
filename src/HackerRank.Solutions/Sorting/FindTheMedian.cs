namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Find the Median — the middle element of an odd-length array once sorted.
/// https://www.hackerrank.com/challenges/find-the-median
/// </summary>
public static class FindTheMedian
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        var sorted = arr.Order().ToArray();
        return sorted[sorted.Length / 2];
    }
}
