namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Larry's Array — can the array be sorted by repeatedly rotating any three consecutive
/// elements? A rotation never changes the parity of the inversion count, so the answer is
/// YES exactly when the number of inversions is even.
/// https://www.hackerrank.com/challenges/larrys-array
/// </summary>
public static class LarrysArray
{
    public static string Solve(IReadOnlyList<int> a)
    {
        int inversions = 0;

        for (int i = 0; i < a.Count; i++)
        {
            for (int j = i + 1; j < a.Count; j++)
            {
                if (a[i] > a[j]) inversions++;
            }
        }

        return inversions % 2 == 0 ? "YES" : "NO";
    }
}
