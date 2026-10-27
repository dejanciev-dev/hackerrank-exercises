namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Ajob Subsequence — the number of length-(k + 1) subsequences of a string of n + 1
/// distinct letters is C(n + 1, k + 1). We need it modulo a small prime p, with n up to
/// 10^18, so use Lucas's theorem. The binomial splits into a product of C(n_i, k_i) over the
/// base-p digits, each taken from a factorial table mod p.
/// https://www.hackerrank.com/challenges/ajob-subsequence
/// </summary>
public static class AjobSubsequence
{
    public static long Solve(long n, long k, int p)
    {
        var factorial = new long[p];
        factorial[0] = 1;
        for (int i = 1; i < p; i++)
        {
            factorial[i] = factorial[i - 1] * i % p;
        }

        long top = n + 1;
        long bottom = k + 1;
        long result = 1;

        while (bottom > 0 || top > 0)
        {
            long ni = top % p;
            long ki = bottom % p;
            if (ki > ni)
            {
                return 0;
            }

            long denominator = factorial[ki] * factorial[ni - ki] % p;
            result = result * factorial[ni] % p * ModularMath.Power(denominator, p - 2, p) % p;

            top /= p;
            bottom /= p;
        }

        return result;
    }
}
