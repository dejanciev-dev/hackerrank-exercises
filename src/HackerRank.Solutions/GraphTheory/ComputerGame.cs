namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Computer Game — one number from A and one from B can be removed together when they share
/// a factor (gcd &gt; 1); find the most pairs that can be removed. That's a maximum bipartite
/// matching on the "shares a factor" relation.
/// https://www.hackerrank.com/challenges/computer-game
/// </summary>
public static class ComputerGame
{
    public static int Solve(IReadOnlyList<long> a, IReadOnlyList<long> b) =>
        BipartiteMatching.MaxMatching(a.Count, b.Count, (i, j) => Mathematics.ModularMath.Gcd(a[i], b[j]) > 1);
}
