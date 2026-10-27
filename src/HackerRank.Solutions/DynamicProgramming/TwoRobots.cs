namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Two Robots — candies must be moved from a_i to b_i in the given order by either of two
/// robots. A robot's first job only costs |a - b|; later jobs also cost the walk from where
/// that robot stopped. After job i, one robot is at b_i, so the state is just where the
/// other robot is: at the end of some earlier job j, or not used yet.
/// best[j] = minimum distance so far. O(n²).
/// https://www.hackerrank.com/challenges/two-robots
/// </summary>
public static class TwoRobots
{
    /// <param name="queries">Each job as <c>[from, to]</c>.</param>
    public static long Solve(IReadOnlyList<IReadOnlyList<int>> queries)
    {
        int n = queries.Count;

        // best[j]: the other robot is at the end of job j - 1 (1-based), or unused when j = 0.
        var best = new long[n + 1];
        Array.Fill(best, long.MaxValue);
        best[0] = Math.Abs(queries[0][0] - queries[0][1]);

        for (int i = 1; i < n; i++)
        {
            long job = Math.Abs(queries[i][0] - queries[i][1]);
            var next = new long[n + 1];
            Array.Fill(next, long.MaxValue);

            for (int j = 0; j < i; j++)
            {
                if (best[j] == long.MaxValue)
                {
                    continue;
                }

                // The robot that just finished job i - 1 takes job i.
                long same = best[j] + Math.Abs(queries[i - 1][1] - queries[i][0]) + job;
                next[j] = Math.Min(next[j], same);

                // The other robot takes it; the one at b_{i-1} becomes the "other".
                long walk = j == 0 ? 0 : Math.Abs(queries[j - 1][1] - queries[i][0]);
                next[i] = Math.Min(next[i], best[j] + walk + job);
            }

            best = next;
        }

        return best.Min();
    }
}
