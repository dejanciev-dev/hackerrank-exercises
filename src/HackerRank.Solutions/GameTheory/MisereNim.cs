namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Misère Nim — Nim where whoever takes the last stone loses. Play is the same as normal Nim
/// until only piles of size 1 are left; if every pile starts at 1, the first player wins when
/// the number of piles is even. Otherwise the first player wins when the nim-sum is non-zero.
/// https://www.hackerrank.com/challenges/misere-nim-1
/// </summary>
public static class MisereNim
{
    public static string Solve(IReadOnlyList<int> s)
    {
        if (s.All(stones => stones == 1))
        {
            return s.Count % 2 == 0 ? "First" : "Second";
        }

        return s.Aggregate(0, (nimSum, stones) => nimSum ^ stones) != 0 ? "First" : "Second";
    }
}
