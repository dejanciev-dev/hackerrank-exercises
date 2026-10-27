namespace HackerRank.Solutions.Search;

/// <summary>
/// Bike Racers — assign bikes to bikers so the first <c>k</c> bikers can start as soon as
/// possible; return the square of the time needed. Binary search the answer over the sorted
/// squared distances. A value works if bikers and bikes within that distance admit a matching
/// of size k (Kuhn's augmenting paths). O(log(nm) · n · nm).
/// https://www.hackerrank.com/challenges/bike-racers
/// </summary>
public static class BikeRacers
{
    public static long Solve(IReadOnlyList<IReadOnlyList<int>> bikers, IReadOnlyList<IReadOnlyList<int>> bikes, int k)
    {
        var squared = new long[bikers.Count, bikes.Count];
        var candidates = new List<long>();

        for (int i = 0; i < bikers.Count; i++)
        {
            for (int j = 0; j < bikes.Count; j++)
            {
                long dx = bikers[i][0] - bikes[j][0];
                long dy = bikers[i][1] - bikes[j][1];
                squared[i, j] = dx * dx + dy * dy;
                candidates.Add(squared[i, j]);
            }
        }

        var distances = candidates.Distinct().Order().ToArray();
        int low = 0;
        int high = distances.Length - 1;

        while (low < high)
        {
            int mid = (low + high) / 2;
            if (MaxMatching(squared, distances[mid]) >= k)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return distances[low];
    }

    private static int MaxMatching(long[,] squared, long limit)
    {
        int bikers = squared.GetLength(0);
        var bikeOwner = new int[squared.GetLength(1)];
        Array.Fill(bikeOwner, -1);
        int matched = 0;

        for (int biker = 0; biker < bikers; biker++)
        {
            if (TryAssign(squared, limit, biker, bikeOwner, new bool[bikeOwner.Length]))
            {
                matched++;
            }
        }

        return matched;
    }

    private static bool TryAssign(long[,] squared, long limit, int biker, int[] bikeOwner, bool[] visited)
    {
        for (int bike = 0; bike < bikeOwner.Length; bike++)
        {
            if (squared[biker, bike] > limit || visited[bike])
            {
                continue;
            }

            visited[bike] = true;
            if (bikeOwner[bike] == -1 || TryAssign(squared, limit, bikeOwner[bike], bikeOwner, visited))
            {
                bikeOwner[bike] = biker;
                return true;
            }
        }

        return false;
    }
}
