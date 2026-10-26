namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Abbreviation — can <c>a</c> become <c>b</c> by capitalizing some lowercase letters and
/// deleting all remaining lowercase ones? reachable[i, j] means a[..i] can produce b[..j].
/// O(|a| · |b|).
/// https://www.hackerrank.com/challenges/abbr
/// </summary>
public static class Abbreviation
{
    public static string Solve(string a, string b)
    {
        var reachable = new bool[a.Length + 1, b.Length + 1];
        reachable[0, 0] = true;

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j <= b.Length; j++)
            {
                if (!reachable[i, j])
                {
                    continue;
                }

                // Keep a[i] (capitalizing it if needed) to match b[j].
                if (j < b.Length && char.ToUpperInvariant(a[i]) == b[j])
                {
                    reachable[i + 1, j + 1] = true;
                }

                // Delete a[i], allowed only for lowercase letters.
                if (char.IsLower(a[i]))
                {
                    reachable[i + 1, j] = true;
                }
            }
        }

        return reachable[a.Length, b.Length] ? "YES" : "NO";
    }
}
