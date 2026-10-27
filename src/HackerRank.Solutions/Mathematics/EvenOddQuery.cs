namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Even Odd Query — find(x, y) is the power tower A[x]^(A[x+1]^(...A[y])) (or 1 when x &gt; y);
/// is it odd? The parity is the base's, unless the exponent is 0 (anything^0 = 1). The array
/// never has two zeros in a row, so the exponent is 0 exactly when A[x + 1] = 0. The result
/// is odd when x &gt; y, when A[x] is odd, or when x &lt; y and A[x + 1] = 0. O(1) per query.
/// https://www.hackerrank.com/challenges/even-odd-query
/// </summary>
public static class EvenOddQuery
{
    /// <param name="arr">The values, indexed from 1 by the queries.</param>
    /// <param name="queries">Each query as 1-based <c>[x, y]</c>.</param>
    public static string[] Solve(IReadOnlyList<int> arr, IReadOnlyList<IReadOnlyList<int>> queries) =>
        queries.Select(q =>
        {
            int x = q[0];
            int y = q[1];
            bool odd = x > y || arr[x - 1] % 2 == 1 || (x < y && arr[x] == 0);
            return odd ? "Odd" : "Even";
        }).ToArray();
}
