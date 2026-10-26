namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Truck Tour — petrol pumps on a circle, each given as [petrol, distanceToNext]. Return the
/// first pump from which the truck completes the loop. If the tank runs dry before pump i,
/// no start up to i can work, so restart from i + 1: one O(n) pass.
/// https://www.hackerrank.com/challenges/truck-tour
/// </summary>
public static class TruckTour
{
    public static int Solve(IReadOnlyList<IReadOnlyList<int>> petrolPumps)
    {
        int start = 0;
        long tank = 0;

        for (int i = 0; i < petrolPumps.Count; i++)
        {
            tank += petrolPumps[i][0] - petrolPumps[i][1];

            if (tank < 0)
            {
                start = i + 1;
                tank = 0;
            }
        }

        return start;
    }
}
