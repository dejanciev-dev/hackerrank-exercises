namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Array Manipulation — apply "add k to every element in [a, b]" queries to an array of n
/// zeros and return the maximum value. A difference array records each range in O(1), and a
/// single prefix-sum pass rebuilds the values: O(n + m) instead of O(n · m).
/// https://www.hackerrank.com/challenges/crush
/// </summary>
public static class ArrayManipulation
{
    public static long Solve(int n, IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var difference = new long[n + 2];

        foreach (var query in queries)
        {
            difference[query[0]] += query[2];
            difference[query[1] + 1] -= query[2];
        }

        long running = 0;
        long max = 0;

        for (int i = 1; i <= n; i++)
        {
            running += difference[i];
            max = Math.Max(max, running);
        }

        return max;
    }
}
