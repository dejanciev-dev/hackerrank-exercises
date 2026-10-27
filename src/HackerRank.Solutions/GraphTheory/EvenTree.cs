namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Even Tree — maximum number of edges to remove so every remaining component has an even
/// number of nodes. An edge can go exactly when the subtree below it is even-sized, so count
/// the non-root nodes with even subtree sizes. Iterative BFS order, O(n).
/// https://www.hackerrank.com/challenges/even-tree
/// </summary>
public static class EvenTree
{
    public static int Solve(int nodes, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        var adjacency = new List<int>[nodes + 1];
        for (int i = 1; i <= nodes; i++)
        {
            adjacency[i] = [];
        }

        foreach (var edge in edges)
        {
            adjacency[edge[0]].Add(edge[1]);
            adjacency[edge[1]].Add(edge[0]);
        }

        var parent = new int[nodes + 1];
        var order = new List<int>(nodes) { 1 };
        parent[1] = 0;

        for (int i = 0; i < order.Count; i++)
        {
            int node = order[i];
            foreach (var next in adjacency[node])
            {
                if (next != parent[node])
                {
                    parent[next] = node;
                    order.Add(next);
                }
            }
        }

        // Children come after their parent in BFS order, so walking it backwards finishes
        // every subtree before its parent needs the size.
        var size = new int[nodes + 1];
        int removable = 0;

        for (int i = order.Count - 1; i > 0; i--)
        {
            int node = order[i];
            size[node]++;
            size[parent[node]] += size[node];

            if (size[node] % 2 == 0)
            {
                removable++;
            }
        }

        return removable;
    }
}
