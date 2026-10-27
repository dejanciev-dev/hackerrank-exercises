namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Journey Scheduling — starting at city v, each of k journeys goes to the farthest city from
/// the current one; return the total distance. In a tree, the farthest city from anywhere is
/// an end of some diameter. So the first journey covers the longer of the distances to the
/// two diameter ends, and every later one covers the full diameter. Three BFS passes, then
/// O(1) per query.
/// https://www.hackerrank.com/challenges/journey-scheduling
/// </summary>
public static class JourneyScheduling
{
    /// <param name="n">Number of cities, labelled 1..n.</param>
    /// <param name="roads">Undirected unit-length roads.</param>
    /// <param name="journeys">Each query as <c>[v, k]</c>.</param>
    public static long[] Solve(int n, IReadOnlyList<IReadOnlyList<int>> roads, IReadOnlyList<IReadOnlyList<int>> journeys)
    {
        var adjacency = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            adjacency[i] = [];
        }

        foreach (var road in roads)
        {
            adjacency[road[0]].Add(road[1]);
            adjacency[road[1]].Add(road[0]);
        }

        int endA = Farthest(Distances(adjacency, 1, n));
        var fromA = Distances(adjacency, endA, n);
        int endB = Farthest(fromA);
        var fromB = Distances(adjacency, endB, n);
        long diameter = fromA[endB];

        return journeys
            .Select(j => Math.Max(fromA[j[0]], fromB[j[0]]) + (j[1] - 1) * diameter)
            .ToArray();
    }

    private static int[] Distances(List<int>[] adjacency, int start, int n)
    {
        var distance = new int[n + 1];
        Array.Fill(distance, -1);
        distance[start] = 0;
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            foreach (var v in adjacency[u])
            {
                if (distance[v] == -1)
                {
                    distance[v] = distance[u] + 1;
                    queue.Enqueue(v);
                }
            }
        }

        return distance;
    }

    private static int Farthest(int[] distance)
    {
        int best = 1;
        for (int i = 1; i < distance.Length; i++)
        {
            if (distance[i] > distance[best])
            {
                best = i;
            }
        }

        return best;
    }
}
