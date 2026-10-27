namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Bricks Game — players alternately take 1, 2 or 3 bricks from the top of the stack; with
/// both playing optimally, what does the first player score? Whoever moves from brick i gets
/// everything left minus the best the opponent can then score, so
/// best(i) = suffix(i) - min(best(i + 1), best(i + 2), best(i + 3)). O(n).
/// https://www.hackerrank.com/challenges/play-game
/// </summary>
public static class BricksGame
{
    public static long Solve(IReadOnlyList<int> arr)
    {
        int n = arr.Count;
        var best = new long[n + 3];
        long suffix = 0;

        for (int i = n - 1; i >= 0; i--)
        {
            suffix += arr[i];
            best[i] = suffix - Math.Min(best[i + 1], Math.Min(best[i + 2], best[i + 3]));
        }

        return best[0];
    }
}
