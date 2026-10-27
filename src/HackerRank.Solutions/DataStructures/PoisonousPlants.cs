namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Poisonous Plants — each day every plant with more pesticide than its left neighbour dies;
/// how many days until none do? A plant dies one day after the last plant between it and its
/// nearest smaller-or-equal left neighbour has died. A monotonic stack of (pesticide, day of
/// death) finds that in O(n).
/// https://www.hackerrank.com/challenges/poisonous-plants
/// </summary>
public static class PoisonousPlants
{
    public static int Solve(IReadOnlyList<int> p)
    {
        var stack = new Stack<(int Pesticide, int DiesOn)>();
        int days = 0;

        foreach (var pesticide in p)
        {
            int lastDeathBetween = 0;
            while (stack.Count > 0 && stack.Peek().Pesticide >= pesticide)
            {
                lastDeathBetween = Math.Max(lastDeathBetween, stack.Pop().DiesOn);
            }

            // With no smaller plant to the left, this one never dies.
            int diesOn = stack.Count == 0 ? 0 : lastDeathBetween + 1;
            days = Math.Max(days, diesOn);
            stack.Push((pesticide, diesOn));
        }

        return days;
    }
}
