namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Jim and the Orders — each order is [orderTime, prepTime]; return customer numbers (1-based)
/// in the order they're served: by orderTime + prepTime, ties broken by customer number.
/// https://www.hackerrank.com/challenges/jim-and-the-orders
/// </summary>
public static class JimAndTheOrders
{
    public static int[] Solve(IReadOnlyList<IReadOnlyList<int>> orders)
    {
        return Enumerable.Range(1, orders.Count)
            .OrderBy(customer => (long)orders[customer - 1][0] + orders[customer - 1][1])
            .ThenBy(customer => customer)
            .ToArray();
    }
}
