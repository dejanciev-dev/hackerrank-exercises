namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Permuting Two Arrays — can A and B be permuted so A[i] + B[i] ≥ k for all i? Pairing the
/// smallest of A with the largest of B is optimal, so sort them in opposite orders and check.
/// https://www.hackerrank.com/challenges/two-arrays
/// </summary>
public static class PermutingTwoArrays
{
    public static string Solve(int k, IReadOnlyList<int> a, IReadOnlyList<int> b)
    {
        var ascending = a.Order().ToArray();
        var descending = b.OrderDescending().ToArray();

        for (int i = 0; i < ascending.Length; i++)
        {
            if ((long)ascending[i] + descending[i] < k)
            {
                return "NO";
            }
        }

        return "YES";
    }
}
