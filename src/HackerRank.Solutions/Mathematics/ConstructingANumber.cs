namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Constructing a Number — can the digits of all the given numbers be rearranged into one
/// number divisible by 3? Divisibility by 3 depends only on the digit sum, which reordering
/// doesn't change.
/// https://www.hackerrank.com/challenges/constructing-a-number
/// </summary>
public static class ConstructingANumber
{
    public static string Solve(IReadOnlyList<int> a)
    {
        long digitSum = 0;
        foreach (var number in a)
        {
            for (int value = number; value > 0; value /= 10)
            {
                digitSum += value % 10;
            }
        }

        return digitSum % 3 == 0 ? "Yes" : "No";
    }
}
