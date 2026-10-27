namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Kth Ancestor — a tree that grows ("0 Y X": add X as a child of Y) and loses leaves
/// ("1 X"), with queries "2 X K" for the k-th ancestor of X (0 if there is none or X is
/// absent). Binary lifting: when a node is added, its 2^j-th ancestors are filled in from
/// its parent's, so each query takes O(log n) jumps.
/// https://www.hackerrank.com/challenges/kth-ancestor
/// </summary>
public static class KthAncestor
{
    private const int Levels = 17;

    /// <param name="edges">Initial tree as <c>[node, parent]</c>, with parent 0 for the root.</param>
    /// <param name="queries">The operations, in order.</param>
    public static long[] Solve(IReadOnlyList<IReadOnlyList<int>> edges, IReadOnlyList<string> queries)
    {
        var up = new Dictionary<int, int[]>();
        var answers = new List<long>();

        void Add(int node, int parent)
        {
            var jumps = new int[Levels];
            jumps[0] = parent;
            for (int j = 1; j < Levels; j++)
            {
                jumps[j] = jumps[j - 1] == 0 ? 0 : up[jumps[j - 1]][j - 1];
            }

            up[node] = jumps;
        }

        // Add the initial nodes parents-first.
        var children = edges.ToLookup(e => e[1], e => e[0]);
        var pending = new Queue<int>(children[0]);
        foreach (var root in children[0])
        {
            Add(root, 0);
        }

        while (pending.Count > 0)
        {
            int node = pending.Dequeue();
            foreach (var child in children[node])
            {
                Add(child, node);
                pending.Enqueue(child);
            }
        }

        foreach (var query in queries)
        {
            var parts = query.Split(' ').Select(int.Parse).ToArray();
            switch (parts[0])
            {
                case 0:
                    Add(parts[2], parts[1]);
                    break;
                case 1:
                    up.Remove(parts[1]);
                    break;
                default:
                    answers.Add(Ancestor(up, parts[1], parts[2]));
                    break;
            }
        }

        return answers.ToArray();
    }

    private static int Ancestor(Dictionary<int, int[]> up, int node, int k)
    {
        if (!up.ContainsKey(node))
        {
            return 0;
        }

        for (int j = 0; k > 0 && node != 0; j++, k >>= 1)
        {
            if (j >= Levels)
            {
                return 0;
            }

            if ((k & 1) == 1)
            {
                node = up[node][j];
            }
        }

        return k > 0 ? 0 : node;
    }
}
