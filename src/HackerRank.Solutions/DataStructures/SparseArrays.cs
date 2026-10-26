namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Sparse Arrays — for each query, count how many times it appears among the input strings.
/// A frequency dictionary answers each query in O(1).
/// https://www.hackerrank.com/challenges/sparse-arrays
/// </summary>
public static class SparseArrays
{
    public static int[] Solve(IReadOnlyList<string> strings, IReadOnlyList<string> queries)
    {
        var counts = new Dictionary<string, int>();
        foreach (var s in strings)
        {
            counts[s] = counts.GetValueOrDefault(s) + 1;
        }

        return queries.Select(query => counts.GetValueOrDefault(query)).ToArray();
    }
}
