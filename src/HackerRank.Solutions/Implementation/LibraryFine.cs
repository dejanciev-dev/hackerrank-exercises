namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Library Fine — fine for returning a book on d1/m1/y1 that was due d2/m2/y2:
/// 15 per late day, 500 per late month within the same year, or a flat 10000 if a year late.
/// https://www.hackerrank.com/challenges/library-fine
/// </summary>
public static class LibraryFine
{
    public static int Solve(int d1, int m1, int y1, int d2, int m2, int y2)
    {
        if (y1 > y2) return 10000;
        if (y1 < y2) return 0;

        if (m1 > m2) return 500 * (m1 - m2);
        if (m1 < m2) return 0;

        return d1 > d2 ? 15 * (d1 - d2) : 0;
    }
}
