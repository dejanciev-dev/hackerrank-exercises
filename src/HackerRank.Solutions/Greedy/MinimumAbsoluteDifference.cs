namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Minimum Absolute Difference in an Array — after sorting, the closest pair is adjacent,
/// so a single scan finds it in O(n log n).
/// https://www.hackerrank.com/challenges/minimum-absolute-difference-in-an-array
/// </summary>
public static class MinimumAbsoluteDifference
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        var sorted = arr.Order().ToArray();
        int smallest = int.MaxValue;

        for (int i = 1; i < sorted.Length; i++)
        {
            smallest = Math.Min(smallest, sorted[i] - sorted[i - 1]);
        }

        return smallest;
    }
}
