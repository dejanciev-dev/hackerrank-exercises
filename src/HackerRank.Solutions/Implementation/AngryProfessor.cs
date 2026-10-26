namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Angry Professor — class is cancelled ("YES") when fewer than <c>k</c> students arrive on
/// time. Arrival times &lt;= 0 are on time.
/// https://www.hackerrank.com/challenges/angry-professor
/// </summary>
public static class AngryProfessor
{
    public static string Solve(int k, IReadOnlyList<int> a)
    {
        int onTime = a.Count(arrival => arrival <= 0);
        return onTime < k ? "YES" : "NO";
    }
}
