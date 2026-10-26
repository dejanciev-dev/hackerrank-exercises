namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Max Array Sum — largest sum of a subset with no two adjacent elements.
/// best(i) = max(best(i-1), best(i-2) + a[i], a[i]); only the last two values are kept.
/// https://www.hackerrank.com/challenges/max-array-sum
/// </summary>
public static class MaxArraySum
{
    public static long Solve(IReadOnlyList<int> arr)
    {
        long twoBack = arr[0];
        long oneBack = Math.Max(arr[0], arr.Count > 1 ? arr[1] : arr[0]);

        for (int i = 2; i < arr.Count; i++)
        {
            long current = Math.Max(Math.Max(oneBack, twoBack + arr[i]), arr[i]);
            (twoBack, oneBack) = (oneBack, current);
        }

        return oneBack;
    }
}
