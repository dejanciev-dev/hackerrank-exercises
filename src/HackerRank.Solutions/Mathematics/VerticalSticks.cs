namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Vertical Sticks — for a random ordering of the sticks, each stick's ray reaches back to
/// the nearest earlier stick at least as tall (or the wall); find the expected total ray
/// length. A stick with c sticks at least its height, itself included, has an expected ray
/// of (n + 1) / (c + 1) by symmetry. Linearity of expectation sums those. O(n²) here,
/// O(n log n) with sorting.
/// https://www.hackerrank.com/challenges/vertical-sticks
/// </summary>
public static class VerticalSticks
{
    public static double Solve(IReadOnlyList<int> y)
    {
        int n = y.Count;
        return y.Sum(height =>
        {
            int atLeast = y.Count(other => other >= height);
            return (n + 1.0) / (atLeast + 1);
        });
    }
}
