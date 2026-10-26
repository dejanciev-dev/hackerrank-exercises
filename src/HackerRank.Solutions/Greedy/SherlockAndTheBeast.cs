namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Sherlock and The Beast — the largest <c>n</c>-digit "decent number": only 3s and 5s, the
/// count of 5s divisible by 3 and the count of 3s divisible by 5. Put as many 5s up front as
/// possible. Returns "-1" if none exists.
/// https://www.hackerrank.com/challenges/sherlock-and-the-beast
/// </summary>
public static class SherlockAndTheBeast
{
    public static string Solve(int n)
    {
        for (int fives = n; fives >= 0; fives--)
        {
            int threes = n - fives;
            if (fives % 3 == 0 && threes % 5 == 0)
            {
                return new string('5', fives) + new string('3', threes);
            }
        }

        return "-1";
    }
}
