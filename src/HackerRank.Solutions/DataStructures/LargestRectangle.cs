namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Largest Rectangle — largest rectangle that fits under a skyline of adjacent buildings.
/// A monotonic stack of increasing heights finds each bar's maximal width in O(n) overall.
/// https://www.hackerrank.com/challenges/largest-rectangle
/// </summary>
public static class LargestRectangle
{
    public static long Solve(IReadOnlyList<int> h)
    {
        var stack = new Stack<int>(); // indices of bars with increasing heights
        long best = 0;

        for (int i = 0; i <= h.Count; i++)
        {
            int height = i == h.Count ? 0 : h[i]; // the sentinel 0 flushes the stack at the end

            while (stack.Count > 0 && h[stack.Peek()] >= height)
            {
                long barHeight = h[stack.Pop()];
                int left = stack.Count == 0 ? -1 : stack.Peek();
                best = Math.Max(best, barHeight * (i - left - 1));
            }

            stack.Push(i);
        }

        return best;
    }
}
