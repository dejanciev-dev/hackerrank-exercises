namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Matrix — the cities form a tree and some hold machines; destroy roads at minimum total
/// cost so no two machines stay connected. Equivalently, keep the most expensive roads you
/// can: add roads most expensive first and skip (destroy) any road that would join two
/// components that both contain a machine. Union-find, O(n log n).
/// https://www.hackerrank.com/challenges/matrix
/// </summary>
public static class MatrixMachines
{
    /// <param name="roads">Each road as <c>[cityA, cityB, cost]</c>, with 0-based cities.</param>
    /// <param name="machines">The cities that hold a machine.</param>
    public static long Solve(IReadOnlyList<IReadOnlyList<int>> roads, IReadOnlyList<int> machines)
    {
        int n = roads.Count + 1;
        var set = new DisjointSet(n);
        var hasMachine = new bool[n];
        foreach (var city in machines)
        {
            hasMachine[city] = true;
        }

        long destroyed = 0;

        foreach (var road in roads.OrderByDescending(r => r[2]))
        {
            bool machineA = hasMachine[set.Find(road[0])];
            bool machineB = hasMachine[set.Find(road[1])];

            if (machineA && machineB)
            {
                destroyed += road[2];
                continue;
            }

            set.Union(road[0], road[1]);
            hasMachine[set.Find(road[0])] = machineA || machineB;
        }

        return destroyed;
    }
}
