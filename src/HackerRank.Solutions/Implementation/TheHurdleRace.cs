namespace HackerRank.Solutions.Implementation;

/// <summary>
/// The Hurdle Race — doses of potion needed (1 unit of jump height each) to clear the tallest hurdle.
/// https://www.hackerrank.com/challenges/the-hurdle-race
/// </summary>
public static class TheHurdleRace
{
    public static int Solve(int k, IReadOnlyList<int> height) => Math.Max(0, height.Max() - k);
}
