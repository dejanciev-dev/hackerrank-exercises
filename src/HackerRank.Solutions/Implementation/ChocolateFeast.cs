namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Chocolate Feast — with <c>n</c> money, bars costing <c>c</c>, and a free bar for every
/// <c>m</c> wrappers, how many bars can be eaten in total?
/// https://www.hackerrank.com/challenges/chocolate-feast
/// </summary>
public static class ChocolateFeast
{
    public static int Solve(int n, int c, int m)
    {
        int eaten = n / c;
        int wrappers = eaten;

        while (wrappers >= m)
        {
            int free = wrappers / m;
            eaten += free;
            wrappers = wrappers % m + free;
        }

        return eaten;
    }
}
