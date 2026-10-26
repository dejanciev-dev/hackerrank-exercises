using System.Numerics;

namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Fibonacci Modified — t(i+2) = t(i) + t(i+1)²; return the n-th term. The values grow
/// doubly exponentially, so BigInteger is required.
/// https://www.hackerrank.com/challenges/fibonacci-modified
/// </summary>
public static class FibonacciModified
{
    public static string Solve(int t1, int t2, int n)
    {
        BigInteger previous = t1;
        BigInteger current = t2;

        for (int i = 3; i <= n; i++)
        {
            (previous, current) = (current, previous + current * current);
        }

        return (n == 1 ? previous : current).ToString();
    }
}
