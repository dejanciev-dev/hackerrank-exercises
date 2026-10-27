namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Sherlock and Moving Tiles — two L x L squares start stacked and slide apart along the
/// diagonal at speeds s1 and s2; when does their overlap have area q? The overlap is a
/// square of side L - d, where d = t · |s1 - s2| / √2 is how far apart they are along each
/// axis. So t = (L - √q) · √2 / |s1 - s2|.
/// https://www.hackerrank.com/challenges/sherlock-and-moving-tiles
/// </summary>
public static class SherlockAndMovingTiles
{
    public static double[] Solve(long l, long s1, long s2, IReadOnlyList<long> queries) =>
        queries.Select(q => (l - Math.Sqrt(q)) * Math.Sqrt(2) / Math.Abs(s1 - s2)).ToArray();
}
