namespace HackerRank.Solutions.Recursion;

/// <summary>
/// The Power Sum — number of ways to write <c>x</c> as a sum of N-th powers of unique natural
/// numbers. Recursively either use the current base or skip it, trying bases in increasing order.
/// https://www.hackerrank.com/challenges/the-power-sum
/// </summary>
public static class ThePowerSum
{
    public static int Solve(int x, int n) => CountWays(x, n, 1);

    private static int CountWays(int remaining, int n, int number)
    {
        int power = (int)Math.Pow(number, n);

        if (power > remaining)
        {
            return 0;
        }

        if (power == remaining)
        {
            return 1;
        }

        return CountWays(remaining - power, n, number + 1) + CountWays(remaining, n, number + 1);
    }
}
