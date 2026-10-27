namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Is Fibo — is <c>n</c> a Fibonacci number? Fibonacci numbers grow exponentially, so walking
/// the sequence up to n takes only about 50 steps for n ≤ 10^10.
/// https://www.hackerrank.com/challenges/is-fibo
/// </summary>
public static class IsFibo
{
    public static string Solve(long n)
    {
        long previous = 0;
        long current = 1;

        while (current < n)
        {
            (previous, current) = (current, previous + current);
        }

        return n == 0 || current == n ? "IsFibo" : "IsNotFibo";
    }
}
