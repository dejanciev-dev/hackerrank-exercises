namespace HackerRank.Solutions.Warmup;

/// <summary>
/// Time Conversion — convert a 12-hour AM/PM time (hh:mm:ssAM) to 24-hour military time.
/// https://www.hackerrank.com/challenges/time-conversion
/// </summary>
public static class TimeConversion
{
    public static string Solve(string s)
    {
        string[] partOfTime = s.Split(':');
        var format = partOfTime[2][^2..];
        partOfTime[2] = partOfTime[2][..^2];

        if (partOfTime[0] == "12" && format == "AM")
        {
            partOfTime[0] = "00";
        }

        if (format == "PM" && partOfTime[0] != "12")
        {
            var hour = int.Parse(partOfTime[0]) + 12;
            partOfTime[0] = hour.ToString("00");
        }

        return $"{partOfTime[0]}:{partOfTime[1]}:{partOfTime[2]}";
    }
}
