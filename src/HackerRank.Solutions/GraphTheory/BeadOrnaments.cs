namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Beautiful Bead Ornaments — count the trees on all the beads where each colour's beads
/// form a connected subtree, modulo 1e9+7. Each colour is a labelled tree, b^(b-2) ways by
/// Cayley's formula. The colour groups are then joined into a tree, and the generalised
/// Cayley formula counts those joins as S^(k-2) · Π b_i (S = total beads). Altogether:
/// Π b_i^(b_i - 1) · S^(k-2). With one colour it's just b^(b-2).
/// https://www.hackerrank.com/challenges/beautiful-bead-ornaments
/// </summary>
public static class BeadOrnaments
{
    private const long Mod = 1_000_000_007;

    public static long Solve(IReadOnlyList<int> b)
    {
        if (b.Count == 1)
        {
            return b[0] < 2 ? 1 : Mathematics.ModularMath.Power(b[0], b[0] - 2, Mod);
        }

        long total = b.Sum(c => (long)c);
        long ways = Mathematics.ModularMath.Power(total, b.Count - 2, Mod);

        foreach (var count in b)
        {
            ways = ways * Mathematics.ModularMath.Power(count, count - 1, Mod) % Mod;
        }

        return ways;
    }
}
