namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Sherlock and Counting — count the integers K with 1 ≤ K ≤ N and K · (N − K) &gt; N.
/// K · (N − K) is a parabola that rises up to K = N / 2 and is symmetric around it, so the good
/// values form one block [m, N − m] where m is the smallest K with K · (N − K) &gt; N. m is found
/// by binary search on the rising half using exact integer arithmetic (no square roots), and the
/// block holds N − 2m + 1 values; when no K qualifies the answer is 0. O(log N).
/// https://www.hackerrank.com/challenges/sherlock-and-counting
/// </summary>
public static class SherlockAndCounting
{
    public static long Solve(long n)
    {
        long low = 1;
        long high = n / 2;

        // Is the middle value already too small? Then nothing qualifies.
        if (high < 1 || high * (n - high) <= n)
        {
            return 0;
        }

        while (low < high)
        {
            long mid = low + (high - low) / 2;
            if (mid * (n - mid) > n)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return n - 2 * low + 1;
    }
}
