namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Megaprime Numbers — count primes in [first, last] whose digits are all prime (2, 3, 5,
/// 7). Instead of scanning the range, generate only the numbers made of those four digits
/// (4^d of them per length d). Each is tested with deterministic Miller–Rabin for 64-bit
/// values.
/// https://www.hackerrank.com/challenges/megaprime-numbers
/// </summary>
public static class MegaprimeNumbers
{
    private static readonly long[] Digits = [2, 3, 5, 7];
    private static readonly ulong[] Witnesses = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37];

    public static long Solve(long first, long last)
    {
        long count = 0;
        var stack = new Stack<long>(Digits);

        while (stack.Count > 0)
        {
            long value = stack.Pop();
            if (value > last)
            {
                continue;
            }

            if (value >= first && IsPrime((ulong)value))
            {
                count++;
            }

            if (value <= (last - 7) / 10)
            {
                foreach (var digit in Digits)
                {
                    stack.Push(value * 10 + digit);
                }
            }
        }

        return count;
    }

    internal static bool IsPrime(ulong n)
    {
        if (n < 2)
        {
            return false;
        }

        foreach (var p in Witnesses)
        {
            if (n % p == 0)
            {
                return n == p;
            }
        }

        ulong d = n - 1;
        int r = 0;
        while (d % 2 == 0)
        {
            d /= 2;
            r++;
        }

        foreach (var a in Witnesses)
        {
            ulong x = PowMod(a, d, n);
            if (x == 1 || x == n - 1)
            {
                continue;
            }

            bool composite = true;
            for (int i = 1; i < r && composite; i++)
            {
                x = (ulong)((UInt128)x * x % n);
                composite = x != n - 1;
            }

            if (composite)
            {
                return false;
            }
        }

        return true;
    }

    private static ulong PowMod(ulong value, ulong exponent, ulong modulus)
    {
        ulong result = 1;
        value %= modulus;
        for (; exponent > 0; exponent >>= 1)
        {
            if ((exponent & 1) == 1)
            {
                result = (ulong)((UInt128)result * value % modulus);
            }

            value = (ulong)((UInt128)value * value % modulus);
        }

        return result;
    }
}
