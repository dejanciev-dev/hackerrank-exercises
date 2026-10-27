namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Find Maximum Index Product — for each i, multiply the 1-based indices of the nearest
/// strictly larger element on the left and on the right (0 when there isn't one); return the
/// largest product. Two monotonic-stack passes find all the nearest larger elements. O(n).
/// https://www.hackerrank.com/challenges/find-maximum-index-product
/// </summary>
public static class FindMaximumIndexProduct
{
    public static long Solve(IReadOnlyList<int> arr)
    {
        int n = arr.Count;
        var left = new long[n];
        var right = new long[n];
        var stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek()] <= arr[i])
            {
                stack.Pop();
            }

            left[i] = stack.Count > 0 ? stack.Peek() + 1 : 0;
            stack.Push(i);
        }

        stack.Clear();
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && arr[stack.Peek()] <= arr[i])
            {
                stack.Pop();
            }

            right[i] = stack.Count > 0 ? stack.Peek() + 1 : 0;
            stack.Push(i);
        }

        long best = 0;
        for (int i = 0; i < n; i++)
        {
            best = Math.Max(best, left[i] * right[i]);
        }

        return best;
    }
}
