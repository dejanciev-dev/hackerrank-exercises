namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Connecting Towns — routes from the first town to the last through a chain of towns, where
/// routes[i] roads join town i and town i + 1. Multiplication principle, modulo 1234567.
/// https://www.hackerrank.com/challenges/connecting-towns
/// </summary>
public static class ConnectingTowns
{
    private const long Mod = 1_234_567;

    public static long Solve(IReadOnlyList<int> routes)
    {
        long ways = 1;
        foreach (var roads in routes)
        {
            ways = ways * roads % Mod;
        }

        return ways;
    }
}
