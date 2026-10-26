namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Viral Advertising — an ad is shown to 5 people on day one; half (floored) like it and each
/// shares it with 3 friends the next day. Return the cumulative likes after <c>n</c> days.
/// https://www.hackerrank.com/challenges/strange-advertising
/// </summary>
public static class ViralAdvertising
{
    public static int Solve(int n)
    {
        int shared = 5;
        int cumulative = 0;

        for (int day = 1; day <= n; day++)
        {
            int liked = shared / 2;
            cumulative += liked;
            shared = liked * 3;
        }

        return cumulative;
    }
}
