namespace HackerRank.Solutions.Warmup;

/// <summary>
/// A Very Big Sum — sum large integers without overflowing a 32-bit int.
/// https://www.hackerrank.com/challenges/a-very-big-sum
/// </summary>
public static class AVeryBigSum
{
    public static long Solve(IReadOnlyList<long> ar)
    {
        long sum = 0;
        foreach (var value in ar)
        {
            sum += value;
        }

        return sum;
    }
}
