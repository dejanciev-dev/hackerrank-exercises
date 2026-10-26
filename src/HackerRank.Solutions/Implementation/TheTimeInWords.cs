namespace HackerRank.Solutions.Implementation;

/// <summary>
/// The Time in Words — write a time in English, e.g. 5:47 → "thirteen minutes to six".
/// https://www.hackerrank.com/challenges/the-time-in-words
/// </summary>
public static class TheTimeInWords
{
    private static readonly string[] Ones =
    [
        "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
        "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
        "eighteen", "nineteen",
    ];

    public static string Solve(int h, int m)
    {
        int nextHour = h % 12 + 1;

        return m switch
        {
            0 => $"{Words(h)} o' clock",
            15 => $"quarter past {Words(h)}",
            30 => $"half past {Words(h)}",
            45 => $"quarter to {Words(nextHour)}",
            < 30 => $"{Minutes(m)} past {Words(h)}",
            _ => $"{Minutes(60 - m)} to {Words(nextHour)}",
        };
    }

    private static string Minutes(int minutes) =>
        $"{Words(minutes)} {(minutes == 1 ? "minute" : "minutes")}";

    private static string Words(int number) =>
        number < 20 ? Ones[number] : $"twenty {Ones[number - 20]}".TrimEnd();
}
