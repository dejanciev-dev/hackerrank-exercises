using HackerRank.Solutions.GraphTheory;

namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Super Maximum Cost Queries — a path's cost is its heaviest edge; for each query [L, R],
/// count the node pairs whose path cost lies in that range. Let f(x) be the number of pairs
/// whose cost is at most x. Adding edges in increasing weight joins components of sizes a
/// and b, adding a · b pairs, which tabulates f. Each query is then f(R) - f(L - 1) by
/// binary search. O((n + q) log n).
/// https://www.hackerrank.com/challenges/super-maximum-cost-queries
/// </summary>
public static class SuperMaximumCostQueries
{
    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="tree">Each edge as <c>[u, v, weight]</c>.</param>
    /// <param name="queries">Each query as <c>[L, R]</c>.</param>
    public static long[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> tree, IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var set = new DisjointSet(n + 1);
        var weights = new List<int>();
        var pairsUpTo = new List<long>();
        long pairs = 0;

        foreach (var edge in tree.OrderBy(e => e[2]))
        {
            pairs += (long)set.SizeOf(edge[0]) * set.SizeOf(edge[1]);
            set.Union(edge[0], edge[1]);

            if (weights.Count > 0 && weights[^1] == edge[2])
            {
                pairsUpTo[^1] = pairs;
            }
            else
            {
                weights.Add(edge[2]);
                pairsUpTo.Add(pairs);
            }
        }

        long PairsAtMost(long cost)
        {
            int index = weights.BinarySearch((int)Math.Clamp(cost, int.MinValue, int.MaxValue));
            index = index >= 0 ? index : ~index - 1;
            return index >= 0 ? pairsUpTo[index] : 0;
        }

        return queries.Select(q => PairsAtMost(q[1]) - PairsAtMost((long)q[0] - 1)).ToArray();
    }
}
