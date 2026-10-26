namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Find Digits — count the digits of <c>n</c> that are divisors of <c>n</c>.
/// https://www.hackerrank.com/challenges/find-digits
/// </summary>
public static class FindDigits
{
    public static int Solve(int n)
    {
        int remaining = n;
        int count = 0;

        while (remaining > 0)
        {
            int digit = remaining % 10;
            if (digit > 0 && n % digit == 0)
            {
                count++;
            }

            remaining /= 10;
        }

        return count;
    }
}
