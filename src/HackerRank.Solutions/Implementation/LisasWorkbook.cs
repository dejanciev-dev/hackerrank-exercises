namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Lisa's Workbook — each chapter starts on a new page and a page holds at most <c>k</c>
/// problems. Count "special" problems whose number equals the page they're printed on.
/// https://www.hackerrank.com/challenges/lisa-workbook
/// </summary>
public static class LisasWorkbook
{
    public static int Solve(int k, IReadOnlyList<int> arr)
    {
        int page = 1;
        int special = 0;

        foreach (var problems in arr)
        {
            for (int problem = 1; problem <= problems; problem++)
            {
                if (problem == page)
                {
                    special++;
                }

                if (problem % k == 0 || problem == problems)
                {
                    page++;
                }
            }
        }

        return special;
    }
}
