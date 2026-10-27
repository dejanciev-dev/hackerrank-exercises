namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Sherlock and Divisors — number of even divisors of <c>n</c>. Odd numbers have none;
/// otherwise the even divisors are 2d for each divisor d of n / 2. O(√n).
/// https://www.hackerrank.com/challenges/sherlock-and-divisors
/// </summary>
public static class SherlockAndDivisors
{
    public static int Solve(int n)
    {
        if (n % 2 == 1)
        {
            return 0;
        }

        int half = n / 2;
        int count = 0;

        for (int d = 1; (long)d * d <= half; d++)
        {
            if (half % d == 0)
            {
                count += d * d == half ? 1 : 2;
            }
        }

        return count;
    }
}
