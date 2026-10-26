namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Max Min — choose <c>k</c> elements minimizing max - min. The best choice is always
/// <c>k</c> consecutive elements of the sorted array, so slide a window over it.
/// https://www.hackerrank.com/challenges/angry-children
/// </summary>
public static class MaxMin
{
    public static int Solve(int k, IReadOnlyList<int> arr)
    {
        var sorted = arr.Order().ToArray();
        int best = int.MaxValue;

        for (int i = 0; i + k - 1 < sorted.Length; i++)
        {
            best = Math.Min(best, sorted[i + k - 1] - sorted[i]);
        }

        return best;
    }
}
