namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Best Divisor — the divisor of <c>n</c> with the largest digit sum, the smallest one on a
/// tie. Divisors come in pairs (d, n / d), so trial division up to √n finds them all.
/// https://www.hackerrank.com/challenges/best-divisor
/// </summary>
public static class BestDivisor
{
    public static int Solve(int n)
    {
        int best = 1;

        for (int d = 1; d * d <= n; d++)
        {
            if (n % d != 0)
            {
                continue;
            }

            foreach (var divisor in new[] { d, n / d })
            {
                int sum = DigitSum(divisor);
                int bestSum = DigitSum(best);

                if (sum > bestSum || (sum == bestSum && divisor < best))
                {
                    best = divisor;
                }
            }
        }

        return best;
    }

    private static int DigitSum(int value)
    {
        int sum = 0;
        for (; value > 0; value /= 10)
        {
            sum += value % 10;
        }

        return sum;
    }
}
