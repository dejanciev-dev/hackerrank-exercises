namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Kitty and Katty — starting from 1..n, a move replaces two numbers a, b with a - b. Kitty
/// (who moves first) wins if the last number is 1 mod 3, Katty if it's 2, and whoever moved
/// last if it's 0. With one number Kitty wins outright; otherwise the player who makes the
/// last move can always force a win, so the parity of the n - 1 moves decides.
/// https://www.hackerrank.com/challenges/kitty-and-katty
/// </summary>
public static class KittyAndKatty
{
    public static string Solve(int n) => n == 1 || n % 2 == 0 ? "Kitty" : "Katty";
}
