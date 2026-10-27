using System.Text;

namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Roads in HackerLand — road weights are distinct powers of two, 2^c; return the sum of the
/// shortest distances between all pairs of cities, in binary. With such weights, every
/// shortest path runs along the minimum spanning tree. A tree edge 2^c that splits the tree
/// into parts of size s and n - s lies on s · (n - s) of those paths. Add up the bit counts,
/// then carry into a binary string. O(m log m).
/// https://www.hackerrank.com/challenges/johnland
/// </summary>
public static class RoadsInHackerland
{
    /// <param name="n">Number of cities, labelled 1..n.</param>
    /// <param name="roads">Each road as <c>[from, to, c]</c>, with weight 2^c.</param>
    public static string Solve(int n, IReadOnlyList<IReadOnlyList<int>> roads)
    {
        var set = new DisjointSet(n + 1);
        var tree = new List<(int To, int Bit)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            tree[i] = [];
        }

        int maxBit = 0;
        foreach (var road in roads.OrderBy(r => r[2]))
        {
            if (set.Union(road[0], road[1]))
            {
                tree[road[0]].Add((road[1], road[2]));
                tree[road[1]].Add((road[0], road[2]));
                maxBit = Math.Max(maxBit, road[2]);
            }
        }

        // Subtree sizes from a BFS order of the tree, walked backwards.
        var parent = new int[n + 1];
        var parentBit = new int[n + 1];
        var order = new List<int>(n) { 1 };
        for (int i = 0; i < order.Count; i++)
        {
            int city = order[i];
            foreach (var (to, bit) in tree[city])
            {
                if (to != parent[city])
                {
                    parent[to] = city;
                    parentBit[to] = bit;
                    order.Add(to);
                }
            }
        }

        var size = new long[n + 1];
        var bits = new long[maxBit + 64];

        for (int i = order.Count - 1; i > 0; i--)
        {
            int city = order[i];
            size[city]++;
            size[parent[city]] += size[city];
            bits[parentBit[city]] += size[city] * (n - size[city]);
        }

        for (int i = 0; i + 1 < bits.Length; i++)
        {
            bits[i + 1] += bits[i] / 2;
            bits[i] %= 2;
        }

        var binary = new StringBuilder();
        for (int i = bits.Length - 1; i >= 0; i--)
        {
            if (binary.Length > 0 || bits[i] != 0)
            {
                binary.Append(bits[i]);
            }
        }

        return binary.Length > 0 ? binary.ToString() : "0";
    }
}
