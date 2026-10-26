namespace HackerRank.Solutions.Search;

/// <summary>
/// Pairs — count pairs of (distinct) elements whose difference is exactly <c>k</c>, in O(n)
/// using a hash set.
/// https://www.hackerrank.com/challenges/pairs
/// </summary>
public static class Pairs
{
    public static int Solve(int k, IReadOnlyList<int> arr)
    {
        var values = new HashSet<int>(arr);
        return values.Count(value => values.Contains(value + k));
    }
}
