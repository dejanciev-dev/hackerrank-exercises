namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Construct the Array — count arrays of length <c>n</c> over 1..k that start with 1, end with
/// <c>x</c> and have no two equal neighbours, modulo 1e9+7. By symmetry every value other than
/// 1 is reachable in the same number of ways, so two counters suffice: arrays ending in 1 and
/// arrays ending in one particular other value. O(n) time, O(1) memory.
/// https://www.hackerrank.com/challenges/construct-the-array
/// </summary>
public static class ConstructTheArray
{
    private const long Mod = 1_000_000_007;

    public static long Solve(int n, int k, int x)
    {
        long endsInOne = 1;
        long endsInOther = 0;

        for (int i = 2; i <= n; i++)
        {
            long nextOne = (k - 1) * endsInOther % Mod;
            long nextOther = (endsInOne + (k - 2) * endsInOther) % Mod;
            endsInOne = nextOne;
            endsInOther = nextOther;
        }

        return x == 1 ? endsInOne : endsInOther;
    }
}
