namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Jim and the Jokes — read each date's day digits as a number in base <c>month</c> (skipping
/// dates with a digit too large for that base). Count pairs of dates that give the same
/// number. Group by value and add c · (c - 1) / 2 per group.
/// https://www.hackerrank.com/challenges/jim-and-the-jokes
/// </summary>
public static class JimAndTheJokes
{
    /// <param name="dates">Each date as <c>[month, day]</c>.</param>
    public static long Solve(IReadOnlyList<IReadOnlyList<int>> dates)
    {
        var counts = new Dictionary<long, long>();

        foreach (var date in dates)
        {
            int month = date[0];
            long value = 0;
            bool valid = true;

            foreach (var c in date[1].ToString())
            {
                int digit = c - '0';
                if (digit >= month)
                {
                    valid = false;
                    break;
                }

                value = value * month + digit;
            }

            if (valid)
            {
                counts[value] = counts.GetValueOrDefault(value) + 1;
            }
        }

        return counts.Values.Sum(c => c * (c - 1) / 2);
    }
}
