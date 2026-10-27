namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Game of Stones — players remove 2, 3 or 5 stones; whoever can't move loses. Working out
/// the winning and losing positions shows they repeat every 7, and the player to move loses
/// exactly when n mod 7 is 0 or 1.
/// https://www.hackerrank.com/challenges/game-of-stones-1
/// </summary>
public static class GameOfStones
{
    public static string Solve(int n) => n % 7 is 0 or 1 ? "Second" : "First";
}
