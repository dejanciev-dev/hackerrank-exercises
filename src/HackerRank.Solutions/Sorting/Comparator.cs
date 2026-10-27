namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Sorting: Comparator — order players by score descending, then by name ascending (ordinal).
/// https://www.hackerrank.com/challenges/ctci-comparator-sorting
/// </summary>
public static class Comparator
{
    public static (string Name, int Score)[] Solve(IReadOnlyList<(string Name, int Score)> players) =>
        players
            .OrderByDescending(p => p.Score)
            .ThenBy(p => p.Name, StringComparer.Ordinal)
            .ToArray();
}
