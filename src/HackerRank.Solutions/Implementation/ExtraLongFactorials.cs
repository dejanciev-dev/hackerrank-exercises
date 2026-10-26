using System.Numerics;

namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Extra Long Factorials — n! for n up to 100, which overflows every built-in integer type.
/// https://www.hackerrank.com/challenges/extra-long-factorials
/// </summary>
public static class ExtraLongFactorials
{
    public static string Solve(int n)
    {
        BigInteger factorial = BigInteger.One;

        for (int i = 2; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial.ToString();
    }
}
