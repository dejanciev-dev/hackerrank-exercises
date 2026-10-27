namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Little Ashish's Huge Donation — on day i he gives i² candies; for how many whole days do
/// x candies last? Binary search the largest d with d(d + 1)(2d + 1) / 6 ≤ x. O(log x).
/// https://www.hackerrank.com/challenges/little-chammys-huge-donation
/// </summary>
public static class LittleAshish
{
    public static long Solve(long x)
    {
        long low = 0;
        long high = 2_000_000; // 2e6 days already need more than 10^18 candies

        while (low < high)
        {
            long d = (low + high + 1) / 2;
            if ((Int128)d * (d + 1) * (2 * d + 1) / 6 <= x)
            {
                low = d;
            }
            else
            {
                high = d - 1;
            }
        }

        return low;
    }
}
