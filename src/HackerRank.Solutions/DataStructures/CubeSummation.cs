namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Cube Summation — on an n³ cube, "UPDATE x y z W" sets a cell and "QUERY x1 y1 z1 x2 y2 z2"
/// sums a box. A 3D Fenwick tree stores the cells. An update adds the difference from the
/// cell's old value (kept in a dictionary), and a box sum combines eight prefix sums by
/// inclusion–exclusion. O(log³ n) per operation.
/// https://www.hackerrank.com/challenges/cube-summation
/// </summary>
public static class CubeSummation
{
    public static long[] Solve(int n, IReadOnlyList<string> operations)
    {
        var tree = new long[n + 1, n + 1, n + 1];
        var cells = new Dictionary<(int, int, int), long>();
        var sums = new List<long>();

        void Add(int x, int y, int z, long delta)
        {
            for (int i = x; i <= n; i += i & -i)
                for (int j = y; j <= n; j += j & -j)
                    for (int k = z; k <= n; k += k & -k)
                        tree[i, j, k] += delta;
        }

        long Prefix(int x, int y, int z)
        {
            long sum = 0;
            for (int i = x; i > 0; i -= i & -i)
                for (int j = y; j > 0; j -= j & -j)
                    for (int k = z; k > 0; k -= k & -k)
                        sum += tree[i, j, k];
            return sum;
        }

        foreach (var operation in operations)
        {
            var parts = operation.Split(' ');
            var v = parts.Skip(1).Select(long.Parse).ToArray();

            if (parts[0] == "UPDATE")
            {
                var cell = ((int)v[0], (int)v[1], (int)v[2]);
                Add(cell.Item1, cell.Item2, cell.Item3, v[3] - cells.GetValueOrDefault(cell));
                cells[cell] = v[3];
                continue;
            }

            int x1 = (int)v[0] - 1, y1 = (int)v[1] - 1, z1 = (int)v[2] - 1;
            int x2 = (int)v[3], y2 = (int)v[4], z2 = (int)v[5];

            sums.Add(Prefix(x2, y2, z2)
                - Prefix(x1, y2, z2) - Prefix(x2, y1, z2) - Prefix(x2, y2, z1)
                + Prefix(x1, y1, z2) + Prefix(x1, y2, z1) + Prefix(x2, y1, z1)
                - Prefix(x1, y1, z1));
        }

        return sums.ToArray();
    }
}
