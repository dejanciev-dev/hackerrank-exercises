namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Diwali Lights — patterns from <c>n</c> bulbs with at least one on: 2^n - 1, modulo 10^5.
/// Fast modular exponentiation, O(log n).
/// https://www.hackerrank.com/challenges/diwali-lights
/// </summary>
public static class DiwaliLights
{
    private const long Mod = 100_000;

    public static long Solve(long n)
    {
        long result = 1;
        long powerOfTwo = 2;

        for (long exponent = n; exponent > 0; exponent >>= 1)
        {
            if ((exponent & 1) == 1)
            {
                result = result * powerOfTwo % Mod;
            }

            powerOfTwo = powerOfTwo * powerOfTwo % Mod;
        }

        return (result - 1 + Mod) % Mod;
    }
}
