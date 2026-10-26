namespace HackerRank.Solutions.Implementation;

/// <summary>
/// ACM ICPC Team — each attendee knows a set of topics (a binary string). Return the maximum
/// number of topics a two-person team can know and how many teams reach it.
/// https://www.hackerrank.com/challenges/acm-icpc-team
/// </summary>
public static class AcmIcpcTeam
{
    public static int[] Solve(IReadOnlyList<string> topic)
    {
        int best = 0;
        int teams = 0;

        for (int i = 0; i < topic.Count; i++)
        {
            for (int j = i + 1; j < topic.Count; j++)
            {
                int known = 0;
                for (int t = 0; t < topic[i].Length; t++)
                {
                    if (topic[i][t] == '1' || topic[j][t] == '1') known++;
                }

                if (known > best)
                {
                    best = known;
                    teams = 1;
                }
                else if (known == best)
                {
                    teams++;
                }
            }
        }

        return [best, teams];
    }
}
