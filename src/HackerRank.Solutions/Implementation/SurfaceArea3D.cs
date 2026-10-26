namespace HackerRank.Solutions.Implementation;

/// <summary>
/// 3D Surface Area — surface area of stacks of unit cubes on a grid. Every non-empty stack
/// shows its top and bottom, plus the part of each side that rises above its neighbor.
/// https://www.hackerrank.com/challenges/3d-surface-area
/// </summary>
public static class SurfaceArea3D
{
    private static readonly (int Row, int Col)[] Sides = [(1, 0), (-1, 0), (0, 1), (0, -1)];

    public static int Solve(IReadOnlyList<IReadOnlyList<int>> a)
    {
        int area = 0;

        for (int r = 0; r < a.Count; r++)
        {
            for (int c = 0; c < a[r].Count; c++)
            {
                int height = a[r][c];
                if (height > 0)
                {
                    area += 2;
                }

                foreach (var (dr, dc) in Sides)
                {
                    area += Math.Max(0, height - HeightAt(a, r + dr, c + dc));
                }
            }
        }

        return area;
    }

    private static int HeightAt(IReadOnlyList<IReadOnlyList<int>> a, int r, int c) =>
        r >= 0 && r < a.Count && c >= 0 && c < a[r].Count ? a[r][c] : 0;
}
