using System.Globalization;

namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Median Updates — process "a x" (add) and "r x" (remove one x) and print the median after
/// each, or "Wrong!" if x isn't there or the list ends up empty. Two balanced sorted sets
/// hold the lower and upper halves, so any element can be removed in O(log n), unlike with
/// heaps. Values are tagged with an id so duplicates can coexist.
/// https://www.hackerrank.com/challenges/median
/// </summary>
public static class MedianUpdates
{
    public static string[] Solve(IReadOnlyList<string> operations)
    {
        var lower = new SortedSet<(long Value, int Id)>();
        var upper = new SortedSet<(long Value, int Id)>();
        var output = new List<string>(operations.Count);

        for (int id = 0; id < operations.Count; id++)
        {
            var parts = operations[id].Split(' ');
            long x = long.Parse(parts[1], CultureInfo.InvariantCulture);

            if (parts[0] == "a")
            {
                if (lower.Count == 0 || x <= lower.Max.Value)
                {
                    lower.Add((x, id));
                }
                else
                {
                    upper.Add((x, id));
                }
            }
            else if (!TryRemove(lower, x) && !TryRemove(upper, x))
            {
                output.Add("Wrong!");
                continue;
            }

            Rebalance(lower, upper);

            if (lower.Count == 0)
            {
                output.Add("Wrong!");
                continue;
            }

            output.Add(lower.Count > upper.Count
                ? lower.Max.Value.ToString(CultureInfo.InvariantCulture)
                : FormatHalf(lower.Max.Value + upper.Min.Value));
        }

        return output.ToArray();
    }

    private static bool TryRemove(SortedSet<(long Value, int Id)> set, long x)
    {
        var matches = set.GetViewBetween((x, int.MinValue), (x, int.MaxValue));
        return matches.Count > 0 && set.Remove(matches.Min);
    }

    /// <summary>Keeps lower.Count equal to upper.Count or one more.</summary>
    private static void Rebalance(SortedSet<(long Value, int Id)> lower, SortedSet<(long Value, int Id)> upper)
    {
        while (lower.Count > upper.Count + 1)
        {
            var moved = lower.Max;
            lower.Remove(moved);
            upper.Add(moved);
        }

        while (upper.Count > lower.Count)
        {
            var moved = upper.Min;
            upper.Remove(moved);
            lower.Add(moved);
        }
    }

    /// <summary>sum / 2 without a trailing ".0" for whole numbers, as HackerRank expects.</summary>
    private static string FormatHalf(long sum) =>
        sum % 2 == 0
            ? (sum / 2).ToString(CultureInfo.InvariantCulture)
            : (sum / 2.0).ToString("0.0", CultureInfo.InvariantCulture);
}
