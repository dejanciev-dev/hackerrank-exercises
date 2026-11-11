namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Mehta and his Laziness — pick a divisor of n other than n itself uniformly at random; what
/// is the probability that it is an even perfect square? Print a reduced fraction, or "0".
/// With n = 2^a · Π p^e, the even square divisors are 2^(2i) (1 ≤ i ≤ a / 2) times any square
/// of the odd part, so there are ⌊a / 2⌋ · Π (⌊e / 2⌋ + 1); drop n itself if it qualifies.
/// O(√n).
/// https://www.hackerrank.com/challenges/mehta-and-his-laziness
/// </summary>
public static class MehtaAndHisLaziness
{
    public static string Solve(int n)
    {
        long divisors = 1, evenSquares = 1;
        int remaining = n;
        for (int p = 2; (long)p * p <= remaining; p++)
        {
            int e = 0;
            while (remaining % p == 0)
            {
                remaining /= p;
                e++;
            }

            divisors *= e + 1;
            evenSquares *= p == 2 ? e / 2 : e / 2 + 1;
        }

        if (remaining > 1)
        {
            divisors *= 2;
            evenSquares *= remaining == 2 ? 0 : 1;
        }

        if (n % 2 != 0)
        {
            evenSquares = 0;
        }

        long root = (long)Math.Round(Math.Sqrt(n));
        if (root * root == n && n % 2 == 0)
        {
            evenSquares--;
        }

        long proper = divisors - 1;
        if (evenSquares == 0)
        {
            return "0";
        }

        long gcd = ModularMath.Gcd(evenSquares, proper);
        return $"{evenSquares / gcd}/{proper / gcd}";
    }
}
