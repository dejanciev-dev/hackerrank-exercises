namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Organizing Containers of Balls — swaps keep each container's size fixed, so sorting is
/// possible exactly when the multiset of container sizes equals the multiset of ball-type counts.
/// https://www.hackerrank.com/challenges/organizing-containers-of-balls
/// </summary>
public static class OrganizingContainers
{
    public static string Solve(IReadOnlyList<IReadOnlyList<int>> container)
    {
        int n = container.Count;
        var containerSizes = new long[n];
        var typeCounts = new long[n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                containerSizes[i] += container[i][j];
                typeCounts[j] += container[i][j];
            }
        }

        Array.Sort(containerSizes);
        Array.Sort(typeCounts);

        return containerSizes.SequenceEqual(typeCounts) ? "Possible" : "Impossible";
    }
}
