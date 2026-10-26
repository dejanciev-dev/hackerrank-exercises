namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Day of the Programmer — the 256th day of a year in Russia, accounting for the Julian
/// calendar (1700–1917), the 1918 transition and the Gregorian calendar (1919+).
/// https://www.hackerrank.com/challenges/day-of-the-programmer
/// </summary>
public static class DayOfTheProgrammer
{
    public static string Solve(int year)
    {
        int[] firstEightMonths = [31, 28, 31, 30, 31, 30, 31, 31];

        if (year == 1918)
        {
            // February 14th followed January 31st during the switch to the Gregorian calendar.
            firstEightMonths[1] -= 13;
        }
        else if (IsLeapYear(year))
        {
            firstEightMonths[1] = 29;
        }

        var day = 256 - firstEightMonths.Sum();
        return $"{day}.09.{year}";
    }

    private static bool IsLeapYear(int year) =>
        year < 1918
            ? year % 4 == 0
            : (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
}
