namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Goodland Electricity — fewest power plants (on cities that can host one) so every city is
/// within distance <c>k</c> - 1 of a plant, or -1 if impossible. For the leftmost unpowered
/// city, switch on the rightmost suitable city that still covers it, then skip past its range.
/// O(n · k) worst case, usually far less.
/// https://www.hackerrank.com/challenges/pylons
/// </summary>
public static class GoodlandElectricity
{
    public static int Solve(int k, IReadOnlyList<int> arr)
    {
        int plants = 0;
        int city = 0;

        while (city < arr.Count)
        {
            int plant = Math.Min(city + k - 1, arr.Count - 1);
            int lowest = Math.Max(city - k + 1, 0);

            while (plant >= lowest && arr[plant] == 0)
            {
                plant--;
            }

            if (plant < lowest)
            {
                return -1;
            }

            plants++;
            city = plant + k;
        }

        return plants;
    }
}
