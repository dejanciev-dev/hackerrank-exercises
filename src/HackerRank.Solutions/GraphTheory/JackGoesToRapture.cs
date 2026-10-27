namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Jack goes to Rapture — the fare along a path is its most expensive edge; find the cheapest
/// fare from station 1 to station n. Add edges cheapest first (as in Kruskal) until 1 and n
/// are connected; the last edge added is the answer.
/// https://www.hackerrank.com/challenges/jack-goes-to-rapture
/// </summary>
public static class JackGoesToRapture
{
    /// <param name="n">Number of stations, labelled 1..n.</param>
    /// <param name="edges">Each edge as <c>[from, to, fare]</c>.</param>
    public static string Solve(int n, IReadOnlyList<IReadOnlyList<int>> edges)
    {
        var set = new DisjointSet(n + 1);

        foreach (var edge in edges.OrderBy(e => e[2]))
        {
            set.Union(edge[0], edge[1]);
            if (set.Find(1) == set.Find(n))
            {
                return edge[2].ToString();
            }
        }

        return n == 1 ? "0" : "NO PATH EXISTS";
    }
}
