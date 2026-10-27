namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Powers Game — players take turns picking any unsigned power among 2^1..2^n and putting
/// + or - in front of it; the second player wins if the final sum is divisible by 17. Since
/// 2^4 ≡ -1 (mod 17), the powers 4 apart cancel each other. When n is a multiple of 8 they
/// pair up completely, and the second player answers every move by cancelling it with its
/// partner. Otherwise the first player wins.
/// https://www.hackerrank.com/challenges/powers-game-1
/// </summary>
public static class PowersGame
{
    public static string Solve(int n) => n % 8 == 0 ? "Second" : "First";
}
