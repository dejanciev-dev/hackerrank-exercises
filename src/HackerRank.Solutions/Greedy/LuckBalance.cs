namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Luck Balance — losing a contest adds its luck, winning subtracts it, and at most <c>k</c>
/// important contests may be lost. Lose every unimportant contest and the k luckiest important ones.
/// Each contest is [luck, importance].
/// https://www.hackerrank.com/challenges/luck-balance
/// </summary>
public static class LuckBalance
{
    public static int Solve(int k, IReadOnlyList<IReadOnlyList<int>> contests)
    {
        int luck = contests.Where(c => c[1] == 0).Sum(c => c[0]);

        var important = contests.Where(c => c[1] == 1)
            .Select(c => c[0])
            .OrderDescending()
            .ToArray();

        for (int i = 0; i < important.Length; i++)
        {
            luck += i < k ? important[i] : -important[i];
        }

        return luck;
    }
}
