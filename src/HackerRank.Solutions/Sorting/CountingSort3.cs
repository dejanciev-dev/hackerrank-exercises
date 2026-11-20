namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Counting Sort 3 — for every value i in 0..99, report how many elements of the array are
/// less than or equal to i (the cumulative frequency table that counting sort uses to place
/// elements). O(n + 100).
/// https://www.hackerrank.com/challenges/countingsort3
/// </summary>
public static class CountingSort3
{
    private const int Range = 100;

    public static int[] Solve(IReadOnlyList<int> arr)
    {
        var cumulative = new int[Range];
        foreach (var value in arr)
        {
            cumulative[value]++;
        }

        for (int value = 1; value < Range; value++)
        {
            cumulative[value] += cumulative[value - 1];
        }

        return cumulative;
    }
}
