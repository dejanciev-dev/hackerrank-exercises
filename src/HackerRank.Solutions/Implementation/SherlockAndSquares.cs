namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Sherlock and Squares — count perfect squares in the inclusive range [a, b] in O(1)
/// as floor(sqrt(b)) - ceil(sqrt(a)) + 1.
/// https://www.hackerrank.com/challenges/sherlock-and-squares
/// </summary>
public static class SherlockAndSquares
{
    public static int Solve(int a, int b)
    {
        long low = IntegerSqrt(a);
        if (low * low < a)
        {
            low++;
        }

        long high = IntegerSqrt(b);
        return (int)Math.Max(0, high - low + 1);
    }

    private static long IntegerSqrt(long n)
    {
        long root = (long)Math.Sqrt(n);

        // Correct for floating-point rounding on large inputs.
        while (root * root > n) root--;
        while ((root + 1) * (root + 1) <= n) root++;

        return root;
    }
}
