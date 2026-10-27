namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Minimum Swaps 2 — fewest swaps to sort a permutation of 1..n. The permutation splits into
/// cycles, and a cycle of length L needs L - 1 swaps; count them in one pass by following
/// each unvisited cycle. O(n).
/// https://www.hackerrank.com/challenges/minimum-swaps-2
/// </summary>
public static class MinimumSwaps2
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        var visited = new bool[arr.Count];
        int swaps = 0;

        for (int i = 0; i < arr.Count; i++)
        {
            int length = 0;
            for (int j = i; !visited[j]; j = arr[j] - 1)
            {
                visited[j] = true;
                length++;
            }

            if (length > 0)
            {
                swaps += length - 1;
            }
        }

        return swaps;
    }
}
