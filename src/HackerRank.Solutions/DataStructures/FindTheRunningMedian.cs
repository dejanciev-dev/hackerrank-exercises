namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Find the Running Median — the median after each new value. Keep the lower half in a
/// max-heap and the upper half in a min-heap, rebalanced so the lower half is never smaller;
/// the median is then at the heap tops. O(log n) per value.
/// https://www.hackerrank.com/challenges/find-the-running-median
/// </summary>
public static class FindTheRunningMedian
{
    public static double[] Solve(IReadOnlyList<int> a)
    {
        // PriorityQueue is a min-heap, so the lower half is keyed by the negated value.
        var lower = new PriorityQueue<int, int>();
        var upper = new PriorityQueue<int, int>();
        var medians = new double[a.Count];

        for (int i = 0; i < a.Count; i++)
        {
            int value = a[i];

            if (lower.Count == 0 || value <= lower.Peek())
            {
                lower.Enqueue(value, -value);
            }
            else
            {
                upper.Enqueue(value, value);
            }

            if (lower.Count > upper.Count + 1)
            {
                int moved = lower.Dequeue();
                upper.Enqueue(moved, moved);
            }
            else if (upper.Count > lower.Count)
            {
                int moved = upper.Dequeue();
                lower.Enqueue(moved, -moved);
            }

            medians[i] = lower.Count > upper.Count
                ? lower.Peek()
                : (lower.Peek() + (double)upper.Peek()) / 2;
        }

        return medians;
    }
}
