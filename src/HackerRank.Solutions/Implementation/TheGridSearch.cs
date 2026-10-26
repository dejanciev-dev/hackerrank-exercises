namespace HackerRank.Solutions.Implementation;

/// <summary>
/// The Grid Search — does the 2D digit pattern <c>p</c> occur anywhere inside grid <c>g</c>?
/// https://www.hackerrank.com/challenges/the-grid-search
/// </summary>
public static class TheGridSearch
{
    public static string Solve(IReadOnlyList<string> g, IReadOnlyList<string> p)
    {
        int patternWidth = p[0].Length;

        for (int row = 0; row + p.Count <= g.Count; row++)
        {
            for (int col = 0; col + patternWidth <= g[row].Length; col++)
            {
                if (MatchesAt(g, p, row, col))
                {
                    return "YES";
                }
            }
        }

        return "NO";
    }

    private static bool MatchesAt(IReadOnlyList<string> g, IReadOnlyList<string> p, int row, int col)
    {
        for (int i = 0; i < p.Count; i++)
        {
            if (string.CompareOrdinal(g[row + i], col, p[i], 0, p[i].Length) != 0)
            {
                return false;
            }
        }

        return true;
    }
}
