namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Fun Game — players alternately claim an unused index i; the first player scores a[i] and
/// the second scores b[i]. Taking index i gains a[i] for yourself and denies b[i] to the
/// opponent (or vice versa), so both players greedily take the index with the largest
/// a[i] + b[i]. O(n log n).
/// https://www.hackerrank.com/challenges/fun-game
/// </summary>
public static class FunGame
{
    public static string Solve(IReadOnlyList<int> a, IReadOnlyList<int> b)
    {
        long first = 0;
        long second = 0;
        int turn = 0;

        foreach (int i in Enumerable.Range(0, a.Count).OrderByDescending(i => (long)a[i] + b[i]))
        {
            if (turn++ % 2 == 0)
            {
                first += a[i];
            }
            else
            {
                second += b[i];
            }
        }

        return first > second ? "First" : first < second ? "Second" : "Tie";
    }
}
