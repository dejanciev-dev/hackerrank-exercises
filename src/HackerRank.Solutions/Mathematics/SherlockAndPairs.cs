namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Sherlock and Pairs — count the ordered pairs of indices (i, j) with i ≠ j and a[i] = a[j].
/// A value that occurs c times contributes c · (c − 1) pairs, so counting occurrences is enough.
/// O(n).
/// https://www.hackerrank.com/challenges/sherlock-and-pairs
/// </summary>
public static class SherlockAndPairs
{
    public static long Solve(IReadOnlyList<int> a) =>
        a.GroupBy(x => x).Sum(group => (long)group.Count() * (group.Count() - 1));
}
