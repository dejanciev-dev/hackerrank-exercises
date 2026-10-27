using HackerRank.Solutions.GraphTheory;

namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Friend Circle Queries — after each "these two people are friends" query, report the size
/// of the largest friend circle. Union-find with sizes; IDs up to 10^9 are mapped to dense
/// indices on first sight. The largest size only ever grows. Nearly O(1) per query.
/// https://www.hackerrank.com/challenges/friend-circle-queries
/// </summary>
public static class MaxCircle
{
    public static int[] Solve(IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var index = new Dictionary<int, int>();
        var set = new DisjointSet(2 * queries.Count);
        var largest = new int[queries.Count];
        int best = 0;

        int Id(int person)
        {
            if (!index.TryGetValue(person, out int id))
            {
                id = index.Count;
                index[person] = id;
            }

            return id;
        }

        for (int q = 0; q < queries.Count; q++)
        {
            int a = Id(queries[q][0]);
            int b = Id(queries[q][1]);
            set.Union(a, b);
            best = Math.Max(best, set.SizeOf(a));
            largest[q] = best;
        }

        return largest;
    }
}
