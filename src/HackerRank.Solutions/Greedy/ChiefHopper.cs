namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Chief Hopper — jumping onto a building of height h changes energy e to 2e - h, which must
/// never go negative. Working backwards from the last building, the energy needed before each
/// jump is ceil((needed + h) / 2). O(n), with no binary search.
/// https://www.hackerrank.com/challenges/chief-hopper
/// </summary>
public static class ChiefHopper
{
    public static long Solve(IReadOnlyList<int> arr)
    {
        long needed = 0;

        for (int i = arr.Count - 1; i >= 0; i--)
        {
            needed = (needed + arr[i] + 1) / 2;
        }

        return needed;
    }
}
