namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Problem solving — each day Emma solves problems in list order, where consecutive picks
/// must differ in rating by at least <c>k</c>; fewest days to solve them all. That's a
/// minimum path cover of the DAG i → j (i &lt; j, |v_i - v_j| ≥ k), which equals n minus a
/// maximum bipartite matching of the same pairs.
/// https://www.hackerrank.com/challenges/problem-solving
/// </summary>
public static class ProblemSolving
{
    public static int Solve(int k, IReadOnlyList<int> v) =>
        v.Count - BipartiteMatching.MaxMatching(v.Count, v.Count, (i, j) => i < j && Math.Abs(v[i] - v[j]) >= k);
}
