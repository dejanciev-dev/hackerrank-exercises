using System.Numerics;

namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Counter Game — players alternately halve a power of two or subtract the largest power of two
/// below n; Louise moves first and whoever reaches 1 wins. Both moves strip one bit from n - 1
/// (halving drops a trailing zero, subtracting clears the top bit), so the number of moves
/// is popcount(n - 1).
/// https://www.hackerrank.com/challenges/counter-game
/// </summary>
public static class CounterGame
{
    public static string Solve(long n)
    {
        int moves = BitOperations.PopCount((ulong)(n - 1));
        return moves % 2 == 1 ? "Louise" : "Richard";
    }
}
