namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Components in a graph — sizes of the smallest and largest connected components that have
/// at least two nodes. Union-find over the edge list.
/// https://www.hackerrank.com/challenges/components-in-graph
/// </summary>
public static class ComponentsInAGraph
{
    public static int[] Solve(IReadOnlyList<IReadOnlyList<int>> gb)
    {
        int maxNode = gb.Max(edge => Math.Max(edge[0], edge[1]));
        var set = new DisjointSet(maxNode + 1);

        foreach (var edge in gb)
        {
            set.Union(edge[0], edge[1]);
        }

        int smallest = int.MaxValue;
        int largest = 0;

        for (int node = 1; node <= maxNode; node++)
        {
            int size = set.SizeOf(node);
            if (set.Find(node) == node && size > 1)
            {
                smallest = Math.Min(smallest, size);
                largest = Math.Max(largest, size);
            }
        }

        return [smallest, largest];
    }
}
