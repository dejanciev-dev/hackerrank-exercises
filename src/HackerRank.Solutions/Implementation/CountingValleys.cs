namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Counting Valleys — given a hike of 'U' and 'D' steps starting at sea level, count the
/// valleys walked through (a valley ends with a step up back to sea level).
/// https://www.hackerrank.com/challenges/counting-valleys
/// </summary>
public static class CountingValleys
{
    public static int Solve(string path)
    {
        int level = 0;
        int valleys = 0;

        foreach (var step in path)
        {
            level += step == 'U' ? 1 : -1;

            if (step == 'U' && level == 0)
            {
                valleys++;
            }
        }

        return valleys;
    }
}
