namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Largest Permutation — with at most <c>k</c> swaps, make the permutation of 1..n as large as
/// possible: put n first, then n - 1, and so on. A position index makes each swap O(1).
/// https://www.hackerrank.com/challenges/largest-permutation
/// </summary>
public static class LargestPermutation
{
    public static int[] Solve(int k, IReadOnlyList<int> arr)
    {
        var result = arr.ToArray();
        int n = result.Length;
        var position = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            position[result[i]] = i;
        }

        for (int i = 0; i < n && k > 0; i++)
        {
            int wanted = n - i;
            if (result[i] == wanted)
            {
                continue;
            }

            int from = position[wanted];
            position[result[i]] = from;
            position[wanted] = i;
            (result[i], result[from]) = (result[from], result[i]);
            k--;
        }

        return result;
    }
}
