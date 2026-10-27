namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Filling Jars — each operation (a, b, k) adds k candies to jars a..b; return the floored
/// average over all <c>n</c> jars. Only the total matters: Σ (b - a + 1) · k, then divide.
/// https://www.hackerrank.com/challenges/filling-jars
/// </summary>
public static class FillingJars
{
    /// <param name="n">Number of jars.</param>
    /// <param name="operations">Each operation as <c>[a, b, k]</c>.</param>
    public static long Solve(int n, IReadOnlyList<IReadOnlyList<int>> operations)
    {
        long total = 0;
        foreach (var op in operations)
        {
            total += (long)(op[1] - op[0] + 1) * op[2];
        }

        return total / n;
    }
}
