namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Sales by Match (Sock Merchant) — count the matching pairs of socks by color.
/// https://www.hackerrank.com/challenges/sock-merchant
/// </summary>
public static class SalesByMatch
{
    public static int Solve(IReadOnlyList<int> ar)
    {
        var unmatched = new HashSet<int>();
        int pairs = 0;

        foreach (var color in ar)
        {
            // Remove succeeds only when a sock of the same color is already waiting for a partner.
            if (unmatched.Remove(color))
            {
                pairs++;
            }
            else
            {
                unmatched.Add(color);
            }
        }

        return pairs;
    }
}
