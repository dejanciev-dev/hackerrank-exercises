namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Service Lane — for each [entry, exit] segment, the widest vehicle that fits is the narrowest
/// width along it.
/// https://www.hackerrank.com/challenges/service-lane
/// </summary>
public static class ServiceLane
{
    public static int[] Solve(IReadOnlyList<int> width, IReadOnlyList<IReadOnlyList<int>> cases)
    {
        var result = new int[cases.Count];

        for (int c = 0; c < cases.Count; c++)
        {
            int narrowest = int.MaxValue;
            for (int i = cases[c][0]; i <= cases[c][1]; i++)
            {
                narrowest = Math.Min(narrowest, width[i]);
            }

            result[c] = narrowest;
        }

        return result;
    }
}
