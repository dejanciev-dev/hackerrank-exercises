namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// The Indian Job — robbers each need A[i] uninterrupted minutes in the vault, and two can
/// work at once; can they all finish within <c>g</c> minutes? Split them into two groups each
/// totalling at most g: some subset sum S must satisfy total - g ≤ S ≤ g. Subset-sum DP over
/// a boolean array, O(n · total).
/// https://www.hackerrank.com/challenges/the-indian-job
/// </summary>
public static class TheIndianJob
{
    public static string Solve(int g, IReadOnlyList<int> a)
    {
        int total = a.Sum();
        if (total > 2L * g)
        {
            return "NO";
        }

        var reachable = new bool[total + 1];
        reachable[0] = true;

        foreach (var time in a)
        {
            for (int s = total; s >= time; s--)
            {
                reachable[s] |= reachable[s - time];
            }
        }

        for (int s = Math.Max(0, total - g); s <= Math.Min(g, total); s++)
        {
            if (reachable[s])
            {
                return "YES";
            }
        }

        return "NO";
    }
}
