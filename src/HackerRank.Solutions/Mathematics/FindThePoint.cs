namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Find the Point — reflect point p through point q. q is the midpoint of p and the answer,
/// so the answer is 2q - p.
/// https://www.hackerrank.com/challenges/find-point
/// </summary>
public static class FindThePoint
{
    public static int[] Solve(int px, int py, int qx, int qy) => [2 * qx - px, 2 * qy - py];
}
