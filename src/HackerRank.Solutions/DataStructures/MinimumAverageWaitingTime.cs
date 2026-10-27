namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Minimum Average Waiting Time — Tieu serves one pizza at a time and can pick any waiting
/// customer; minimise the integer part of the average wait (arrival to served). Shortest job
/// first is optimal: whenever the oven is free, cook the shortest order among those who have
/// arrived. Sort by arrival plus a min-heap on cooking time, O(n log n).
/// https://www.hackerrank.com/challenges/minimum-average-waiting-time
/// </summary>
public static class MinimumAverageWaitingTime
{
    /// <param name="customers">Each customer as <c>[arrivalTime, cookingTime]</c>.</param>
    public static long Solve(IReadOnlyList<IReadOnlyList<int>> customers)
    {
        var byArrival = customers.OrderBy(c => c[0]).ToArray();
        var waiting = new PriorityQueue<IReadOnlyList<int>, int>();
        long time = 0;
        long totalWait = 0;
        int next = 0;

        while (next < byArrival.Length || waiting.Count > 0)
        {
            if (waiting.Count == 0)
            {
                time = Math.Max(time, byArrival[next][0]);
            }

            while (next < byArrival.Length && byArrival[next][0] <= time)
            {
                waiting.Enqueue(byArrival[next], byArrival[next][1]);
                next++;
            }

            var customer = waiting.Dequeue();
            time += customer[1];
            totalWait += time - customer[0];
        }

        return totalWait / customers.Count;
    }
}
