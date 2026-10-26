namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Halloween Sale — the first game costs <c>p</c>, each next one costs <c>d</c> less, never below
/// <c>m</c>. How many games can be bought with budget <c>s</c>?
/// https://www.hackerrank.com/challenges/halloween-sale
/// </summary>
public static class HalloweenSale
{
    public static int Solve(int p, int d, int m, int s)
    {
        int games = 0;

        while (s >= p)
        {
            s -= p;
            games++;
            p = Math.Max(p - d, m);
        }

        return games;
    }
}
