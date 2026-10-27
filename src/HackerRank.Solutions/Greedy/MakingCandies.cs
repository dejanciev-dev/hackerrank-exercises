namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Making Candies — <c>m</c> machines and <c>w</c> workers make m · w candies per pass, and
/// either can be bought for <c>p</c> candies; fewest passes to reach <c>n</c> candies.
/// Whenever buying is affordable, spend everything, keeping m and w as balanced as possible
/// (that maximises their product). After every step, record the answer if we stopped buying
/// and just waited. Waiting stretches are skipped in one go, and Int128 keeps the huge
/// products (up to 10^24) exact.
/// https://www.hackerrank.com/challenges/making-candies
/// </summary>
public static class MakingCandies
{
    public static long Solve(long m, long w, long p, long n)
    {
        Int128 machines = m;
        Int128 workers = w;
        Int128 candies = 0;
        Int128 passes = 0;
        Int128 best = Int128.MaxValue;

        while (candies < n)
        {
            Int128 rate = machines * workers;
            best = Int128.Min(best, passes + CeilDiv(n - candies, rate));

            Int128 wait = (p - candies) / rate;

            if (wait <= 0)
            {
                Int128 total = candies / p + machines + workers;
                Int128 half = (total + 1) / 2;

                if (machines > workers)
                {
                    machines = Int128.Max(machines, half);
                    workers = total - machines;
                }
                else
                {
                    workers = Int128.Max(workers, half);
                    machines = total - workers;
                }

                candies %= p;
                wait = 1;
            }

            rate = machines * workers;
            candies += wait * rate;
            passes += wait;

            best = Int128.Min(best, passes + CeilDiv(n - candies, rate));
        }

        return (long)Int128.Min(best, passes);
    }

    private static Int128 CeilDiv(Int128 remaining, Int128 rate) =>
        remaining <= 0 ? 0 : (remaining + rate - 1) / rate;
}
