namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Journey to the Moon — astronauts from the same country are linked by pairs; count the ways
/// to pick two astronauts from different countries. All pairs minus same-country pairs, with
/// country sizes from union-find.
/// https://www.hackerrank.com/challenges/journey-to-the-moon
/// </summary>
public static class JourneyToTheMoon
{
    public static long Solve(int n, IReadOnlyList<IReadOnlyList<int>> astronaut)
    {
        var set = new DisjointSet(n);
        foreach (var pair in astronaut)
        {
            set.Union(pair[0], pair[1]);
        }

        long pairs = (long)n * (n - 1) / 2;

        for (int i = 0; i < n; i++)
        {
            if (set.Find(i) == i)
            {
                long size = set.SizeOf(i);
                pairs -= size * (size - 1) / 2;
            }
        }

        return pairs;
    }
}
