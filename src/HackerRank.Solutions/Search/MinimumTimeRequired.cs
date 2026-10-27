namespace HackerRank.Solutions.Search;

/// <summary>
/// Minimum Time Required — machine i makes one item every machines[i] days; fewest days to
/// make <c>goal</c> items. Output by day d is Σ ⌊d / machines[i]⌋, which never decreases as
/// d grows, so binary search d. The fastest machine alone gives the upper bound.
/// O(n log(goal · min)).
/// https://www.hackerrank.com/challenges/minimum-time-required
/// </summary>
public static class MinimumTimeRequired
{
    public static long Solve(IReadOnlyList<long> machines, long goal)
    {
        long low = 1;
        long high = machines.Min() * goal;

        while (low < high)
        {
            long days = low + (high - low) / 2;
            long made = 0;
            foreach (var machine in machines)
            {
                made += days / machine;
                if (made >= goal)
                {
                    break;
                }
            }

            if (made >= goal)
            {
                high = days;
            }
            else
            {
                low = days + 1;
            }
        }

        return low;
    }
}
