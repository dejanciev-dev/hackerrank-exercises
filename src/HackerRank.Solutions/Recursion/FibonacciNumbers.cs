namespace HackerRank.Solutions.Recursion;

/// <summary>
/// Recursion: Fibonacci Numbers — the n-th Fibonacci number, with fib(0) = 0 and fib(1) = 1.
/// Recursive, memoized so each value is computed once: O(n) instead of O(2^n).
/// https://www.hackerrank.com/challenges/ctci-fibonacci-numbers
/// </summary>
public static class FibonacciNumbers
{
    public static long Solve(int n) => Fibonacci(n, new long?[n + 1]);

    private static long Fibonacci(int n, long?[] memo)
    {
        if (n <= 1)
        {
            return n;
        }

        return memo[n] ??= Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
    }
}
