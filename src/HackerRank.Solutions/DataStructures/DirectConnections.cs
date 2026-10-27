namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Direct Connections — every pair of cities is joined by |x_i - x_j| · max(p_i, p_j) cable;
/// return the total, modulo 1e9+7. Process cities in increasing population, so the current
/// city's population is the max for every pair with the cities already processed. Fenwick
/// trees over the compressed coordinates give the count and coordinate sum of those cities
/// on either side, so the summed distance takes O(log n). O(n log n).
/// https://www.hackerrank.com/challenges/direct-connections
/// </summary>
public static class DirectConnections
{
    private const long Mod = 1_000_000_007;

    public static long Solve(IReadOnlyList<int> x, IReadOnlyList<int> p)
    {
        int n = x.Count;
        var sortedX = x.Distinct().Order().ToArray();
        var count = new long[sortedX.Length + 1];
        var sum = new long[sortedX.Length + 1];
        long totalCount = 0;
        long totalSum = 0;
        long cable = 0;

        (long Count, long Sum) Prefix(int index)
        {
            long c = 0, s = 0;
            for (; index > 0; index -= index & -index)
            {
                c += count[index];
                s += sum[index];
            }

            return (c, s);
        }

        foreach (int i in Enumerable.Range(0, n).OrderBy(i => p[i]))
        {
            int rank = Array.BinarySearch(sortedX, x[i]) + 1;
            var (leftCount, leftSum) = Prefix(rank);
            long rightCount = totalCount - leftCount;
            long rightSum = totalSum - leftSum;

            long distance = (x[i] * leftCount - leftSum + rightSum - x[i] * rightCount) % Mod;
            cable = (cable + distance * p[i]) % Mod;

            for (int j = rank; j < count.Length; j += j & -j)
            {
                count[j]++;
                sum[j] += x[i];
            }

            totalCount++;
            totalSum += x[i];
        }

        return cable;
    }
}
