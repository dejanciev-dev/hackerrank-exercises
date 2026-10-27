namespace HackerRank.Solutions.Search;

/// <summary>
/// Count Triplets — number of index triples i &lt; j &lt; k forming a geometric progression
/// with ratio <c>r</c>. Treat each element as the middle term: multiply how many times x / r
/// appeared to its left by how many times x · r appears to its right. Two hash maps, O(n).
/// https://www.hackerrank.com/challenges/count-triplets-1
/// </summary>
public static class CountTriplets
{
    public static long Solve(IReadOnlyList<long> arr, long r)
    {
        var left = new Dictionary<long, long>();
        var right = new Dictionary<long, long>();

        foreach (var value in arr)
        {
            right[value] = right.GetValueOrDefault(value) + 1;
        }

        long triplets = 0;

        foreach (var value in arr)
        {
            right[value]--;

            if (value % r == 0)
            {
                triplets += left.GetValueOrDefault(value / r) * right.GetValueOrDefault(value * r);
            }

            left[value] = left.GetValueOrDefault(value) + 1;
        }

        return triplets;
    }
}
