namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Move the Coins — on a tree rooted at 1, a move takes one or more coins from a non-root node
/// to its parent, and a player with no move loses. Each query re-hangs u's subtree under v (an
/// independent change to the original tree). Print "INVALID" if v lies in u's subtree, else
/// "YES" if the first player wins.
/// This is staircase Nim: only coins at odd depths matter, and the position is lost exactly
/// when their XOR is 0. Re-hanging changes the parity of the whole subtree when depth(v) and
/// depth(u) have the same parity, which swaps its odd and even XORs. Euler-tour prefix XORs
/// give both per subtree. O(n + q).
/// https://www.hackerrank.com/challenges/move-the-coins
/// </summary>
public static class MoveTheCoins
{
    /// <param name="coins">The coins on each node, nodes numbered from 1.</param>
    /// <param name="edges">The tree's edges, each as <c>[a, b]</c>.</param>
    /// <param name="queries">Each query as <c>[u, v]</c>.</param>
    public static string[] Solve(
        IReadOnlyList<int> coins,
        IReadOnlyList<IReadOnlyList<int>> edges,
        IReadOnlyList<IReadOnlyList<int>> queries)
    {
        int n = coins.Count;
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

        // Euler tour: subtree of v occupies positions [enter[v], leave[v]).
        var depth = new int[n];
        var enter = new int[n];
        var leave = new int[n];
        var parent = new int[n];
        var xorByParity = new int[2, n + 1];
        int clock = 0;

        var stack = new Stack<int>();
        parent[0] = -1;
        stack.Push(0);
        while (stack.Count > 0)
        {
            int v = stack.Pop();
            if (v < 0)
            {
                leave[~v] = clock;
                continue;
            }

            enter[v] = clock;
            for (int parity = 0; parity < 2; parity++)
            {
                xorByParity[parity, clock + 1] = xorByParity[parity, clock] ^ (depth[v] % 2 == parity ? coins[v] : 0);
            }

            clock++;
            stack.Push(~v);
            foreach (int to in adjacency[v])
            {
                if (to != parent[v])
                {
                    parent[to] = v;
                    depth[to] = depth[v] + 1;
                    stack.Push(to);
                }
            }
        }

        int nimSum = xorByParity[1, n];
        var answers = new string[queries.Count];
        for (int i = 0; i < queries.Count; i++)
        {
            int u = queries[i][0] - 1, v = queries[i][1] - 1;
            if (enter[u] <= enter[v] && enter[v] < leave[u])
            {
                answers[i] = "INVALID";
                continue;
            }

            int result = nimSum;
            if (depth[u] % 2 == depth[v] % 2)
            {
                result ^= SubtreeXor(0, u) ^ SubtreeXor(1, u);
            }

            answers[i] = result != 0 ? "YES" : "NO";
        }

        return answers;

        int SubtreeXor(int parity, int v) => xorByParity[parity, leave[v]] ^ xorByParity[parity, enter[v]];
    }
}
