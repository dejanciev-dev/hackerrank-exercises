namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Mark and Toys — the most toys that can be bought with budget <c>k</c>: buy the cheapest first.
/// https://www.hackerrank.com/challenges/mark-and-toys
/// </summary>
public static class MarkAndToys
{
    public static int Solve(IReadOnlyList<int> prices, long k)
    {
        int toys = 0;

        foreach (var price in prices.Order())
        {
            if (price > k)
            {
                break;
            }

            k -= price;
            toys++;
        }

        return toys;
    }
}
