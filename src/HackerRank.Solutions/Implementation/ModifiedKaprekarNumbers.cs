namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Modified Kaprekar Numbers — numbers n in [p, q] whose square, split into a right part with
/// as many digits as n and the left part that remains, sums back to n (e.g. 45² = 2025, 20 + 25).
/// Returns an empty array when there are none (printed as "INVALID RANGE" on HackerRank).
/// https://www.hackerrank.com/challenges/kaprekar-numbers
/// </summary>
public static class ModifiedKaprekarNumbers
{
    public static int[] Solve(int p, int q)
    {
        var result = new List<int>();

        for (int n = p; n <= q; n++)
        {
            long square = (long)n * n;
            long divisor = 1;
            for (int remaining = n; remaining > 0; remaining /= 10)
            {
                divisor *= 10;
            }

            if (square / divisor + square % divisor == n)
            {
                result.Add(n);
            }
        }

        return result.ToArray();
    }
}
