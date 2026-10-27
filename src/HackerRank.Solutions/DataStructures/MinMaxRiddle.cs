namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Min Max Riddle — for every window size w, the maximum over all windows of size w of the
/// window minimum. Monotonic stacks give each element the widest window in which it's the
/// minimum. That element then answers that width, and smaller widths inherit the best of
/// larger ones. O(n).
/// https://www.hackerrank.com/challenges/min-max-riddle
/// </summary>
public static class MinMaxRiddle
{
    public static long[] Solve(IReadOnlyList<long> arr)
    {
        int n = arr.Count;
        var left = new int[n];  // index of the previous smaller element, or -1
        var right = new int[n]; // index of the next smaller element, or n
        var stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
            {
                stack.Pop();
            }

            left[i] = stack.Count > 0 ? stack.Peek() : -1;
            stack.Push(i);
        }

        stack.Clear();
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
            {
                stack.Pop();
            }

            right[i] = stack.Count > 0 ? stack.Peek() : n;
            stack.Push(i);
        }

        var best = new long[n + 1];
        Array.Fill(best, long.MinValue);
        for (int i = 0; i < n; i++)
        {
            int width = right[i] - left[i] - 1;
            best[width] = Math.Max(best[width], arr[i]);
        }

        for (int width = n - 1; width >= 1; width--)
        {
            best[width] = Math.Max(best[width], best[width + 1]);
        }

        return best[1..];
    }
}
