namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Bus Station — every bus size x such that the groups, boarding in order without splitting
/// a group, fill each bus exactly. x must divide the total and be at least the largest
/// group, and each such divisor is checked with one greedy pass. O(n · d(total)).
/// https://www.hackerrank.com/challenges/bus-station
/// </summary>
public static class BusStation
{
    public static long[] Solve(IReadOnlyList<int> a)
    {
        long total = a.Sum(g => (long)g);
        int largest = a.Max();
        var divisors = new List<long>();

        for (long d = 1; d * d <= total; d++)
        {
            if (total % d == 0)
            {
                divisors.Add(d);
                if (d * d != total)
                {
                    divisors.Add(total / d);
                }
            }
        }

        return divisors.Where(x => x >= largest && FillsExactly(a, x)).Order().ToArray();
    }

    private static bool FillsExactly(IReadOnlyList<int> groups, long size)
    {
        long load = 0;
        foreach (var group in groups)
        {
            load += group;
            if (load == size)
            {
                load = 0;
            }
            else if (load > size)
            {
                return false;
            }
        }

        return load == 0;
    }
}
