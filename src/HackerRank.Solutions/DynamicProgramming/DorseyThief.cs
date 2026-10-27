namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Dorsey Thief — passenger i offers v_i for carrying a_i units; take passengers whose units
/// add up to exactly x, maximising the total offer, or "Got caught!" if no selection fits.
/// 0/1 knapsack on exact weight, with unreachable weights marked. O(n · x).
/// https://www.hackerrank.com/challenges/dorsey-thief
/// </summary>
public static class DorseyThief
{
    /// <param name="x">The exact number of units to carry.</param>
    /// <param name="passengers">Each passenger as <c>[offer, units]</c>.</param>
    public static string Solve(int x, IReadOnlyList<IReadOnlyList<int>> passengers)
    {
        var best = new long[x + 1];
        Array.Fill(best, -1);
        best[0] = 0;

        foreach (var passenger in passengers)
        {
            int units = passenger[1];
            for (int w = x; w >= units; w--)
            {
                if (best[w - units] >= 0)
                {
                    best[w] = Math.Max(best[w], best[w - units] + passenger[0]);
                }
            }
        }

        return best[x] >= 0 ? best[x].ToString() : "Got caught!";
    }
}
