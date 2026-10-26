namespace HackerRank.Solutions.Warmup;

/// <summary>
/// Simple Array Sum — return the sum of all elements of an array.
/// https://www.hackerrank.com/challenges/simple-array-sum
/// </summary>
public static class SimpleArraySum
{
    public static int Solve(IReadOnlyList<int> ar)
    {
        int sum = 0;
        foreach (var value in ar)
        {
            sum += value;
        }

        return sum;
    }
}
