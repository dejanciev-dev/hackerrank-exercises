namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Mr. X and His Shots — each fielder covers an interval and each shot lands in an interval;
/// count (shot, fielder) pairs whose intervals overlap. For a fielder [c, d], the overlapping
/// shots are those starting at or before d minus those ending before c. Two sorted arrays and
/// binary searches answer that. O((n + m) log n).
/// https://www.hackerrank.com/challenges/x-and-his-shots
/// </summary>
public static class MrXAndHisShots
{
    public static long Solve(IReadOnlyList<IReadOnlyList<int>> shots, IReadOnlyList<IReadOnlyList<int>> players)
    {
        var starts = shots.Select(s => s[0]).Order().ToArray();
        var ends = shots.Select(s => s[1]).Order().ToArray();
        long overlaps = 0;

        foreach (var player in players)
        {
            overlaps += UpperBound(starts, player[1]) - LowerBound(ends, player[0]);
        }

        return overlaps;
    }

    /// <summary>Number of elements ≤ value.</summary>
    private static int UpperBound(int[] sorted, int value)
    {
        int low = 0, high = sorted.Length;
        while (low < high)
        {
            int mid = (low + high) / 2;
            if (sorted[mid] <= value) low = mid + 1;
            else high = mid;
        }

        return low;
    }

    /// <summary>Number of elements &lt; value.</summary>
    private static int LowerBound(int[] sorted, int value)
    {
        int low = 0, high = sorted.Length;
        while (low < high)
        {
            int mid = (low + high) / 2;
            if (sorted[mid] < value) low = mid + 1;
            else high = mid;
        }

        return low;
    }
}
