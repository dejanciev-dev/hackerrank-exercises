namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Smart Number — a number is "smart" when it has an odd number of divisors. Divisors pair up as
/// (d, n / d), so the count is odd exactly when some divisor pairs with itself, that is when n is
/// a perfect square. Report "YES" for a smart number and "NO" otherwise. O(1).
/// https://www.hackerrank.com/challenges/smart-number
/// </summary>
public static class SmartNumber
{
    public static string Solve(long n)
    {
        if (n < 1)
        {
            return "NO";
        }

        long root = (long)Math.Sqrt(n);

        // Correct the floating-point estimate in both directions, comparing by division so that
        // squares near the top of the long range cannot overflow.
        while (root > n / root)
        {
            root--;
        }

        while (root + 1 <= n / (root + 1))
        {
            root++;
        }

        return root * root == n ? "YES" : "NO";
    }
}
