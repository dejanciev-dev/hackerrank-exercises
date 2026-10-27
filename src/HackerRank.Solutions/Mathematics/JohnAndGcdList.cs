namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// John and GCD list — find the smallest-sum list B with gcd(B[i], B[i+1]) = A[i]. Each
/// B[i] must be a multiple of both A[i-1] and A[i], and the smallest such value is their
/// lcm. The ends only need A[0] and A[n-1].
/// https://www.hackerrank.com/challenges/john-and-gcd-list
/// </summary>
public static class JohnAndGcdList
{
    public static long[] Solve(IReadOnlyList<int> a)
    {
        var b = new long[a.Count + 1];
        b[0] = a[0];
        b[^1] = a[^1];

        for (int i = 1; i < a.Count; i++)
        {
            b[i] = (long)a[i - 1] / ModularMath.Gcd(a[i - 1], a[i]) * a[i];
        }

        return b;
    }
}
