namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Cloudy Day — remove exactly one cloud to maximise the population living in sunny towns.
/// Sweep a line across all cloud starts, towns and cloud ends, with starts before towns
/// before ends at the same coordinate, since cloud ranges are inclusive. A town under no
/// cloud is always sunny; a town under exactly one cloud is credited to that cloud. Answer:
/// always-sunny + the best cloud's credit. O((n + m) log(n + m)).
/// https://www.hackerrank.com/challenges/cloudy-day
/// </summary>
public static class CloudyDay
{
    /// <param name="p">Town populations.</param>
    /// <param name="x">Town locations.</param>
    /// <param name="y">Cloud centres.</param>
    /// <param name="r">Cloud radii.</param>
    public static long Solve(IReadOnlyList<long> p, IReadOnlyList<long> x, IReadOnlyList<long> y, IReadOnlyList<long> r)
    {
        const int Start = 0, Town = 1, End = 2;
        var events = new List<(long Position, int Kind, int Index)>();

        for (int i = 0; i < x.Count; i++)
        {
            events.Add((x[i], Town, i));
        }

        for (int j = 0; j < y.Count; j++)
        {
            events.Add((y[j] - r[j], Start, j));
            events.Add((y[j] + r[j], End, j));
        }

        events.Sort();

        var active = new HashSet<int>();
        var credit = new long[y.Count];
        long sunny = 0;

        foreach (var (_, kind, index) in events)
        {
            switch (kind)
            {
                case Start:
                    active.Add(index);
                    break;
                case End:
                    active.Remove(index);
                    break;
                case Town when active.Count == 0:
                    sunny += p[index];
                    break;
                case Town when active.Count == 1:
                    credit[active.First()] += p[index];
                    break;
            }
        }

        return sunny + (credit.Length > 0 ? credit.Max() : 0);
    }
}
