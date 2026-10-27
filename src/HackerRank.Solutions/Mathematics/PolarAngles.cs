namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Polar Angles — sort points by polar angle measured anticlockwise from the positive x-axis,
/// then by distance from the origin. Angles are compared exactly, with no floating point:
/// first by half-plane (upper half, including the positive x-axis, comes first), then by
/// the sign of the cross product.
/// https://www.hackerrank.com/challenges/polar-angles
/// </summary>
public static class PolarAngles
{
    public static int[][] Solve(IReadOnlyList<IReadOnlyList<int>> points)
    {
        var sorted = points.Select(p => new[] { p[0], p[1] }).ToArray();
        Array.Sort(sorted, Compare);
        return sorted;
    }

    private static int Compare(int[] a, int[] b)
    {
        int halfA = Half(a);
        int halfB = Half(b);
        if (halfA != halfB)
        {
            return halfA.CompareTo(halfB);
        }

        long cross = (long)a[0] * b[1] - (long)a[1] * b[0];
        if (cross != 0)
        {
            return cross > 0 ? -1 : 1;
        }

        return SquaredLength(a).CompareTo(SquaredLength(b));
    }

    /// <summary>0 for angles in [0, π), 1 for [π, 2π).</summary>
    private static int Half(int[] p) => p[1] < 0 || (p[1] == 0 && p[0] < 0) ? 1 : 0;

    private static long SquaredLength(int[] p) => (long)p[0] * p[0] + (long)p[1] * p[1];
}
