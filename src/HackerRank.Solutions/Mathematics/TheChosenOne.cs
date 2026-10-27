namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// The Chosen One — find a number that divides all but exactly one element. Prefix and suffix
/// gcds give, for each i, the gcd g of everything except a[i]. If g doesn't divide a[i],
/// g is an answer. For a single element, a[0] + 1 works. O(n log max).
/// https://www.hackerrank.com/challenges/the-chosen-one
/// </summary>
public static class TheChosenOne
{
    public static long Solve(IReadOnlyList<long> a)
    {
        int n = a.Count;
        if (n == 1)
        {
            return a[0] + 1;
        }

        var prefix = new long[n + 1];
        var suffix = new long[n + 2];
        for (int i = 0; i < n; i++)
        {
            prefix[i + 1] = ModularMath.Gcd(prefix[i], a[i]);
        }

        for (int i = n - 1; i >= 0; i--)
        {
            suffix[i + 1] = ModularMath.Gcd(suffix[i + 2], a[i]);
        }

        for (int i = 0; i < n; i++)
        {
            long others = ModularMath.Gcd(prefix[i], suffix[i + 2]);
            if (a[i] % others != 0)
            {
                return others;
            }
        }

        throw new InvalidOperationException("No number divides all but exactly one element.");
    }
}
