namespace HackerRank.Solutions.Recursion;

/// <summary>
/// Recursive Digit Sum — the "super digit" of <c>n</c> repeated <c>k</c> times. Summing the
/// digits once and multiplying by k avoids building a string of up to 10^5 × 10^5 characters.
/// https://www.hackerrank.com/challenges/recursive-digit-sum
/// </summary>
public static class RecursiveDigitSum
{
    public static int Solve(string n, int k)
    {
        long digitSum = n.Sum(c => (long)(c - '0'));
        return SuperDigit(digitSum * k);
    }

    private static int SuperDigit(long number)
    {
        if (number < 10)
        {
            return (int)number;
        }

        long sum = 0;
        for (; number > 0; number /= 10)
        {
            sum += number % 10;
        }

        return SuperDigit(sum);
    }
}
