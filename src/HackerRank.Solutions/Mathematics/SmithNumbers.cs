namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Identify Smith Numbers — 1 if <c>n</c> is a composite number whose digit sum equals the
/// sum of the digit sums of its prime factors (counted with multiplicity), else 0.
/// Trial division, O(√n).
/// https://www.hackerrank.com/challenges/identify-smith-numbers
/// </summary>
public static class SmithNumbers
{
    public static int Solve(int n)
    {
        int factorDigits = 0;
        int factorCount = 0;
        int remaining = n;

        for (int p = 2; (long)p * p <= remaining; p++)
        {
            for (; remaining % p == 0; remaining /= p)
            {
                factorDigits += DigitSum(p);
                factorCount++;
            }
        }

        if (remaining > 1)
        {
            factorDigits += DigitSum(remaining);
            factorCount++;
        }

        bool composite = factorCount > 1;
        return composite && factorDigits == DigitSum(n) ? 1 : 0;
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
