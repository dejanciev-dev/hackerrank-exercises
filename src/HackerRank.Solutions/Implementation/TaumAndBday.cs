namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Taum and B'day — buy <c>b</c> black and <c>w</c> white gifts as cheaply as possible, where a
/// gift can also be bought in the other color and converted for <c>z</c>.
/// https://www.hackerrank.com/challenges/taum-and-bday
/// </summary>
public static class TaumAndBday
{
    public static long Solve(long b, long w, long bc, long wc, long z)
    {
        long blackPrice = Math.Min(bc, wc + z);
        long whitePrice = Math.Min(wc, bc + z);

        return b * blackPrice + w * whitePrice;
    }
}
