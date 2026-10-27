namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Nimble Game — a move takes one coin from square i to any square to its left; whoever can't
/// move loses. Each coin is a Nim pile of size i, and pairs of coins on the same square cancel
/// out, so XOR the indices of squares holding an odd number of coins.
/// https://www.hackerrank.com/challenges/nimble-game-1
/// </summary>
public static class NimbleGame
{
    public static string Solve(IReadOnlyList<int> s)
    {
        int nimSum = 0;
        for (int i = 0; i < s.Count; i++)
        {
            if (s[i] % 2 == 1)
            {
                nimSum ^= i;
            }
        }

        return nimSum != 0 ? "First" : "Second";
    }
}
