namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Wet Shark and Two Subsequences — count pairs of equal-length subsequences (A, B) with
/// sum(A) + sum(B) = r and sum(A) - sum(B) = s, modulo 1e9+7. So sum(A) = (r + s) / 2 and
/// sum(B) = (r - s) / 2. A knapsack counts subsequences by (length, sum), and the answer is
/// Σ_len ways(len, sumA) · ways(len, sumB). O(m² · r).
/// https://www.hackerrank.com/challenges/wet-shark-and-two-subsequences
/// </summary>
public static class WetSharkAndTwoSubsequences
{
    private const long Mod = 1_000_000_007;

    public static long Solve(IReadOnlyList<int> x, int r, int s)
    {
        if ((r + s) % 2 != 0 || s > r)
        {
            return 0;
        }

        int sumA = (r + s) / 2;
        int sumB = (r - s) / 2;
        int maxSum = Math.Max(sumA, sumB);
        int m = x.Count;

        var ways = new long[m + 1, maxSum + 1];
        ways[0, 0] = 1;

        foreach (var value in x)
        {
            for (int length = m; length >= 1; length--)
            {
                for (int sum = maxSum; sum >= value; sum--)
                {
                    ways[length, sum] = (ways[length, sum] + ways[length - 1, sum - value]) % Mod;
                }
            }
        }

        long pairs = 0;
        for (int length = 1; length <= m; length++)
        {
            pairs = (pairs + ways[length, sumA] * ways[length, sumB]) % Mod;
        }

        return pairs;
    }
}
