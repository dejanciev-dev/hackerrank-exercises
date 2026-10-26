namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Knapsack (unbounded) — the largest sum not exceeding <c>k</c> using any number of copies of
/// each value. reachable[s] marks sums that can be formed exactly. O(k · n).
/// https://www.hackerrank.com/challenges/unbounded-knapsack
/// </summary>
public static class Knapsack
{
    public static int Solve(int k, IReadOnlyList<int> arr)
    {
        var reachable = new bool[k + 1];
        reachable[0] = true;

        for (int sum = 1; sum <= k; sum++)
        {
            foreach (var value in arr)
            {
                if (value <= sum && reachable[sum - value])
                {
                    reachable[sum] = true;
                    break;
                }
            }
        }

        return Array.LastIndexOf(reachable, true);
    }
}
