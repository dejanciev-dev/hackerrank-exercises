namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Task Scheduling — tasks arrive one by one, each with a deadline and a duration in minutes.
/// After each arrival, report the smallest possible value of the largest overshoot (finish time
/// minus deadline, never below 0) when the tasks that have arrived so far are run back to back
/// in the best order.
/// The best order is by deadline, so a task finishes at the total duration of every task whose
/// deadline is at most its own. A segment tree indexed by deadline holds, for each deadline d,
/// "total duration of tasks due by d minus d": adding a task of duration m with deadline d adds m
/// to every position from d onwards, and the answer is the tree-wide maximum. O(n log n).
/// https://www.hackerrank.com/challenges/task-scheduling
/// </summary>
public static class TaskScheduling
{
    /// <param name="tasks">Each task as its deadline and its duration in minutes, in arrival order.</param>
    /// <returns>The minimal maximum overshoot after each task has arrived.</returns>
    public static int[] Solve(IReadOnlyList<(int Deadline, int Minutes)> tasks)
    {
        int size = tasks.Count == 0 ? 1 : tasks.Max(t => t.Deadline);

        // best[node] is the maximum of its range including the node's own pending addition.
        var best = new long[4 * size];
        var added = new long[4 * size];
        Build(best, 1, 1, size);

        var result = new int[tasks.Count];
        for (int i = 0; i < tasks.Count; i++)
        {
            Add(best, added, 1, 1, size, tasks[i].Deadline, size, tasks[i].Minutes);
            result[i] = (int)Math.Max(0, best[1]);
        }

        return result;
    }

    private static void Build(long[] best, int node, int lo, int hi)
    {
        if (lo == hi)
        {
            best[node] = -lo;
            return;
        }

        int mid = (lo + hi) / 2;
        Build(best, 2 * node, lo, mid);
        Build(best, 2 * node + 1, mid + 1, hi);
        best[node] = Math.Max(best[2 * node], best[2 * node + 1]);
    }

    private static void Add(long[] best, long[] added, int node, int lo, int hi, int from, int to, int value)
    {
        if (from > hi || to < lo)
        {
            return;
        }

        if (from <= lo && hi <= to)
        {
            best[node] += value;
            added[node] += value;
            return;
        }

        int mid = (lo + hi) / 2;
        Add(best, added, 2 * node, lo, mid, from, to, value);
        Add(best, added, 2 * node + 1, mid + 1, hi, from, to, value);
        best[node] = Math.Max(best[2 * node], best[2 * node + 1]) + added[node];
    }
}
