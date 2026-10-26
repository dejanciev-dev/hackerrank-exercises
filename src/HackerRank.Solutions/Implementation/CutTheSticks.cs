namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Cut the Sticks — repeatedly cut every stick by the length of the shortest one and discard
/// the empty ones; return how many sticks remain before each cut. After sorting, each new
/// distinct length marks one round.
/// https://www.hackerrank.com/challenges/cut-the-sticks
/// </summary>
public static class CutTheSticks
{
    public static int[] Solve(IReadOnlyList<int> arr)
    {
        var sorted = arr.Order().ToArray();
        var result = new List<int>();

        for (int i = 0; i < sorted.Length; i++)
        {
            if (i == 0 || sorted[i] != sorted[i - 1])
            {
                result.Add(sorted.Length - i);
            }
        }

        return result.ToArray();
    }
}
