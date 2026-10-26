namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Equalize the Array — minimum deletions so every remaining element is equal:
/// keep the most frequent value and delete everything else.
/// https://www.hackerrank.com/challenges/equality-in-a-array
/// </summary>
public static class EqualizeTheArray
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        int mostFrequent = arr.GroupBy(value => value).Max(group => group.Count());
        return arr.Count - mostFrequent;
    }
}
