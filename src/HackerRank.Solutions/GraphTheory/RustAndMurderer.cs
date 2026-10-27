namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Rust &amp; Murderer — the given roads are main roads; Rust walks only along village roads,
/// which join every pair of cities not joined by a main road. BFS over that complement graph
/// without building it: keep the unvisited cities in a set, and from each city move to every
/// unvisited city it has no main road to. Each city leaves the set once, so O(n + m).
/// https://www.hackerrank.com/challenges/rust-murderer
/// </summary>
public static class RustAndMurderer
{
    public static int[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> roads, int s)
    {
        var mainRoads = new HashSet<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            mainRoads[i] = [];
        }

        foreach (var road in roads)
        {
            mainRoads[road[0]].Add(road[1]);
            mainRoads[road[1]].Add(road[0]);
        }

        var distance = new int[n + 1];
        var unvisited = new HashSet<int>(Enumerable.Range(1, n));
        unvisited.Remove(s);

        var queue = new Queue<int>();
        queue.Enqueue(s);

        while (queue.Count > 0 && unvisited.Count > 0)
        {
            int city = queue.Dequeue();
            var reached = unvisited.Where(next => !mainRoads[city].Contains(next)).ToList();

            foreach (var next in reached)
            {
                unvisited.Remove(next);
                distance[next] = distance[city] + 1;
                queue.Enqueue(next);
            }
        }

        foreach (var city in unvisited)
        {
            distance[city] = -1;
        }

        return Enumerable.Range(1, n).Where(i => i != s).Select(i => distance[i]).ToArray();
    }
}
