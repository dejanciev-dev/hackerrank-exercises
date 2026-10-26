namespace HackerRank.Solutions.Search;

/// <summary>
/// Missing Numbers — values whose frequency in <c>arr</c> is lower than in the original list
/// <c>brr</c>, each reported once in ascending order.
/// https://www.hackerrank.com/challenges/missing-numbers
/// </summary>
public static class MissingNumbers
{
    public static int[] Solve(IReadOnlyList<int> arr, IReadOnlyList<int> brr)
    {
        var balance = new SortedDictionary<int, int>();

        foreach (var value in brr) balance[value] = balance.GetValueOrDefault(value) + 1;
        foreach (var value in arr) balance[value] = balance.GetValueOrDefault(value) - 1;

        return balance.Where(entry => entry.Value > 0).Select(entry => entry.Key).ToArray();
    }
}
