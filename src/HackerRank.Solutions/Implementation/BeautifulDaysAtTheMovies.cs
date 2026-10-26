namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Beautiful Days at the Movies — count days in [i, j] where |day - reverse(day)| is divisible by k.
/// https://www.hackerrank.com/challenges/beautiful-days-at-the-movies
/// </summary>
public static class BeautifulDaysAtTheMovies
{
    public static int Solve(int i, int j, int k)
    {
        int count = 0;
        for (int day = i; day <= j; day++)
        {
            if (Math.Abs(day - Reverse(day)) % k == 0)
            {
                count++;
            }
        }

        return count;
    }

    private static int Reverse(int number)
    {
        int reversed = 0;
        while (number > 0)
        {
            reversed = reversed * 10 + number % 10;
            number /= 10;
        }

        return reversed;
    }
}
