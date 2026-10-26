namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Sequence Equation — for each x in 1..n find y such that p(p(y)) = x.
/// Applying the inverse permutation twice gives y directly.
/// https://www.hackerrank.com/challenges/permutation-equation
/// </summary>
public static class SequenceEquation
{
    public static int[] Solve(IReadOnlyList<int> p)
    {
        int n = p.Count;
        var position = new int[n + 1]; // position[v] = 1-based index of v in p

        for (int i = 0; i < n; i++)
        {
            position[p[i]] = i + 1;
        }

        var result = new int[n];
        for (int x = 1; x <= n; x++)
        {
            result[x - 1] = position[position[x]];
        }

        return result;
    }
}
