namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Super Humble Matrix — fill an n x m matrix with 1..nm so values increase with i + j.
/// Every anti-diagonal must hold the next block of numbers, in any order, so the count is
/// the product of (diagonal length)! modulo 1e9+7. O(n + m).
/// https://www.hackerrank.com/challenges/super-humble-matrix
/// </summary>
public static class SuperHumbleMatrix
{
    public static long Solve(int n, int m)
    {
        int longest = Math.Min(n, m);
        var factorial = new long[longest + 1];
        factorial[0] = 1;
        for (int i = 1; i <= longest; i++)
        {
            factorial[i] = factorial[i - 1] * i % ModularMath.Prime;
        }

        long ways = 1;
        for (int d = 0; d <= n + m - 2; d++)
        {
            int length = Math.Min(Math.Min(d, n + m - 2 - d), longest - 1) + 1;
            ways = ways * factorial[length] % ModularMath.Prime;
        }

        return ways;
    }
}
