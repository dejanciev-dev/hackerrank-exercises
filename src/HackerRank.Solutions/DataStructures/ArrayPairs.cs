namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Array Pairs — count the pairs of indices i &lt; j with a[i] * a[j] ≤ max(a[i..j]).
/// Split every range at its (leftmost) maximum m: each pair that straddles m has m as its
/// maximum, so it only needs a[i] * a[j] ≤ a[m]. Looping over the shorter side of the split and
/// counting partners on the other side that are at most a[m] / a[i] gives O(n log n) range
/// counting queries ("how many values ≤ v among positions x..y"), which are answered offline
/// with a Fenwick tree while the values are inserted in increasing order. O(n log² n).
/// https://www.hackerrank.com/challenges/array-pairs
/// </summary>
public static class ArrayPairs
{
    public static long Solve(IReadOnlyList<int> a)
    {
        int n = a.Count;
        if (n < 2)
        {
            return 0;
        }

        var argMax = BuildArgMaxTable(a);

        // Each query counts positions in [from, to] holding a value ≤ limit.
        var queries = new List<(long Limit, int From, int To)>();
        var ranges = new Stack<(int Lo, int Hi)>();
        ranges.Push((0, n - 1));

        while (ranges.Count > 0)
        {
            var (lo, hi) = ranges.Pop();
            if (lo >= hi)
            {
                continue;
            }

            int m = QueryArgMax(a, argMax, lo, hi);
            long top = a[m];

            if (m - lo <= hi - m)
            {
                for (int i = lo; i <= m; i++)
                {
                    queries.Add((top / a[i], i == m ? m + 1 : m, hi));
                }
            }
            else
            {
                for (int j = m; j <= hi; j++)
                {
                    queries.Add((top / a[j], lo, j == m ? m - 1 : m));
                }
            }

            ranges.Push((lo, m - 1));
            ranges.Push((m + 1, hi));
        }

        return CountOffline(a, queries);
    }

    private static long CountOffline(IReadOnlyList<int> a, List<(long Limit, int From, int To)> queries)
    {
        int n = a.Count;
        var byValue = Enumerable.Range(0, n).OrderBy(i => a[i]).ToArray();
        var ordered = queries.Where(q => q.From <= q.To).OrderBy(q => q.Limit).ToArray();

        var tree = new int[n + 1];
        long total = 0;
        int inserted = 0;

        foreach (var (limit, from, to) in ordered)
        {
            while (inserted < n && a[byValue[inserted]] <= limit)
            {
                for (int p = byValue[inserted] + 1; p <= n; p += p & -p)
                {
                    tree[p]++;
                }

                inserted++;
            }

            total += Prefix(tree, to + 1) - Prefix(tree, from);
        }

        return total;
    }

    private static int Prefix(int[] tree, int count)
    {
        int sum = 0;
        for (int p = count; p > 0; p -= p & -p)
        {
            sum += tree[p];
        }

        return sum;
    }

    // table[k][i] is the index of the leftmost maximum of a[i .. i + 2^k - 1].
    private static int[][] BuildArgMaxTable(IReadOnlyList<int> a)
    {
        int n = a.Count;
        var table = new List<int[]> { Enumerable.Range(0, n).ToArray() };

        for (int k = 1; (1 << k) <= n; k++)
        {
            var previous = table[k - 1];
            var row = new int[n - (1 << k) + 1];
            for (int i = 0; i < row.Length; i++)
            {
                int left = previous[i];
                int right = previous[i + (1 << (k - 1))];
                row[i] = a[right] > a[left] ? right : left;
            }

            table.Add(row);
        }

        return [.. table];
    }

    private static int QueryArgMax(IReadOnlyList<int> a, int[][] table, int lo, int hi)
    {
        int k = 31 - int.LeadingZeroCount(hi - lo + 1);
        int left = table[k][lo];
        int right = table[k][hi - (1 << k) + 1];
        return a[right] > a[left] ? right : left;
    }
}
