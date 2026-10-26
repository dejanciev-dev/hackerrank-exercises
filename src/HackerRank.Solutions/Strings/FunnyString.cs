namespace HackerRank.Solutions.Strings;

/// <summary>
/// Funny String — a string is funny when the absolute differences between adjacent
/// characters are the same read forwards and backwards.
/// https://www.hackerrank.com/challenges/funny-string
/// </summary>
public static class FunnyString
{
    public static string Solve(string s)
    {
        int n = s.Length;

        for (int i = 1; i < n; i++)
        {
            int forward = Math.Abs(s[i] - s[i - 1]);
            int backward = Math.Abs(s[n - 1 - i] - s[n - i]);

            if (forward != backward)
            {
                return "Not Funny";
            }
        }

        return "Funny";
    }
}
