namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Lily's Homework — the "beautiful" array is the sorted one, ascending or descending. Return
/// the minimum swaps to reach either. Swapping each element straight into its final position
/// gives the minimum swaps for a target order.
/// https://www.hackerrank.com/challenges/lilys-homework
/// </summary>
public static class LilysHomework
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        return Math.Min(
            SwapsToMatch(arr, arr.Order().ToArray()),
            SwapsToMatch(arr, arr.OrderDescending().ToArray()));
    }

    private static int SwapsToMatch(IReadOnlyList<int> arr, int[] target)
    {
        var current = arr.ToArray();
        var position = new Dictionary<int, int>();
        for (int i = 0; i < current.Length; i++)
        {
            position[current[i]] = i;
        }

        int swaps = 0;
        for (int i = 0; i < current.Length; i++)
        {
            if (current[i] == target[i])
            {
                continue;
            }

            int from = position[target[i]];
            position[current[i]] = from;
            position[target[i]] = i;
            (current[i], current[from]) = (current[from], current[i]);
            swaps++;
        }

        return swaps;
    }
}
