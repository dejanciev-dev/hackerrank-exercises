namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Maximum Perimeter Triangle — the non-degenerate triangle with the largest perimeter (ties
/// broken by longest sides), as ascending side lengths, or [-1]. After sorting descending, the
/// best triangle with longest side a[i] uses a[i + 1] and a[i + 2], so return the first
/// triple that satisfies the triangle inequality. O(n log n).
/// https://www.hackerrank.com/challenges/maximum-perimeter-triangle
/// </summary>
public static class MaximumPerimeterTriangle
{
    public static int[] Solve(IReadOnlyList<int> sticks)
    {
        var sorted = sticks.OrderDescending().ToArray();

        for (int i = 0; i + 2 < sorted.Length; i++)
        {
            if ((long)sorted[i + 1] + sorted[i + 2] > sorted[i])
            {
                return [sorted[i + 2], sorted[i + 1], sorted[i]];
            }
        }

        return [-1];
    }
}
