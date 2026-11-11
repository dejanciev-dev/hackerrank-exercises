namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Balanced Forest — attach one new node to the tree, then cut two edges so that the three
/// resulting trees have equal sums. Find the smallest value the new node can hold, or −1.
/// Without the new node, that means two cuts leave parts {t, t, t − w} (or one cut leaves
/// {t, t} and the new node stands alone). For each cut subtree with sum s, the partner cut is
/// either an ancestor (part sums s, q − s, S − q) or a finished disjoint subtree (s, p,
/// S − s − p). Solving each case for two equal largest parts gives the exact q or p to look up
/// in the ancestor-sum multiset or the finished-sum set. O(n) expected.
/// https://www.hackerrank.com/challenges/balanced-forest
/// </summary>
public static class BalancedForest
{
    /// <param name="values">The value of each node, nodes numbered from 1.</param>
    /// <param name="edges">The tree's edges, each as <c>[u, v]</c>.</param>
    public static long Solve(IReadOnlyList<int> values, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        int n = values.Count;
        var adjacency = new List<int>[n];
        for (int v = 0; v < n; v++)
        {
            adjacency[v] = [];
        }

        foreach (var edge in edges)
        {
            adjacency[edge[0] - 1].Add(edge[1] - 1);
            adjacency[edge[1] - 1].Add(edge[0] - 1);
        }

        // Preorder from node 0, then subtree sums bottom-up.
        var parent = new int[n];
        var order = new List<int>(n) { 0 };
        parent[0] = -1;
        for (int i = 0; i < order.Count; i++)
        {
            foreach (int to in adjacency[order[i]])
            {
                if (to != parent[order[i]])
                {
                    parent[to] = order[i];
                    order.Add(to);
                }
            }
        }

        var sum = new long[n];
        for (int i = n - 1; i >= 0; i--)
        {
            int v = order[i];
            sum[v] += values[v];
            if (parent[v] >= 0)
            {
                sum[parent[v]] += sum[v];
            }
        }

        long total = sum[0], best = long.MaxValue;
        var ancestors = new Dictionary<long, int>();
        var finished = new HashSet<long>();

        // Iterative DFS: a non-negative entry enters a node, ~v leaves it.
        var stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count > 0)
        {
            int v = stack.Pop();
            if (v < 0)
            {
                v = ~v;
                if (--ancestors[sum[v]] == 0)
                {
                    ancestors.Remove(sum[v]);
                }

                finished.Add(sum[v]);
                continue;
            }

            if (v != 0)
            {
                Consider(sum[v]);
                ancestors[sum[v]] = ancestors.GetValueOrDefault(sum[v]) + 1;
                stack.Push(~v);
            }

            foreach (int to in adjacency[v])
            {
                if (to != parent[v])
                {
                    stack.Push(to);
                }
            }
        }

        return best == long.MaxValue ? -1 : best;

        void Consider(long s)
        {
            if (2 * s == total)
            {
                best = Math.Min(best, s);
            }

            // s is one of the two equal largest parts.
            if (3 * s >= total
                && (finished.Contains(s) || finished.Contains(total - 2 * s)
                    || ancestors.ContainsKey(2 * s) || ancestors.ContainsKey(total - s)))
            {
                best = Math.Min(best, 3 * s - total);
            }

            // s is the smallest part; the other two are t each.
            if ((total - s) % 2 == 0)
            {
                long t = (total - s) / 2;
                if (t >= s && (finished.Contains(t) || ancestors.ContainsKey(s + t)))
                {
                    best = Math.Min(best, t - s);
                }
            }
        }
    }
}
