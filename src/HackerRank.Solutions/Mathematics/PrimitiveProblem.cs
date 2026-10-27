namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Primitive Problem — the smallest primitive root of the prime <c>p</c> and how many
/// primitive roots there are. g is a primitive root when g^((p-1)/q) ≠ 1 for every prime q
/// dividing p - 1, and there are φ(p - 1) of them.
/// https://www.hackerrank.com/challenges/primitive-problem
/// </summary>
public static class PrimitiveProblem
{
    public static long[] Solve(long p)
    {
        long order = p - 1;
        var factors = ModularMath.PrimeFactors(order);

        long root = 2;
        while (factors.Any(q => ModularMath.Power(root, order / q, p) == 1))
        {
            root++;
        }

        if (p == 2)
        {
            root = 1;
        }

        long totient = order;
        foreach (var q in factors)
        {
            totient = totient / q * (q - 1);
        }

        return [root, totient];
    }
}
