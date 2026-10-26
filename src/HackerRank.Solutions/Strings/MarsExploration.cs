namespace HackerRank.Solutions.Strings;

/// <summary>
/// Mars Exploration — a series of "SOS" signals was received; count the altered letters.
/// https://www.hackerrank.com/challenges/mars-exploration
/// </summary>
public static class MarsExploration
{
    private const string Signal = "SOS";

    public static int Solve(string s)
    {
        int altered = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != Signal[i % Signal.Length])
            {
                altered++;
            }
        }

        return altered;
    }
}
