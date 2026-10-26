namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Counting Sort 1 — frequency array of values in [0, 100).
/// https://www.hackerrank.com/challenges/countingsort1
/// </summary>
public static class CountingSort1
{
    public static int[] Solve(IReadOnlyList<int> arr)
    {
        var counts = new int[100];
        foreach (var value in arr)
        {
            counts[value]++;
        }

        return counts;
    }
}
