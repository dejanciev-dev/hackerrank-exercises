namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Halloween Party — maximum 1x1 pieces from a chocolate bar with <c>k</c> straight cuts.
/// Split the cuts as evenly as possible between the two directions: ⌊k/2⌋ · ⌈k/2⌉.
/// https://www.hackerrank.com/challenges/halloween-party
/// </summary>
public static class HalloweenParty
{
    public static long Solve(long k) => k / 2 * ((k + 1) / 2);
}
