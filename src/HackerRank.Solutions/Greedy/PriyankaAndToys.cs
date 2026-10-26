namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Priyanka and Toys — minimum containers when each holds toys whose weights fall within 4 of
/// its lightest toy. After sorting, open a new container at the first toy that doesn't fit.
/// https://www.hackerrank.com/challenges/priyanka-and-toys
/// </summary>
public static class PriyankaAndToys
{
    public static int Solve(IReadOnlyList<int> w)
    {
        int containers = 0;
        long limit = long.MinValue;

        foreach (var weight in w.Order())
        {
            if (weight > limit)
            {
                containers++;
                limit = weight + 4L;
            }
        }

        return containers;
    }
}
