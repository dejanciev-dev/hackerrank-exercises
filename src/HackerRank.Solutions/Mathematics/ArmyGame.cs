namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Army Game — fewest supply drops to cover an n x m grid, where a drop on a grid point
/// supplies the (up to) four cells around it. Each drop covers a 2x2 block: ⌈n/2⌉ · ⌈m/2⌉.
/// https://www.hackerrank.com/challenges/game-with-cells
/// </summary>
public static class ArmyGame
{
    public static long Solve(long n, long m) => (n + 1) / 2 * ((m + 1) / 2);
}
