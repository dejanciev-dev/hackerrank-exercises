namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Big Sorting — sort numeric strings of up to 10^6 digits by value. With no leading zeros a
/// shorter string is always smaller, so compare by length first and then ordinally; no parsing needed.
/// https://www.hackerrank.com/challenges/big-sorting
/// </summary>
public static class BigSorting
{
    public static string[] Solve(IReadOnlyList<string> unsorted)
    {
        return unsorted
            .OrderBy(number => number.Length)
            .ThenBy(number => number, StringComparer.Ordinal)
            .ToArray();
    }
}
