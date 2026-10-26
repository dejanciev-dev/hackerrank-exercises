namespace HackerRank.Solutions.Warmup;

/// <summary>
/// Mini-Max Sum — minimum and maximum sums obtainable by adding exactly four of five integers.
/// https://www.hackerrank.com/challenges/mini-max-sum
/// </summary>
public static class MiniMaxSum
{
    public static (long Min, long Max) Solve(IReadOnlyList<int> arr)
    {
        long total = 0;
        int min = int.MaxValue;
        int max = int.MinValue;

        foreach (var value in arr)
        {
            total += value;
            min = Math.Min(min, value);
            max = Math.Max(max, value);
        }

        return (total - max, total - min);
    }
}
