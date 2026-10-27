namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Demanding Money — Killgrave visits houses, but never two that are directly connected; find
/// the most money he can collect and how many sets of houses achieve it. This is a
/// maximum-weight independent set on at most 34 vertices. Branch on the lowest remaining
/// vertex: skip it, or take it and drop its neighbours. Memoising on the remaining-vertex
/// bitmask keeps this well below 2^n.
/// https://www.hackerrank.com/challenges/borrowing-money
/// </summary>
public static class DemandingMoney
{
    /// <param name="money">The money at house i + 1.</param>
    /// <param name="roads">Each road as <c>[u, v]</c>, 1-based.</param>
    public static long[] Solve(IReadOnlyList<int> money, IReadOnlyList<IReadOnlyList<int>> roads)
    {
        int n = money.Count;
        var neighbours = new ulong[n];
        foreach (var road in roads)
        {
            neighbours[road[0] - 1] |= 1UL << (road[1] - 1);
            neighbours[road[1] - 1] |= 1UL << (road[0] - 1);
        }

        var memo = new Dictionary<ulong, (long Best, long Ways)>();

        (long Best, long Ways) Search(ulong remaining)
        {
            if (remaining == 0)
            {
                return (0, 1);
            }

            if (memo.TryGetValue(remaining, out var known))
            {
                return known;
            }

            int v = System.Numerics.BitOperations.TrailingZeroCount(remaining);
            ulong without = remaining & ~(1UL << v);

            var skip = Search(without);
            var take = Search(without & ~neighbours[v]);
            take = (take.Best + money[v], take.Ways);

            var result = skip.Best == take.Best ? (skip.Best, skip.Ways + take.Ways)
                : skip.Best > take.Best ? skip : take;

            return memo[remaining] = result;
        }

        var (best, ways) = Search(n == 64 ? ulong.MaxValue : (1UL << n) - 1);
        return [best, ways];
    }
}
