namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Play on benders — tokens sit on the nodes of a DAG; a move slides one token along an
/// edge, and whoever can't move loses. Bumi moves first. Each token is its own game, so XOR
/// the Grundy numbers of their nodes. A node's Grundy number is the mex of its successors',
/// computed in reverse topological order. O(n + m) to prepare, O(k) per query.
/// https://www.hackerrank.com/challenges/benders-play
/// </summary>
public static class PlayOnBenders
{
    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="edges">Directed edges as <c>[from, to]</c>; the graph is acyclic.</param>
    /// <param name="queries">For each game, the nodes holding a token.</param>
    public static string[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges, IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var successors = new List<int>[n + 1];
        var inDegree = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            successors[i] = [];
        }

        foreach (var edge in edges)
        {
            successors[edge[0]].Add(edge[1]);
            inDegree[edge[1]]++;
        }

        var order = new List<int>(n);
        var queue = new Queue<int>(Enumerable.Range(1, n).Where(i => inDegree[i] == 0));
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            order.Add(u);
            foreach (var v in successors[u])
            {
                if (--inDegree[v] == 0)
                {
                    queue.Enqueue(v);
                }
            }
        }

        var grundy = new int[n + 1];
        for (int i = order.Count - 1; i >= 0; i--)
        {
            int u = order[i];
            var seen = successors[u].Select(v => grundy[v]).ToHashSet();
            int mex = 0;
            while (seen.Contains(mex))
            {
                mex++;
            }

            grundy[u] = mex;
        }

        return queries
            .Select(tokens => tokens.Aggregate(0, (x, node) => x ^ grundy[node]) != 0 ? "Bumi" : "Iroh")
            .ToArray();
    }
}
