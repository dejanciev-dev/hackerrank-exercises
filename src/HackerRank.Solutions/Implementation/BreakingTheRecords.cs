namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Breaking the Records — count how many times Maria breaks her most and least points records.
/// Returns [timesMaxBroken, timesMinBroken].
/// https://www.hackerrank.com/challenges/breaking-best-and-worst-records
/// </summary>
public static class BreakingTheRecords
{
    public static int[] Solve(IReadOnlyList<int> scores)
    {
        int minScore = scores[0], maxScore = scores[0];
        int countMin = 0, countMax = 0;

        for (int i = 1; i < scores.Count; i++)
        {
            if (scores[i] > maxScore)
            {
                countMax++;
                maxScore = scores[i];
            }

            if (scores[i] < minScore)
            {
                countMin++;
                minScore = scores[i];
            }
        }

        return [countMax, countMin];
    }
}
