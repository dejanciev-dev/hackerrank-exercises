namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Jim and his LAN Party — every person plays one of m games, and wires join pairs of people
/// one at a time. For each game, after which wire are all of its players connected? Use 0 if
/// they already are (a single player) and −1 if they never are.
/// Union-find where each component keeps a game → player count map, merged small into large.
/// A game is done when one component's count for it reaches the game's total. O(n log² n).
/// https://www.hackerrank.com/challenges/jim-and-his-lan-party
/// </summary>
public static class JimAndHisLanParty
{
    /// <param name="m">The number of games.</param>
    /// <param name="games">The game played by each person, numbered from 1.</param>
    /// <param name="wires">The wires in order, each as <c>[u, v]</c>, people numbered from 1.</param>
    public static int[] Solve(int m, IReadOnlyList<int> games, IReadOnlyList<IReadOnlyList<int>> wires)
    {
        int n = games.Count;
        var players = new int[m + 1];
        foreach (int game in games)
        {
            players[game]++;
        }

        var answer = new int[m];
        for (int game = 1; game <= m; game++)
        {
            answer[game - 1] = players[game] <= 1 ? 0 : -1;
        }

        var parent = new int[n];
        var counts = new Dictionary<int, int>[n];
        for (int person = 0; person < n; person++)
        {
            parent[person] = person;
            counts[person] = new Dictionary<int, int> { [games[person]] = 1 };
        }

        for (int wire = 0; wire < wires.Count; wire++)
        {
            int a = Find(wires[wire][0] - 1), b = Find(wires[wire][1] - 1);
            if (a == b)
            {
                continue;
            }

            if (counts[a].Count < counts[b].Count)
            {
                (a, b) = (b, a);
            }

            parent[b] = a;
            foreach (var (game, count) in counts[b])
            {
                int merged = counts[a].GetValueOrDefault(game) + count;
                counts[a][game] = merged;
                if (merged == players[game] && answer[game - 1] < 0)
                {
                    answer[game - 1] = wire + 1;
                }
            }

            counts[b] = [];
        }

        return answer;

        int Find(int v)
        {
            while (parent[v] != v)
            {
                parent[v] = parent[parent[v]];
                v = parent[v];
            }

            return v;
        }
    }
}
