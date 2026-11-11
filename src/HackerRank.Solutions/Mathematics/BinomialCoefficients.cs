using System.Numerics;

namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Binomial Coefficients — for n with up to 500 digits and a prime p, count the k in [0, n]
/// for which C(n, k) is divisible by p.
/// By Lucas's theorem C(n, k) is not divisible by p exactly when every base-p digit of k is at
/// most the matching digit of n, which gives Π (d_i + 1) such k. Subtract that from n + 1.
/// O(digits²) with BigInteger division.
/// https://www.hackerrank.com/challenges/binomial-coefficients
/// </summary>
public static class BinomialCoefficients
{
    public static string Solve(string n, int p)
    {
        var value = BigInteger.Parse(n);
        BigInteger notDivisible = 1;
        for (var rest = value; rest > 0; rest /= p)
        {
            notDivisible *= (int)(rest % p) + 1;
        }

        return (value + 1 - notDivisible).ToString();
    }
}
