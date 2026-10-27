namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Little Panda Power — a^b mod x, where b may be negative (a is coprime to x, so a has an
/// inverse). x needn't be prime, so the inverse comes from the extended Euclidean algorithm;
/// then raise it to |b| by fast exponentiation.
/// https://www.hackerrank.com/challenges/littlepandapower
/// </summary>
public static class LittlePandaPower
{
    public static long Solve(long a, long b, long x)
    {
        long baseValue = ((a % x) + x) % x;

        if (b < 0)
        {
            baseValue = Inverse(baseValue, x);
            b = -b;
        }

        return ModularMath.Power(baseValue, b, x);
    }

    private static long Inverse(long a, long modulus)
    {
        long oldR = a, r = modulus;
        long oldS = 1, s = 0;

        while (r != 0)
        {
            long quotient = oldR / r;
            (oldR, r) = (r, oldR - quotient * r);
            (oldS, s) = (s, oldS - quotient * s);
        }

        return ((oldS % modulus) + modulus) % modulus;
    }
}
