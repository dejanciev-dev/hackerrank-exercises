namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// The Story of a Tree — Bob guesses parent/child pairs; Alice picks a random root. Return the
/// probability (as a reduced fraction) that at least <c>k</c> guesses are right. Count the
/// correct guesses for root 1, then reroot across each edge u → v. Only guesses about that
/// edge change: (u, v) becomes wrong and (v, u) becomes right. O(n + g).
/// https://www.hackerrank.com/challenges/the-story-of-a-tree
/// </summary>
public static class TheStoryOfATree
{
    /// <param name="n">Number of nodes, labelled 1..n.</param>
    /// <param name="edges">Undirected tree edges.</param>
    /// <param name="guesses">Each guess as <c>[parent, child]</c>.</param>
    /// <param name="k">Minimum number of correct guesses for Bob to win.</param>
    public static string Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges, IReadOnlyList<IReadOnlyList<int>> guesses, int k)
    {
        var adjacency = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            adjacency[i] = [];
        }

        foreach (var edge in edges)
        {
            adjacency[edge[0]].Add(edge[1]);
            adjacency[edge[1]].Add(edge[0]);
        }

        var guessed = guesses.Select(g => ((long)g[0] << 32) | (uint)g[1]).ToHashSet();
        bool Guessed(int parent, int child) => guessed.Contains(((long)parent << 32) | (uint)child);

        var parentOf = new int[n + 1];
        var order = new List<int>(n) { 1 };
        int correctAtRoot = 0;

        for (int i = 0; i < order.Count; i++)
        {
            int node = order[i];
            foreach (var next in adjacency[node])
            {
                if (next != parentOf[node])
                {
                    parentOf[next] = node;
                    order.Add(next);
                    if (Guessed(node, next))
                    {
                        correctAtRoot++;
                    }
                }
            }
        }

        var correct = new int[n + 1];
        correct[1] = correctAtRoot;
        int wins = 0;

        foreach (var node in order)
        {
            if (node != 1)
            {
                int parent = parentOf[node];
                correct[node] = correct[parent] - (Guessed(parent, node) ? 1 : 0) + (Guessed(node, parent) ? 1 : 0);
            }

            if (correct[node] >= k)
            {
                wins++;
            }
        }

        if (wins == 0)
        {
            return "0/1";
        }

        int g = (int)Mathematics.ModularMath.Gcd(wins, n);
        return $"{wins / g}/{n / g}";
    }
}
