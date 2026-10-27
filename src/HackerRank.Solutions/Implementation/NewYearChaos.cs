namespace HackerRank.Solutions.Implementation;

/// <summary>
/// New Year Chaos — people in a queue can bribe the person directly ahead, at most twice
/// each; return the minimum number of bribes, or "Too chaotic". Anyone more than two places
/// ahead of their sticker is impossible. Each bribe someone received comes from a person now
/// ahead of them with a larger sticker. Such a person can't stand more than one place before
/// that person's original spot, so only a short window needs scanning.
/// https://www.hackerrank.com/challenges/new-year-chaos
/// </summary>
public static class NewYearChaos
{
    public static string Solve(IReadOnlyList<int> q)
    {
        int bribes = 0;

        for (int i = 0; i < q.Count; i++)
        {
            if (q[i] - (i + 1) > 2)
            {
                return "Too chaotic";
            }

            for (int j = Math.Max(0, q[i] - 2); j < i; j++)
            {
                if (q[j] > q[i])
                {
                    bribes++;
                }
            }
        }

        return bribes.ToString();
    }
}
