namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Number Groups — the odd numbers are grouped 1 | 3 5 | 7 9 11 | ...; the k-th group's sum
/// is k³ (k terms averaging k²).
/// https://www.hackerrank.com/challenges/number-groups
/// </summary>
public static class NumberGroups
{
    public static long Solve(long k) => k * k * k;
}
