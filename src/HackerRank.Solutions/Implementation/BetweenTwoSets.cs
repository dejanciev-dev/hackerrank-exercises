namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Between Two Sets — count integers that are multiples of every element of <c>a</c> and
/// divisors of every element of <c>b</c>. Those are exactly the multiples of lcm(a) that
/// divide gcd(b).
/// https://www.hackerrank.com/challenges/between-two-sets
/// </summary>
public static class BetweenTwoSets
{
    public static int Solve(IReadOnlyList<int> a, IReadOnlyList<int> b)
    {
        int lcm = a.Aggregate(Lcm);
        int gcd = b.Aggregate(Gcd);

        int count = 0;
        for (int candidate = lcm; candidate <= gcd; candidate += lcm)
        {
            if (gcd % candidate == 0)
            {
                count++;
            }
        }

        return count;
    }

    private static int Gcd(int x, int y)
    {
        while (y != 0)
        {
            (x, y) = (y, x % y);
        }

        return x;
    }

    private static int Lcm(int x, int y) => x / Gcd(x, y) * y;
}
