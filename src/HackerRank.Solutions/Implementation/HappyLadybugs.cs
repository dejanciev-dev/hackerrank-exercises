namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Happy Ladybugs — a ladybug is happy next to one of the same color. With at least one empty
/// cell ('_') bugs can be rearranged freely, so every color just needs two or more bugs.
/// Without one, the board must already be happy.
/// https://www.hackerrank.com/challenges/happy-ladybugs
/// </summary>
public static class HappyLadybugs
{
    public static string Solve(string b)
    {
        if (b.Contains('_'))
        {
            bool everyColorPaired = b.Where(c => c != '_')
                .GroupBy(c => c)
                .All(group => group.Count() >= 2);

            return everyColorPaired ? "YES" : "NO";
        }

        for (int i = 0; i < b.Length; i++)
        {
            bool matchesLeft = i > 0 && b[i - 1] == b[i];
            bool matchesRight = i < b.Length - 1 && b[i + 1] == b[i];

            if (!matchesLeft && !matchesRight)
            {
                return "NO";
            }
        }

        return "YES";
    }
}
