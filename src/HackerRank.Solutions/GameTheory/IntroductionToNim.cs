namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Introduction to Nim Game — take any number of stones from one pile; whoever takes the last
/// stone wins. Bouton's theorem: the first player wins exactly when the XOR of the piles
/// (the nim-sum) is non-zero.
/// https://www.hackerrank.com/challenges/nim-game-1
/// </summary>
public static class IntroductionToNim
{
    public static string Solve(IReadOnlyList<int> pile) =>
        pile.Aggregate(0, (nimSum, stones) => nimSum ^ stones) != 0 ? "First" : "Second";
}
