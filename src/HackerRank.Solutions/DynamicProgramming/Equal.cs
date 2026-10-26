namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Equal — giving 1, 2 or 5 chocolates to everyone but one colleague is the same as taking them
/// from that one. So bring everyone down to a common target using greedy 5/2/1 steps. The best
/// target is within 4 below the minimum, so try those five.
/// https://www.hackerrank.com/challenges/equal
/// </summary>
public static class Equal
{
    public static long Solve(IReadOnlyList<int> arr)
    {
        int min = arr.Min();
        long best = long.MaxValue;

        for (int target = min - 4; target <= min; target++)
        {
            long operations = arr.Sum(value => (long)Steps(value - target));
            best = Math.Min(best, operations);
        }

        return best;
    }

    private static int Steps(int difference) =>
        difference / 5 + difference % 5 / 2 + difference % 5 % 2;
}
