namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Most Distant — every point lies on an axis; return the largest distance between two of
/// them. The farthest pair is either the two ends of the x-axis points, the two ends of the
/// y-axis points, or the point farthest from the origin on each axis (by Pythagoras). O(n).
/// https://www.hackerrank.com/challenges/most-distant
/// </summary>
public static class MostDistant
{
    public static double Solve(IReadOnlyList<IReadOnlyList<int>> coordinates)
    {
        long minX = long.MaxValue, maxX = long.MinValue, farX = -1;
        long minY = long.MaxValue, maxY = long.MinValue, farY = -1;

        foreach (var point in coordinates)
        {
            long x = point[0];
            long y = point[1];

            if (y == 0)
            {
                minX = Math.Min(minX, x);
                maxX = Math.Max(maxX, x);
                farX = Math.Max(farX, Math.Abs(x));
            }

            if (x == 0)
            {
                minY = Math.Min(minY, y);
                maxY = Math.Max(maxY, y);
                farY = Math.Max(farY, Math.Abs(y));
            }
        }

        double best = 0;
        if (farX >= 0)
        {
            best = Math.Max(best, maxX - minX);
        }

        if (farY >= 0)
        {
            best = Math.Max(best, maxY - minY);
        }

        if (farX >= 0 && farY >= 0)
        {
            best = Math.Max(best, Math.Sqrt((double)farX * farX + (double)farY * farY));
        }

        return best;
    }
}
