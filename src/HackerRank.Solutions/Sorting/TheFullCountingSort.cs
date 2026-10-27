using System.Text;

namespace HackerRank.Solutions.Sorting;

/// <summary>
/// The Full Counting Sort — stably sort (key, string) pairs by key, replacing the strings of
/// the first half of the input with "-". Bucket the strings by key in input order, then
/// concatenate the buckets. O(n + 100).
/// https://www.hackerrank.com/challenges/countingsort4
/// </summary>
public static class TheFullCountingSort
{
    private const int Range = 100;

    /// <param name="arr">Each entry as <c>[key, text]</c>, with the key in 0..99.</param>
    public static string Solve(IReadOnlyList<IReadOnlyList<string>> arr)
    {
        var buckets = new List<string>[Range];
        for (int i = 0; i < Range; i++)
        {
            buckets[i] = [];
        }

        for (int i = 0; i < arr.Count; i++)
        {
            buckets[int.Parse(arr[i][0])].Add(i < arr.Count / 2 ? "-" : arr[i][1]);
        }

        var output = new StringBuilder();
        foreach (var text in buckets.SelectMany(bucket => bucket))
        {
            output.Append(text).Append(' ');
        }

        return output.ToString().TrimEnd();
    }
}
