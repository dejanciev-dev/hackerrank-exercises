namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Sherlock and Cost — choose A[i] in [1, B[i]] to maximize Σ|A[i] - A[i-1]|. An optimal A only
/// ever uses the extremes 1 or B[i], so track the best total ending low and ending high. O(n).
/// https://www.hackerrank.com/challenges/sherlock-and-cost
/// </summary>
public static class SherlockAndCost
{
    public static long Solve(IReadOnlyList<int> b)
    {
        long low = 0;  // best total with A[i - 1] = 1
        long high = 0; // best total with A[i - 1] = B[i - 1]

        for (int i = 1; i < b.Count; i++)
        {
            long nextLow = Math.Max(low, high + Math.Abs(b[i - 1] - 1));
            long nextHigh = Math.Max(low + Math.Abs(b[i] - 1), high + Math.Abs(b[i] - b[i - 1]));
            (low, high) = (nextLow, nextHigh);
        }

        return Math.Max(low, high);
    }
}
