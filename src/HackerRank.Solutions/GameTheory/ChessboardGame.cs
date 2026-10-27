namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// A Chessboard Game — a coin on a 15x15 board moves (-2, ±1) or (±1, -2); whoever can't move
/// loses. Working out the winning and losing squares gives a period-4 pattern: the player to
/// move loses when both coordinates are 1 or 2 mod 4.
/// https://www.hackerrank.com/challenges/a-chessboard-game-1
/// </summary>
public static class ChessboardGame
{
    public static string Solve(int x, int y) => (x - 1) % 4 < 2 && (y - 1) % 4 < 2 ? "Second" : "First";
}
