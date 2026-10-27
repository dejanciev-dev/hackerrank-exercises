namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Queries with Fixed Length — for each window size d, the minimum over all windows of the
/// window's maximum. A monotonic deque of indices gives every window maximum in O(n), so each
/// query is O(n).
/// https://www.hackerrank.com/challenges/queries-with-fixed-length
/// </summary>
public static class QueriesWithFixedLength
{
    public static int[] Solve(IReadOnlyList<int> arr, IReadOnlyList<int> queries) =>
        queries.Select(d => MinOfWindowMaxima(arr, d)).ToArray();

    private static int MinOfWindowMaxima(IReadOnlyList<int> arr, int d)
    {
        // Indices whose values decrease from front to back; the front is the window maximum.
        var window = new LinkedList<int>();
        int best = int.MaxValue;

        for (int i = 0; i < arr.Count; i++)
        {
            while (window.Count > 0 && arr[window.Last!.Value] <= arr[i])
            {
                window.RemoveLast();
            }

            window.AddLast(i);

            if (window.First!.Value <= i - d)
            {
                window.RemoveFirst();
            }

            if (i >= d - 1)
            {
                best = Math.Min(best, arr[window.First.Value]);
            }
        }

        return best;
    }
}
