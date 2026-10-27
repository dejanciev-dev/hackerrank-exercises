namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Time Complexity: Primality — trial division by 2, then by odd numbers up to √n. O(√n).
/// https://www.hackerrank.com/challenges/ctci-big-o
/// </summary>
public static class Primality
{
    public static string Solve(long n)
    {
        if (n < 2 || (n % 2 == 0 && n != 2))
        {
            return "Not prime";
        }

        for (long d = 3; d * d <= n; d += 2)
        {
            if (n % d == 0)
            {
                return "Not prime";
            }
        }

        return "Prime";
    }
}
