using HackerRank.Solutions.GraphTheory;

namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Merging Communities — handle "M i j" (merge the communities of i and j) and "Q i" (report
/// the size of i's community). Union-find with sizes, nearly O(1) per query.
/// https://www.hackerrank.com/challenges/merging-communities
/// </summary>
public static class MergingCommunities
{
    public static int[] Solve(int n, IReadOnlyList<string> queries)
    {
        var set = new DisjointSet(n + 1);
        var sizes = new List<int>();

        foreach (var query in queries)
        {
            var parts = query.Split(' ');

            if (parts[0] == "M")
            {
                set.Union(int.Parse(parts[1]), int.Parse(parts[2]));
            }
            else
            {
                sizes.Add(set.SizeOf(int.Parse(parts[1])));
            }
        }

        return sizes.ToArray();
    }
}
