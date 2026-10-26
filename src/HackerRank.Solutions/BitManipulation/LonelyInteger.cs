namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Lonely Integer — every element appears twice except one. XOR-ing everything cancels the
/// pairs (x ^ x = 0) and leaves the unique element. O(n) time, O(1) memory.
/// https://www.hackerrank.com/challenges/lonely-integer
/// </summary>
public static class LonelyInteger
{
    public static int Solve(IReadOnlyList<int> a) => a.Aggregate(0, (acc, value) => acc ^ value);
}
