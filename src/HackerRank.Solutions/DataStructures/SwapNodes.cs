namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Swap Nodes [Algo] — for each query k, swap the children of every node at a depth that is a
/// multiple of k (swaps accumulate), then record the in-order traversal. The tree is stored as
/// child arrays; depths come from one BFS and traversals are iterative, so deep trees are safe.
/// https://www.hackerrank.com/challenges/swap-nodes-algo
/// </summary>
public static class SwapNodes
{
    /// <param name="indexes">Row i holds the <c>[left, right]</c> children of node i + 1; -1 for none.</param>
    /// <param name="queries">The depth multiples k to swap at.</param>
    public static int[][] Solve(IReadOnlyList<IReadOnlyList<int>> indexes, IReadOnlyList<int> queries)
    {
        int n = indexes.Count;
        var left = new int[n + 1];
        var right = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            left[i] = indexes[i - 1][0];
            right[i] = indexes[i - 1][1];
        }

        var depth = new int[n + 1];
        var order = new List<int>(n) { 1 };
        depth[1] = 1;

        for (int i = 0; i < order.Count; i++)
        {
            int node = order[i];
            foreach (var child in new[] { left[node], right[node] })
            {
                if (child != -1)
                {
                    depth[child] = depth[node] + 1;
                    order.Add(child);
                }
            }
        }

        var results = new int[queries.Count][];

        for (int q = 0; q < queries.Count; q++)
        {
            foreach (var node in order)
            {
                if (depth[node] % queries[q] == 0)
                {
                    (left[node], right[node]) = (right[node], left[node]);
                }
            }

            results[q] = Inorder(left, right, n);
        }

        return results;
    }

    private static int[] Inorder(int[] left, int[] right, int n)
    {
        var visited = new List<int>(n);
        var stack = new Stack<int>();
        int node = 1;

        while (node != -1 || stack.Count > 0)
        {
            for (; node != -1; node = left[node])
            {
                stack.Push(node);
            }

            node = stack.Pop();
            visited.Add(node);
            node = right[node];
        }

        return visited.ToArray();
    }
}
