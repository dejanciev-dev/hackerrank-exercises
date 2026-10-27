namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Maximum bipartite matching by Kuhn's augmenting paths, O(V · E), shared by the
/// assignment problems.
/// </summary>
internal static class BipartiteMatching
{
    /// <param name="left">Number of left vertices.</param>
    /// <param name="right">Number of right vertices.</param>
    /// <param name="canPair">Whether left vertex i may be matched with right vertex j.</param>
    public static int MaxMatching(int left, int right, Func<int, int, bool> canPair)
    {
        var adjacency = new List<int>[left];
        for (int i = 0; i < left; i++)
        {
            adjacency[i] = Enumerable.Range(0, right).Where(j => canPair(i, j)).ToList();
        }

        var owner = new int[right];
        Array.Fill(owner, -1);
        int matched = 0;

        for (int i = 0; i < left; i++)
        {
            if (TryAugment(adjacency, i, owner, new bool[right]))
            {
                matched++;
            }
        }

        return matched;
    }

    private static bool TryAugment(List<int>[] adjacency, int vertex, int[] owner, bool[] visited)
    {
        foreach (var j in adjacency[vertex])
        {
            if (visited[j])
            {
                continue;
            }

            visited[j] = true;
            if (owner[j] == -1 || TryAugment(adjacency, owner[j], owner, visited))
            {
                owner[j] = vertex;
                return true;
            }
        }

        return false;
    }
}
