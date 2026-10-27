namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Salary Blues — for each k, gcd(a_1 + k, a_2 + k, ..., a_n + k). Shifting every value by k
/// leaves their differences alone, so this equals gcd(a_1 + k, g), with g the gcd of
/// a_i - a_1 computed once. O(n + q · log).
/// https://www.hackerrank.com/challenges/salary-blues
/// </summary>
public static class SalaryBlues
{
    public static long[] Solve(IReadOnlyList<long> a, IReadOnlyList<long> queries)
    {
        long g = a.Aggregate(0L, (acc, v) => ModularMath.Gcd(acc, v - a[0]));
        return queries.Select(k => ModularMath.Gcd(a[0] + k, g)).ToArray();
    }
}
