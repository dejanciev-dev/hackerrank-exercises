namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Beautiful Triplets — count triplets i &lt; j &lt; k in a non-decreasing array where
/// a[j] - a[i] = a[k] - a[j] = d. Multiplying value frequencies handles duplicates in O(n).
/// https://www.hackerrank.com/challenges/beautiful-triplets
/// </summary>
public static class BeautifulTriplets
{
    public static long Solve(int d, IReadOnlyList<int> arr)
    {
        var counts = new Dictionary<int, long>();
        foreach (var value in arr)
        {
            counts[value] = counts.GetValueOrDefault(value) + 1;
        }

        long triplets = 0;
        foreach (var (value, count) in counts)
        {
            triplets += count * counts.GetValueOrDefault(value + d) * counts.GetValueOrDefault(value + 2 * d);
        }

        return triplets;
    }
}
