namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Marc's Cakewalk — eating the j-th cupcake (0-based) means walking 2^j × its calories.
/// Minimize total miles by eating the most caloric cupcakes first.
/// https://www.hackerrank.com/challenges/marcs-cakewalk
/// </summary>
public static class MarcsCakewalk
{
    public static long Solve(IReadOnlyList<int> calorie)
    {
        long miles = 0;
        int j = 0;

        foreach (var calories in calorie.OrderDescending())
        {
            miles += calories * (1L << j++);
        }

        return miles;
    }
}
