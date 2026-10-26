namespace HackerRank.Solutions.Strings;

/// <summary>
/// Gemstones — count the minerals (characters) that occur in every rock (string).
/// https://www.hackerrank.com/challenges/gem-stones
/// </summary>
public static class Gemstones
{
    public static int Solve(IReadOnlyList<string> arr)
    {
        var common = new HashSet<char>(arr[0]);

        for (int i = 1; i < arr.Count; i++)
        {
            common.IntersectWith(arr[i]);
        }

        return common.Count;
    }
}
