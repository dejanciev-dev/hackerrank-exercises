namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Poker Nim — Nim where a player may also add chips to a pile (at most <c>k</c> times). Adding
/// doesn't help: the winner just takes the added chips back, and the move limit stops the game
/// running forever. So it's ordinary Nim, decided by the nim-sum.
/// https://www.hackerrank.com/challenges/poker-nim-1
/// </summary>
public static class PokerNim
{
    public static string Solve(int k, IReadOnlyList<int> c) =>
        c.Aggregate(0, (nimSum, chips) => nimSum ^ chips) != 0 ? "First" : "Second";
}
