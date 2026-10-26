namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Bill Division (Bon Appetit) — Anna didn't eat item <c>k</c>. Return "Bon Appetit" when
/// Brian charged her fairly, otherwise the amount he owes her.
/// https://www.hackerrank.com/challenges/bon-appetit
/// </summary>
public static class BillDivision
{
    public static string Solve(IReadOnlyList<int> bill, int k, int b)
    {
        int sum = 0;
        for (int i = 0; i < bill.Count; i++)
        {
            if (i != k)
            {
                sum += bill[i];
            }
        }

        int annaShare = sum / 2;
        return b == annaShare ? "Bon Appetit" : (b - annaShare).ToString();
    }
}
