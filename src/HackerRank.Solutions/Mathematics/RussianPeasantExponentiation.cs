namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Russian Peasant Exponentiation — (a + bi)^k with both parts reduced modulo m. Square and
/// multiply on Gaussian integers, using (p + qi)(r + si) = (pr - qs) + (ps + qr)i.
/// O(log k).
/// https://www.hackerrank.com/challenges/russian-peasant-exponentiation
/// </summary>
public static class RussianPeasantExponentiation
{
    public static long[] Solve(long a, long b, long k, long m)
    {
        (long Re, long Im) result = (1 % m, 0);
        (long Re, long Im) power = (a % m, b % m);

        for (; k > 0; k >>= 1)
        {
            if ((k & 1) == 1)
            {
                result = Multiply(result, power, m);
            }

            power = Multiply(power, power, m);
        }

        return [result.Re, result.Im];
    }

    private static (long Re, long Im) Multiply((long Re, long Im) x, (long Re, long Im) y, long m)
    {
        long re = (x.Re * y.Re % m - x.Im * y.Im % m + m) % m;
        long im = (x.Re * y.Im % m + x.Im * y.Re % m) % m;
        return (re, im);
    }
}
