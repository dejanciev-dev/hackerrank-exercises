namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Flatland Space Stations — the maximum distance from any of <c>n</c> cities to its nearest
/// space station. The worst city is at one end or halfway between two adjacent stations.
/// https://www.hackerrank.com/challenges/flatland-space-stations
/// </summary>
public static class FlatlandSpaceStations
{
    public static int Solve(int n, IReadOnlyList<int> c)
    {
        var stations = c.Order().ToArray();
        int best = Math.Max(stations[0], n - 1 - stations[^1]);

        for (int i = 1; i < stations.Length; i++)
        {
            best = Math.Max(best, (stations[i] - stations[i - 1]) / 2);
        }

        return best;
    }
}
