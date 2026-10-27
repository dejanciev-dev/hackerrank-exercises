namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Real Estate Broker — client i wants a house with area above a_i and price at most p_i;
/// each house can be sold once. The most sales is a maximum bipartite matching between
/// clients and the houses they accept.
/// https://www.hackerrank.com/challenges/real-estate-broker
/// </summary>
public static class RealEstateBroker
{
    /// <param name="clients">Each client as <c>[minimumArea, maximumPrice]</c>.</param>
    /// <param name="houses">Each house as <c>[area, price]</c>.</param>
    public static int Solve(IReadOnlyList<IReadOnlyList<int>> clients, IReadOnlyList<IReadOnlyList<int>> houses) =>
        BipartiteMatching.MaxMatching(
            clients.Count,
            houses.Count,
            (c, h) => houses[h][0] > clients[c][0] && houses[h][1] <= clients[c][1]);
}
