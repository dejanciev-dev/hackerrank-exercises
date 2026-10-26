namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Picking Numbers — length of the longest subset where any two elements differ by at most 1.
/// Such a subset uses only two adjacent values, so count frequencies and take the best pair.
/// https://www.hackerrank.com/challenges/picking-numbers
/// </summary>
public static class PickingNumbers
{
    public static int Solve(IReadOnlyList<int> a)
    {
        var counts = new Dictionary<int, int>();
        foreach (var value in a)
        {
            counts[value] = counts.GetValueOrDefault(value) + 1;
        }

        int best = 0;
        foreach (var (value, count) in counts)
        {
            best = Math.Max(best, count + counts.GetValueOrDefault(value + 1));
        }

        return best;
    }
}
