namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Interval Selection — the largest set of closed intervals with no point covered more than
/// twice. Take intervals in order of their right ends, tracking the end of the last chosen
/// interval and the furthest point already covered twice. An interval fits exactly when it
/// starts after that doubly-covered point, and choosing the earliest-ending ones first is
/// optimal by the usual exchange argument. O(n log n).
/// https://www.hackerrank.com/challenges/interval-selection
/// </summary>
public static class IntervalSelection
{
    public static int Solve(IReadOnlyList<IReadOnlyList<int>> intervals)
    {
        long lastEnd = long.MinValue;
        long coveredTwice = long.MinValue;
        int chosen = 0;

        foreach (var interval in intervals.OrderBy(i => i[1]))
        {
            if (interval[0] <= coveredTwice)
            {
                continue;
            }

            if (interval[0] <= lastEnd)
            {
                coveredTwice = lastEnd;
            }

            lastEnd = interval[1];
            chosen++;
        }

        return chosen;
    }
}
