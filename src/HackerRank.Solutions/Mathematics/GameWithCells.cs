namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Game With Cells — a supply drop lands on a corner shared by up to four cells of an n × m
/// grid and feeds all of them; how many drops feed every cell?
/// Each drop covers at most a 2 × 2 block, and tiling with such blocks is optimal, so the
/// answer is ⌈n / 2⌉ · ⌈m / 2⌉. O(1).
/// https://www.hackerrank.com/challenges/game-with-cells
/// </summary>
public static class GameWithCells
{
    public static long Solve(long n, long m) => (n + 1) / 2 * ((m + 1) / 2);
}
