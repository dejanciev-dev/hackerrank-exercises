namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Electronics Shop — the most Monica can spend on one keyboard and one USB drive within
/// budget <c>b</c>, or -1 if no pair fits. Sorts and walks two pointers for O(n log n).
/// https://www.hackerrank.com/challenges/electronics-shop
/// </summary>
public static class ElectronicsShop
{
    public static int Solve(IReadOnlyList<int> keyboards, IReadOnlyList<int> drives, int b)
    {
        var sortedKeyboards = keyboards.Order().ToArray();
        var sortedDrives = drives.OrderDescending().ToArray();

        int best = -1;
        int k = 0;
        int d = 0;

        while (k < sortedKeyboards.Length && d < sortedDrives.Length)
        {
            int total = sortedKeyboards[k] + sortedDrives[d];

            if (total > b)
            {
                d++;
            }
            else
            {
                best = Math.Max(best, total);
                k++;
            }
        }

        return best;
    }
}
