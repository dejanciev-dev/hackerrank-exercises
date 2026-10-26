namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Beautiful Pairs — maximum disjoint pairs of equal elements between A and B after changing
/// exactly one element of B. Count the matches; the forced change can add one more match, or
/// it costs one if everything already matched.
/// https://www.hackerrank.com/challenges/beautiful-pairs
/// </summary>
public static class BeautifulPairs
{
    public static int Solve(IReadOnlyList<int> a, IReadOnlyList<int> b)
    {
        var available = new Dictionary<int, int>();
        foreach (var value in a)
        {
            available[value] = available.GetValueOrDefault(value) + 1;
        }

        int matches = 0;
        foreach (var value in b)
        {
            if (available.GetValueOrDefault(value) > 0)
            {
                available[value]--;
                matches++;
            }
        }

        return matches == a.Count ? matches - 1 : matches + 1;
    }
}
