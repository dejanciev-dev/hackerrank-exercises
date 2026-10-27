namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Points On a Line — do all points lie on one horizontal or one vertical line? True when
/// they all share an x coordinate or all share a y coordinate.
/// https://www.hackerrank.com/challenges/points-on-a-line
/// </summary>
public static class PointsOnALine
{
    public static string Solve(IReadOnlyList<IReadOnlyList<int>> points)
    {
        bool vertical = points.All(p => p[0] == points[0][0]);
        bool horizontal = points.All(p => p[1] == points[0][1]);

        return vertical || horizontal ? "YES" : "NO";
    }
}
