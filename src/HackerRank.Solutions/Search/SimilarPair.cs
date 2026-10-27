namespace HackerRank.Solutions.Search;

/// <summary>
/// Similar Pair — count pairs (a, b) where a is an ancestor of b and |a - b| ≤ k. Walk the
/// tree depth-first, keeping the current node's ancestors in a Fenwick tree indexed by node
/// value; on entering b, a range query counts the ancestors in [b - k, b + k].
/// O(n log n), iterative so deep trees are safe.
/// https://www.hackerrank.com/challenges/similarpair
/// </summary>
public static class SimilarPair
{
    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="k">Maximum allowed difference.</param>
    /// <param name="edges">Each edge as <c>[parent, child]</c>.</param>
    public static long Solve(int n, int k, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        var children = new List<int>[n + 1];
        var hasParent = new bool[n + 1];
        for (int i = 1; i <= n; i++)
        {
            children[i] = [];
        }

        foreach (var edge in edges)
        {
            children[edge[0]].Add(edge[1]);
            hasParent[edge[1]] = true;
        }

        int root = Enumerable.Range(1, n).First(i => !hasParent[i]);
        var fenwick = new long[n + 1];
        long pairs = 0;

        // Each entry is (node, entering); the exit entry removes the node from the ancestors.
        var stack = new Stack<(int Node, bool Entering)>();
        stack.Push((root, true));

        while (stack.Count > 0)
        {
            var (node, entering) = stack.Pop();

            if (!entering)
            {
                Add(fenwick, node, -1);
                continue;
            }

            pairs += Prefix(fenwick, Math.Min(n, node + k)) - Prefix(fenwick, Math.Max(0, node - k - 1));
            Add(fenwick, node, 1);
            stack.Push((node, false));

            foreach (var child in children[node])
            {
                stack.Push((child, true));
            }
        }

        return pairs;
    }

    private static void Add(long[] fenwick, int index, long delta)
    {
        for (; index < fenwick.Length; index += index & -index)
        {
            fenwick[index] += delta;
        }
    }

    private static long Prefix(long[] fenwick, int index)
    {
        long sum = 0;
        for (; index > 0; index -= index & -index)
        {
            sum += fenwick[index];
        }

        return sum;
    }
}
