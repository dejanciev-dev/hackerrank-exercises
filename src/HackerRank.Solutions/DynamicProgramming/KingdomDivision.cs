namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Kingdom Division — ways to split a tree's cities between two brothers so that every city
/// has a neighbour belonging to the same brother, modulo 1e9+7. Tree DP with the root's
/// colour fixed. lonely(v) counts colourings of v's subtree where v has no same-coloured
/// child yet but every child is satisfied. all(v) counts every valid child arrangement. Then
/// happy(v) = all(v) - lonely(v), and the answer is 2 · happy(root).
/// https://www.hackerrank.com/challenges/kingdom-division
/// </summary>
public static class KingdomDivision
{
    private const long Mod = 1_000_000_007;

    public static long Solve(int n, IReadOnlyList<IReadOnlyList<int>> roads)
    {
        var adjacency = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            adjacency[i] = [];
        }

        foreach (var road in roads)
        {
            adjacency[road[0]].Add(road[1]);
            adjacency[road[1]].Add(road[0]);
        }

        var parent = new int[n + 1];
        var order = new List<int>(n) { 1 };
        for (int i = 0; i < order.Count; i++)
        {
            foreach (var next in adjacency[order[i]])
            {
                if (next != parent[order[i]])
                {
                    parent[next] = order[i];
                    order.Add(next);
                }
            }
        }

        var happy = new long[n + 1];  // v already has a same-coloured neighbour below it
        var lonely = new long[n + 1]; // v still needs its parent to share its colour

        for (int i = order.Count - 1; i >= 0; i--)
        {
            int v = order[i];
            long all = 1;
            long noneSame = 1;

            foreach (var child in adjacency[v])
            {
                if (child == parent[v])
                {
                    continue;
                }

                // A child of the other colour must be happy on its own; a same-coloured
                // child is satisfied by v either way.
                all = all * ((2 * happy[child] + lonely[child]) % Mod) % Mod;
                noneSame = noneSame * happy[child] % Mod;
            }

            lonely[v] = noneSame;
            happy[v] = (all - noneSame + Mod) % Mod;
        }

        return 2 * happy[1] % Mod;
    }
}
