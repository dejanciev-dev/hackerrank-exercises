namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Power of Large Numbers — compute A^B modulo 10^9 + 7 where A and B (both at least 1) are given
/// as decimal strings of up to 100 000 digits.
/// Reduce the base modulo p = 10^9 + 7. If it becomes 0 the power is 0. Otherwise, by Fermat's
/// little theorem A^(p − 1) ≡ 1, so the exponent can be reduced modulo p − 1 before the modular
/// power is taken. Both reductions are single passes over the digits. O(digits + log p).
/// https://www.hackerrank.com/challenges/power-of-large-numbers
/// </summary>
public static class PowerOfLargeNumbers
{
    private const long Modulus = 1_000_000_007;

    public static long Solve(string a, string b)
    {
        long baseResidue = Reduce(a, Modulus);
        if (baseResidue == 0)
        {
            return 0;
        }

        return ModularMath.Power(baseResidue, Reduce(b, Modulus - 1), Modulus);
    }

    private static long Reduce(string digits, long modulus)
    {
        long residue = 0;
        foreach (var digit in digits)
        {
            residue = (residue * 10 + (digit - '0')) % modulus;
        }

        return residue;
    }
}
