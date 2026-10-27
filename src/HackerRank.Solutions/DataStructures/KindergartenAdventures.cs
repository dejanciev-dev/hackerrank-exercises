namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Kindergarten Adventures — students sit in a circle and the teacher collects drawings
/// clockwise, starting at some student; student i needs t[i] minutes to finish. Pick the
/// starting student (smallest id on ties) for whom the most drawings are complete. Student i
/// fails exactly for the t[i] starting positions just behind them, so mark those circular
/// ranges in a difference array and take the position with the fewest failures. O(n).
/// https://www.hackerrank.com/challenges/kindergarten-adventures
/// </summary>
public static class KindergartenAdventures
{
    public static int Solve(IReadOnlyList<int> t)
    {
        int n = t.Count;
        var failures = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            if (t[i] == 0)
            {
                continue;
            }

            if (t[i] >= n)
            {
                failures[0]++;
                failures[n]--;
                continue;
            }

            // Failing starts: i - t[i] + 1 .. i, wrapping around the circle.
            int start = i - t[i] + 1;
            if (start >= 0)
            {
                failures[start]++;
                failures[i + 1]--;
            }
            else
            {
                failures[0]++;
                failures[i + 1]--;
                failures[start + n]++;
                failures[n]--;
            }
        }

        int best = 0;
        int bestFailures = int.MaxValue;
        int running = 0;

        for (int s = 0; s < n; s++)
        {
            running += failures[s];
            if (running < bestFailures)
            {
                bestFailures = running;
                best = s;
            }
        }

        return best + 1;
    }
}
